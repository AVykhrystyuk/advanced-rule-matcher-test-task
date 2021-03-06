using AdvancedRuleMatcher.Tests.Common;
using System.Collections.Generic;
using Xunit;

namespace AdvancedRuleMatcher.Tests
{
    public class SampleDataIntegrationTests : IClassFixture<SampleDataIntegrationTests.EngineFixture>
    {
        private readonly ISearchEngine engine;

        public SampleDataIntegrationTests(EngineFixture fixture)
            => engine = fixture.Engine;

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestFindRule(FourFilterRuleMatchCriteria criteria, int expectedRuleId)
        {
            var rule = engine.MatchRule(criteria);

            Assert.Equal(expectedRuleId, rule?.RuleId);
        }

        public static IEnumerable<object[]> GetTestCases() => SampleDataMetadata.GetTestCases();

        /// <summary>
        /// Shared object instance across tests in a single class
        /// </summary>
        public class EngineFixture
        {
            public ISearchEngine Engine { get; } = SearchEngineFactory.Create(SampleDataMetadata.DataFile);
        }
    }
}
