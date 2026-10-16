using System.Collections.ObjectModel;
using CodexSwitch.Models;

namespace CodexSwitch.Services;

public static class BuiltInModelCatalog
{
    public const string PricingSchemaVersion = "1.3";
    public const long OpenAiLongContextThresholdTokens = 272_000;
    public const long XiaomiLongContextThresholdTokens = 256_000;

    public static IReadOnlyList<ProviderTemplateModel> RoutinAiModels { get; } =
    [
        OpenAiResponsesRoute("gpt-6-astra", "GPT-6 Astra", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("gpt-6.1-sol", "GPT-6.1 Sol", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("gpt-6-luna", "GPT-6 Luna", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("gpt-5.6-sol", "GPT-5.6 Sol", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("gpt-5.5", "GPT-5.5", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("gpt-5", "GPT-5", upstreamModel: "gpt-5.5", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("gpt-5.4", "GPT-5.4", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("gpt-5.4-mini", "GPT-5.4 Mini", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("codex-mini-latest", "Codex Mini Latest", serviceTier: "priority", fastMode: true),
        OpenAiChatRoute("deepseek-v4.1-flash", "DeepSeek V4.1 Flash", serviceTier: "priority", fastMode: true),
        OpenAiChatRoute("deepseek-v4.1-pro", "DeepSeek V4.1 Pro", serviceTier: "priority", fastMode: true),
        OpenAiChatRoute("deepseek-v4-flash", "DeepSeek V4 Flash", serviceTier: "priority", fastMode: true),
        OpenAiChatRoute("deepseek-v4-pro", "DeepSeek V4 Pro", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("mimo-v2.5-pro", "MiMo V2.5 Pro", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("mimo-v2.5", "MiMo V2.5", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("mimo-v2-omni", "MiMo V2 Omni", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("mimo-v2-pro", "MiMo V2 Pro", serviceTier: "priority", fastMode: true),
        OpenAiResponsesRoute("mimo-v2-flash", "MiMo V2 Flash", serviceTier: "priority", fastMode: true)
    ];

    public static IReadOnlyList<ProviderTemplateModel> OpenAiOfficialModels { get; } =
    [
        OpenAiResponsesRoute("gpt-6-astra", "GPT-6 Astra"),
        OpenAiResponsesRoute("gpt-6.1-sol", "GPT-6.1 Sol"),
        OpenAiResponsesRoute("gpt-6-sol", "GPT-6 Sol", upstreamModel: "gpt-6.1-sol"),
        OpenAiResponsesRoute("gpt-6-luna", "GPT-6 Luna"),
        OpenAiResponsesRoute("gpt-5.6-sol", "GPT-5.6 Sol"),
        OpenAiResponsesRoute("gpt-5.5", "GPT-5.5"),
        OpenAiResponsesRoute("gpt-5.4", "GPT-5.4"),
        OpenAiResponsesRoute("gpt-5.4-mini", "GPT-5.4 Mini"),
        OpenAiResponsesRoute("codex-mini-latest", "Codex Mini Latest")
    ];

    public static IReadOnlyList<ProviderTemplateModel> AnthropicModels { get; } =
    [
        AnthropicRoute("sonnet", "Claude Code Sonnet", upstreamModel: "claude-sonnet-5-5"),
        AnthropicRoute("opus", "Claude Code Opus", upstreamModel: "claude-opus-5-5"),
        AnthropicRoute("haiku", "Claude Code Haiku", upstreamModel: "claude-haiku-5-5"),
        AnthropicRoute("claude-opus-5-5", "Claude Opus 5.5"),
        AnthropicRoute("claude-sonnet-5-5", "Claude Sonnet 5.5"),
        AnthropicRoute("claude-haiku-5-5", "Claude Haiku 5.5"),
        AnthropicRoute("claude-fable-5-1", "Claude Fable 5.1"),
        AnthropicRoute("claude-opus-4-7", "Claude Opus 4.7"),
        AnthropicRoute("claude-opus-4-6", "Claude Opus 4.6"),
        AnthropicRoute("claude-opus-4-5", "Claude Opus 4.5", upstreamModel: "claude-opus-4-5-20251101"),
        AnthropicRoute("claude-sonnet-4-6", "Claude Sonnet 4.6"),
        AnthropicRoute("claude-sonnet-4-5", "Claude Sonnet 4.5", upstreamModel: "claude-sonnet-4-5-20250929"),
        AnthropicRoute("claude-3-7-sonnet", "Claude Sonnet 3.7", upstreamModel: "claude-3-7-sonnet-20250219"),
        AnthropicRoute("claude-3-5-sonnet", "Claude Sonnet 3.5", upstreamModel: "claude-3-5-sonnet-20241022"),
        AnthropicRoute("claude-haiku-4-5", "Claude Haiku 4.5", upstreamModel: "claude-haiku-4-5-20251001"),
        AnthropicRoute("claude-3-5-haiku", "Claude Haiku 3.5", upstreamModel: "claude-3-5-haiku-20241022")
    ];

    public static IReadOnlyList<ProviderTemplateModel> DeepSeekModels { get; } =
    [
        OpenAiChatRoute("deepseek-v4.1-flash", "DeepSeek V4.1 Flash"),
        OpenAiChatRoute("deepseek-v4.1-pro", "DeepSeek V4.1 Pro"),
        OpenAiChatRoute("deepseek-chat", "DeepSeek Chat"),
        OpenAiChatRoute("deepseek-reasoner", "DeepSeek Reasoner"),
        OpenAiChatRoute("deepseek-v4-flash", "DeepSeek V4 Flash"),
        OpenAiChatRoute("deepseek-v4-pro", "DeepSeek V4 Pro")
    ];

    public static IReadOnlyList<ProviderTemplateModel> XiaomiModels { get; } =
    [
        OpenAiChatRoute("mimo-v2.5-pro", "MiMo V2.5 Pro"),
        OpenAiChatRoute("mimo-v2.5", "MiMo V2.5"),
        OpenAiChatRoute("mimo-v2-omni", "MiMo V2 Omni"),
        OpenAiChatRoute("mimo-v2-flash", "MiMo V2 Flash")
    ];

    public static IReadOnlyList<ProviderTemplateModel> QwenModels { get; } =
    [
        OpenAiChatRoute("qwen3-coder-plus", "Qwen3 Coder Plus"),
        OpenAiChatRoute("qwen3-max", "Qwen3 Max"),
        OpenAiChatRoute("qwen3-plus", "Qwen3 Plus")
    ];

    public static IReadOnlyList<ProviderTemplateModel> ZhipuModels { get; } =
    [
        OpenAiChatRoute("glm-5-plus", "GLM-5 Plus"),
        OpenAiChatRoute("glm-5-flash", "GLM-5 Flash"),
        OpenAiChatRoute("glm-4-plus", "GLM-4 Plus")
    ];

    public static IReadOnlyList<ProviderTemplateModel> MoonshotModels { get; } =
    [
        OpenAiChatRoute("kimi-k2.5", "Kimi K2.5"),
        OpenAiChatRoute("kimi-k2", "Kimi K2"),
        OpenAiChatRoute("moonshot-v1-128k", "Moonshot V1 128K")
    ];

    public static IReadOnlyList<ProviderTemplateModel> DoubaoModels { get; } =
    [
        OpenAiChatRoute("doubao-1.5-pro", "Doubao 1.5 Pro"),
        OpenAiChatRoute("doubao-1.5-lite", "Doubao 1.5 Lite"),
        OpenAiChatRoute("doubao-seed-1.5", "Doubao Seed 1.5")
    ];

    public static FastModePricing CreateFastModePricing()
    {
        return new FastModePricing
        {
            DefaultMultiplier = 2m,
            ModelOverrides = CreateFastModeOverrides()
        };
    }

    public static Dictionary<string, decimal> CreateFastModeOverrides()
    {
        return new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
        {
            ["gpt-6-astra*"] = 2.5m,
            ["gpt-6.1-sol*"] = 2.5m,
            ["gpt-5.5*"] = 2.5m
        };
    }

    public static Collection<ModelPricingRule> CreatePricingRules()
    {
        return
        [
            CreateRule(
                "gpt-6-astra",
                "GPT-6 Astra",
                "openai",
                Flat(10m),
                Flat(1.00m),
                new TokenPriceTable(),
                Flat(60m),
                aliases: ["gpt-6-astra*"]),
            CreateRule(
                "gpt-6.1-sol",
                "GPT-6.1 Sol",
                "openai",
                Flat(5m),
                Flat(0.50m),
                new TokenPriceTable(),
                Flat(30m),
                aliases: ["gpt-6.1-sol*", "gpt-6-sol*"]),
            CreateRule(
                "gpt-6-luna",
                "GPT-6 Luna",
                "openai",
                Flat(0.50m),
                Flat(0.05m),
                new TokenPriceTable(),
                Flat(3m),
                aliases: ["gpt-6-luna*"]),
            CreateRule(
                "gpt-5.6-sol",
                "GPT-5.6 Sol",
                "openai",
                Flat(3m),
                Flat(0.30m),
                new TokenPriceTable(),
                Flat(18m),
                aliases: ["gpt-5.6-sol*"]),
            CreateRule(
                "gpt-5.5",
                "GPT-5.5",
                "openai",
                Tiered(OpenAiLongContextThresholdTokens, 5m, 10m),
                Tiered(OpenAiLongContextThresholdTokens, 0.50m, 1m),
                new TokenPriceTable(),
                Tiered(OpenAiLongContextThresholdTokens, 30m, 45m),
                aliases: ["gpt-5", "gpt-5.5*"]),
            CreateRule(
                "gpt-5.4",
                "GPT-5.4",
                "openai",
                Tiered(OpenAiLongContextThresholdTokens, 2.5m, 5m),
                Tiered(OpenAiLongContextThresholdTokens, 0.25m, 0.50m),
                new TokenPriceTable(),
                Tiered(OpenAiLongContextThresholdTokens, 15m, 22.5m),
                aliases: ["gpt-5.4*"]),
            CreateRule(
                "gpt-5.4-mini",
                "GPT-5.4 Mini",
                "openai",
                Flat(0.75m),
                Flat(0.075m),
                new TokenPriceTable(),
                Flat(4.5m),
                aliases: ["gpt-5.4-mini*"]),
            CreateRule(
                "codex-mini-latest",
                "Codex Mini Latest",
                "openai",
                Flat(0.50m),
                Flat(0.05m),
                new TokenPriceTable(),
                Flat(3m),
                aliases: ["codex-mini*"]),

            CreateRule("claude-opus-5-5", "Claude Opus 5.5", "claude", Flat(4m), Flat(0.20m), Flat(5m), Flat(20m), aliases: ["claude-opus-5.5", "opus-5-5", "opus-5.5"]),
            CreateRule("claude-sonnet-5-5", "Claude Sonnet 5.5", "claude", Flat(2m), Flat(0.10m), Flat(2.5m), Flat(10m), aliases: ["claude-sonnet-5.5", "sonnet-5-5", "sonnet-5.5"]),
            CreateRule("claude-haiku-5-5", "Claude Haiku 5.5", "claude", Flat(0.10m), Flat(0.01m), Flat(0.125m), Flat(0.50m), aliases: ["claude-haiku-5.5", "haiku-5-5", "haiku-5.5"]),
            CreateRule("claude-fable-5-1", "Claude Fable 5.1", "claude", Flat(10m), Flat(0.25m), Flat(12.5m), Flat(50m), aliases: ["claude-fable-5.1"]),
            CreateRule("claude-opus-4-7", "Claude Opus 4.7", "claude", Flat(5m), Flat(0.50m), Flat(6.25m), Flat(25m), aliases: ["claude-opus-4.7"]),
            CreateRule("claude-opus-4-6", "Claude Opus 4.6", "claude", Flat(5m), Flat(0.50m), Flat(6.25m), Flat(25m), aliases: ["claude-opus-4.6"]),
            CreateRule("claude-opus-4-5", "Claude Opus 4.5", "claude", Flat(5m), Flat(0.50m), Flat(6.25m), Flat(25m), aliases: ["claude-opus-4.5", "claude-opus-4-5-20251101"]),
            CreateRule("claude-sonnet-4-6", "Claude Sonnet 4.6", "claude", Flat(3m), Flat(0.30m), Flat(3.75m), Flat(15m), aliases: ["claude-sonnet-4.6"]),
            CreateRule("claude-sonnet-4-5", "Claude Sonnet 4.5", "claude", Flat(3m), Flat(0.30m), Flat(3.75m), Flat(15m), aliases: ["claude-sonnet-4.5", "claude-sonnet-4-5-20250929"]),
            CreateRule("claude-3-7-sonnet", "Claude Sonnet 3.7", "claude", Flat(3m), Flat(0.30m), Flat(3.75m), Flat(15m), aliases: ["claude-3.7-sonnet", "claude-3-7-sonnet-20250219", "claude-3.7-sonnet-20250219"]),
            CreateRule("claude-3-5-sonnet", "Claude Sonnet 3.5", "claude", Flat(3m), Flat(0.30m), Flat(3.75m), Flat(15m), aliases: ["claude-3.5-sonnet", "claude-3-5-sonnet-20241022", "claude-3-5-sonnet-20240620"]),
            CreateRule("claude-haiku-4-5", "Claude Haiku 4.5", "claude", Flat(1m), Flat(0.10m), Flat(1.25m), Flat(5m), aliases: ["claude-haiku-4.5", "claude-haiku-4-5-20251001"]),
            CreateRule("claude-3-5-haiku", "Claude Haiku 3.5", "claude", Flat(0.8m), Flat(0.08m), Flat(1m), Flat(4m), aliases: ["claude-3.5-haiku", "claude-3-5-haiku-20241022"]),

            CreateRule(
                "deepseek-v4.1-flash",
                "DeepSeek V4.1 Flash",
                "deepseek",
                Flat(0.07m),
                Flat(0.0014m),
                new TokenPriceTable(),
                Flat(0.14m),
                aliases: ["deepseek-flash", "deepseek-v4.1-flash*"]),
            CreateRule(
                "deepseek-v4.1-pro",
                "DeepSeek V4.1 Pro",
                "deepseek",
                Flat(0.25m),
                Flat(0.002m),
                new TokenPriceTable(),
                Flat(0.50m),
                aliases: ["deepseek-v4.1-pro*"]),
            CreateRule(
                "deepseek-v4-flash",
                "DeepSeek V4 Flash",
                "deepseek",
                Flat(0.14m),
                Flat(0.0028m),
                new TokenPriceTable(),
                Flat(0.28m),
                aliases: ["deepseek-chat", "deepseek-reasoner", "deepseek-v4-flash*"]),
            CreateRule(
                "deepseek-v4-pro",
                "DeepSeek V4 Pro",
                "deepseek",
                Flat(0.435m),
                Flat(0.003625m),
                new TokenPriceTable(),
                Flat(0.87m),
                aliases: ["deepseek-v4-pro*"]),

            CreateRule(
                "qwen3-coder-plus",
                "Qwen3 Coder Plus",
                "qwen",
                Flat(0.50m),
                Flat(0.10m),
                new TokenPriceTable(),
                Flat(1.50m),
                aliases: ["qwen3-coder*"]),
            CreateRule(
                "qwen3-max",
                "Qwen3 Max",
                "qwen",
                Flat(1.50m),
                Flat(0.30m),
                new TokenPriceTable(),
                Flat(4.50m),
                aliases: ["qwen3-max*"]),
            CreateRule(
                "qwen3-plus",
                "Qwen3 Plus",
                "qwen",
                Flat(0.20m),
                Flat(0.04m),
                new TokenPriceTable(),
                Flat(0.60m),
                aliases: ["qwen3-plus*", "qwen-plus*"]),

            CreateRule(
                "glm-5-plus",
                "GLM-5 Plus",
                "zhipu",
                Flat(1.00m),
                Flat(0.20m),
                new TokenPriceTable(),
                Flat(3.00m),
                aliases: ["glm-5*"]),
            CreateRule(
                "glm-5-flash",
                "GLM-5 Flash",
                "zhipu",
                Flat(0.05m),
                Flat(0.01m),
                new TokenPriceTable(),
                Flat(0.15m),
                aliases: ["glm-5-flash*"]),
            CreateRule(
                "glm-4-plus",
                "GLM-4 Plus",
                "zhipu",
                Flat(0.50m),
                Flat(0.10m),
                new TokenPriceTable(),
                Flat(1.50m),
                aliases: ["glm-4-plus*"]),

            CreateRule(
                "kimi-k2.5",
                "Kimi K2.5",
                "moonshot",
                Flat(0.80m),
                Flat(0.15m),
                new TokenPriceTable(),
                Flat(2.50m),
                aliases: ["kimi-k2.5*"]),
            CreateRule(
                "kimi-k2",
                "Kimi K2",
                "moonshot",
                Flat(0.50m),
                Flat(0.10m),
                new TokenPriceTable(),
                Flat(1.50m),
                aliases: ["kimi-k2*"]),
            CreateRule(
                "moonshot-v1-128k",
                "Moonshot V1 128K",
                "moonshot",
                Flat(0.80m),
                Flat(0.15m),
                new TokenPriceTable(),
                Flat(2.50m),
                aliases: ["moonshot-v1*"]),

            CreateRule(
                "doubao-1.5-pro",
                "Doubao 1.5 Pro",
                "doubao",
                Flat(0.50m),
                Flat(0.10m),
                new TokenPriceTable(),
                Flat(1.50m),
                aliases: ["doubao-1.5-pro*"]),
            CreateRule(
                "doubao-1.5-lite",
                "Doubao 1.5 Lite",
                "doubao",
                Flat(0.10m),
                Flat(0.02m),
                new TokenPriceTable(),
                Flat(0.30m),
                aliases: ["doubao-1.5-lite*"]),
            CreateRule(
                "doubao-seed-1.5",
                "Doubao Seed 1.5",
                "doubao",
                Flat(0.40m),
                Flat(0.08m),
                new TokenPriceTable(),
                Flat(1.20m),
                aliases: ["doubao-seed-1.5*"]),

            CreateRule(
                "mimo-v2.5-pro",
                "MiMo V2.5 Pro",
                "xiaomi",
                Tiered(XiaomiLongContextThresholdTokens, 1.00m, 2.00m),
                Tiered(XiaomiLongContextThresholdTokens, 0.20m, 0.40m),
                new TokenPriceTable(),
                Tiered(XiaomiLongContextThresholdTokens, 3.00m, 6.00m),
                aliases: ["mimo-v2-pro"]),
            CreateRule(
                "mimo-v2.5",
                "MiMo V2.5",
                "xiaomi",
                Tiered(XiaomiLongContextThresholdTokens, 0.40m, 0.80m),
                Tiered(XiaomiLongContextThresholdTokens, 0.08m, 0.16m),
                new TokenPriceTable(),
                Tiered(XiaomiLongContextThresholdTokens, 2.00m, 4.00m)),
            CreateRule(
                "mimo-v2-omni",
                "MiMo V2 Omni",
                "xiaomi",
                Flat(0.40m),
                Flat(0.08m),
                new TokenPriceTable(),
                Flat(2.00m)),
            CreateRule(
                "mimo-v2-flash",
                "MiMo V2 Flash",
                "xiaomi",
                Flat(0.10m),
                Flat(0.01m),
                new TokenPriceTable(),
                Flat(0.30m))
        ];
    }

    private static ProviderTemplateModel OpenAiResponsesRoute(
        string id,
        string displayName,
        string? upstreamModel = null,
        string? serviceTier = null,
        bool fastMode = false)
    {
        return new ProviderTemplateModel
        {
            Id = id,
            DisplayName = displayName,
            Protocol = ProviderProtocol.OpenAiResponses,
            UpstreamModel = upstreamModel,
            ServiceTier = serviceTier,
            FastMode = fastMode
        };
    }

    private static ProviderTemplateModel OpenAiChatRoute(
        string id,
        string displayName,
        string? upstreamModel = null,
        string? serviceTier = null,
        bool fastMode = false)
    {
        return new ProviderTemplateModel
        {
            Id = id,
            DisplayName = displayName,
            Protocol = ProviderProtocol.OpenAiChat,
            UpstreamModel = upstreamModel,
            ServiceTier = serviceTier,
            FastMode = fastMode
        };
    }

    private static ProviderTemplateModel AnthropicRoute(
        string id,
        string displayName,
        string? upstreamModel = null)
    {
        return new ProviderTemplateModel
        {
            Id = id,
            DisplayName = displayName,
            Protocol = ProviderProtocol.AnthropicMessages,
            UpstreamModel = upstreamModel
        };
    }

    private static ModelPricingRule CreateRule(
        string id,
        string displayName,
        string iconSlug,
        TokenPriceTable input,
        TokenPriceTable cachedInput,
        TokenPriceTable cacheCreationInput,
        TokenPriceTable output,
        IEnumerable<string>? aliases = null)
    {
        var rule = new ModelPricingRule
        {
            Id = id,
            DisplayName = displayName,
            IconSlug = iconSlug,
            Input = input,
            CachedInput = cachedInput,
            CacheCreationInput = cacheCreationInput,
            Output = output
        };

        if (aliases is not null)
        {
            foreach (var alias in aliases)
                rule.Aliases.Add(alias);
        }

        return rule;
    }

    private static TokenPriceTable Flat(decimal price)
    {
        var table = new TokenPriceTable();
        table.Tiers.Add(new PricingTier { UpToTokens = null, PricePerUnit = price });
        return table;
    }

    private static TokenPriceTable Tiered(long threshold, decimal firstPrice, decimal overflowPrice)
    {
        var table = new TokenPriceTable();
        table.Tiers.Add(new PricingTier
        {
            UpToTokens = threshold,
            PricePerUnit = firstPrice
        });
        table.Tiers.Add(new PricingTier
        {
            UpToTokens = null,
            PricePerUnit = overflowPrice
        });
        return table;
    }
}
