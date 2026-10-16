using CodexSwitch.Models;
using CodexSwitch.Services;

namespace CodexSwitch.Tests;

public sealed class ClaudeCodeConfigWriterTests : IDisposable
{
    private readonly string _tempDirectory = Path.Combine(
        Path.GetTempPath(),
        "CodexSwitchTests",
        Guid.NewGuid().ToString("N"));

    [Theory]
    [InlineData("claude-sonnet-4-5", false, true, false)]
    [InlineData("claude-opus-4-7", true, false, true)]
    [InlineData("claude-haiku-5-5", true, false, true)]
    [InlineData("custom-model", false, false, false)]
    public void ModelCapabilities_SeparateDefaultContextBetaAndThinking(
        string model, bool defaultContext, bool betaHeader, bool adaptiveThinking)
    {
        Assert.Equal(defaultContext, ClaudeModelCapabilities.HasDefaultOneMillionContext(model));
        Assert.Equal(betaHeader, ClaudeModelCapabilities.RequiresOneMillionBeta(model));
        Assert.Equal(adaptiveThinking, ClaudeModelCapabilities.UsesAdaptiveThinking(model));
    }

    [Fact]
    public void Apply_DoesNotAddLegacyOneMillionSuffixToDefaultContextModel()
    {
        var paths = CreatePaths("default-1m");
        var config = CreateConfig(manageClaudeCode: true);
        var provider = Assert.Single(config.Providers);
        provider.ClaudeCode.Model = "claude-opus-4-7";
        provider.ClaudeCode.EnableOneMillionContext = true;
        provider.Models.Clear();
        provider.Models.Add(new ModelRouteConfig { Id = "claude-opus-4-7" });

        new ClaudeCodeConfigWriter(paths).Apply(config);

        var settings = File.ReadAllText(paths.ClaudeSettingsPath);
        Assert.Contains("claude-opus-4-7", settings, StringComparison.Ordinal);
        Assert.DoesNotContain("[1m]", settings, StringComparison.Ordinal);
    }

    [Fact]
    public void Apply_LeavesUserSettingsUntouched_WhenManageDisabled()
    {
        var paths = CreatePaths("disabled");
        Directory.CreateDirectory(paths.ClaudeDirectory);
        const string original = "{\n  \"env\": { \"ANTHROPIC_BASE_URL\": \"https://api.anthropic.com\" }\n}\n";
        File.WriteAllText(paths.ClaudeSettingsPath, original);

        var writer = new ClaudeCodeConfigWriter(paths);
        writer.Apply(CreateConfig(manageClaudeCode: false));

        Assert.Equal(original, File.ReadAllText(paths.ClaudeSettingsPath));
        Assert.False(File.Exists(BackupPath(paths.ClaudeSettingsPath)));
    }

    [Fact]
    public void Apply_WritesManagedSettings_WhenManageEnabled()
    {
        var paths = CreatePaths("enabled");
        Directory.CreateDirectory(paths.ClaudeDirectory);
        const string original = "{\n  \"env\": { \"ANTHROPIC_BASE_URL\": \"https://api.anthropic.com\" }\n}\n";
        File.WriteAllText(paths.ClaudeSettingsPath, original);

        var writer = new ClaudeCodeConfigWriter(paths);
        writer.Apply(CreateConfig(manageClaudeCode: true));

        var settings = File.ReadAllText(paths.ClaudeSettingsPath);
        Assert.Contains("\"ANTHROPIC_BASE_URL\": \"http://127.0.0.1:12785\"", settings, StringComparison.Ordinal);
        Assert.Contains("\"ANTHROPIC_AUTH_TOKEN\": \"sk-codex\"", settings, StringComparison.Ordinal);
        Assert.True(File.Exists(BackupPath(paths.ClaudeSettingsPath)));
        Assert.Equal(original, File.ReadAllText(BackupPath(paths.ClaudeSettingsPath)));
    }

    [Fact]
    public void RestoreOriginal_DoesNotDeleteUserSettings_WhenNeverManaged()
    {
        var paths = CreatePaths("restore-safe");
        Directory.CreateDirectory(paths.ClaudeDirectory);
        const string original = "{\n  \"model\": \"claude-sonnet-4-5\"\n}\n";
        File.WriteAllText(paths.ClaudeSettingsPath, original);

        var writer = new ClaudeCodeConfigWriter(paths);
        writer.RestoreOriginal();

        Assert.True(File.Exists(paths.ClaudeSettingsPath));
        Assert.Equal(original, File.ReadAllText(paths.ClaudeSettingsPath));
    }

    [Fact]
    public void Apply_RestoresOriginal_WhenManageToggledOff()
    {
        var paths = CreatePaths("toggle-off");
        Directory.CreateDirectory(paths.ClaudeDirectory);
        const string original = "{\n  \"env\": { \"ANTHROPIC_BASE_URL\": \"https://api.anthropic.com\" }\n}\n";
        File.WriteAllText(paths.ClaudeSettingsPath, original);

        var writer = new ClaudeCodeConfigWriter(paths);
        writer.Apply(CreateConfig(manageClaudeCode: true));
        Assert.NotEqual(original, File.ReadAllText(paths.ClaudeSettingsPath));

        writer.Apply(CreateConfig(manageClaudeCode: false));

        Assert.Equal(original, File.ReadAllText(paths.ClaudeSettingsPath));
        Assert.False(File.Exists(BackupPath(paths.ClaudeSettingsPath)));
    }

    private AppPaths CreatePaths(string name)
    {
        var appRoot = Path.Combine(_tempDirectory, name, "appdata");
        var codexRoot = Path.Combine(_tempDirectory, name, "codex");
        var claudeRoot = Path.Combine(_tempDirectory, name, "claude");
        return new AppPaths(appRoot, codexRoot, claudeRoot);
    }

    private static AppConfig CreateConfig(bool manageClaudeCode)
    {
        return new AppConfig
        {
            ActiveClaudeCodeProviderId = "anthropic",
            Proxy = new ProxySettings
            {
                Host = "127.0.0.1",
                Port = 12785,
                InboundApiKey = "sk-codex",
                ManageClaudeCodeConfig = manageClaudeCode
            },
            Providers =
            {
                new ProviderConfig
                {
                    Id = "anthropic",
                    Protocol = ProviderProtocol.AnthropicMessages,
                    SupportsClaudeCode = true,
                    DefaultModel = "claude-sonnet-4-5",
                    Models =
                    {
                        new ModelRouteConfig { Id = "claude-sonnet-4-5" }
                    }
                }
            }
        };
    }

    private static string BackupPath(string path)
    {
        return path + ".bak";
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDirectory))
            Directory.Delete(_tempDirectory, recursive: true);
    }
}
