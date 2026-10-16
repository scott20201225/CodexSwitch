using CodexSwitch.Models;

namespace CodexSwitch.Services;

public static class ClaudeModelCapabilities
{
    public static string ResolveUpstreamModel(ProviderConfig provider, string model)
    {
        var id = ClaudeCodeConfigWriter.StripOneMillionSuffix(model);
        return provider.Models.FirstOrDefault(route =>
            string.Equals(route.Id, id, StringComparison.OrdinalIgnoreCase))?.UpstreamModel is { Length: > 0 } upstream
            ? upstream
            : id;
    }

    public static bool HasDefaultOneMillionContext(string? model)
    {
        var id = Normalize(model);
        return IsAtLeastClaude46(id) ||
            id.StartsWith("claude-haiku-5-5", StringComparison.Ordinal) ||
            id.StartsWith("claude-fable-5", StringComparison.Ordinal) ||
            id.StartsWith("claude-mythos-5", StringComparison.Ordinal);
    }

    public static bool RequiresOneMillionBeta(string? model)
    {
        var id = Normalize(model);
        return !HasDefaultOneMillionContext(id) &&
            (id == "sonnet" || id.StartsWith("claude-sonnet-4", StringComparison.Ordinal));
    }

    public static bool UsesAdaptiveThinking(string? model)
    {
        var id = Normalize(model);
        return IsAtLeastClaude46(id) ||
            id.StartsWith("claude-haiku-5-5", StringComparison.Ordinal) ||
            id.StartsWith("claude-fable-5", StringComparison.Ordinal) ||
            id.StartsWith("claude-mythos-5", StringComparison.Ordinal);
    }

    public static bool SupportsManualThinking(string? model)
    {
        var id = Normalize(model);
        return (id == "claude-sonnet-4" || id.StartsWith("claude-sonnet-4-", StringComparison.Ordinal)) && !IsAtLeastClaude46(id) ||
            id == "claude-opus-4" ||
            id.StartsWith("claude-opus-4-5", StringComparison.Ordinal) ||
            id.StartsWith("claude-haiku-4-5", StringComparison.Ordinal);
    }

    private static bool IsAtLeastClaude46(string id)
    {
        return id.StartsWith("claude-opus-4-6", StringComparison.Ordinal) ||
            id.StartsWith("claude-opus-4-7", StringComparison.Ordinal) ||
            id.StartsWith("claude-opus-4-8", StringComparison.Ordinal) ||
            id.StartsWith("claude-opus-5", StringComparison.Ordinal) ||
            id.StartsWith("claude-sonnet-4-6", StringComparison.Ordinal) ||
            id.StartsWith("claude-sonnet-5", StringComparison.Ordinal);
    }

    private static string Normalize(string? model)
    {
        return string.IsNullOrWhiteSpace(model)
            ? string.Empty
            : ClaudeCodeConfigWriter.StripOneMillionSuffix(model.Trim()).ToLowerInvariant();
    }
}
