﻿namespace AdvancedRuleMatcher.Impl
{
    public record FourFilterRule(
        int RuleId,
        int Priority,
        string Filter1, string Filter2, string Filter3, string Filter4,
        int? OutputValue)
        : BaseRule(RuleId, OutputValue)
    {
        public const string AnyFilter = "<ANY>";
    }
}