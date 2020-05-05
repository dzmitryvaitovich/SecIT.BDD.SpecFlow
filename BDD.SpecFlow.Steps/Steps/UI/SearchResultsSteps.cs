using BDD.SpecFlow.PageObjects.Pages;
using BDD.SpecFlow.Tests.Steps.UI.Common;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDD.SpecFlow.Tests.Steps.UI
{
	[Binding]
	[Scope(Feature = "SearchResults")]
	public class SearchResultsSteps
	{
		private readonly UiContext _context;

		private MainPage MainPage => new MainPage(_context.Driver);

		private SearchResultPage SearchResultPage => new SearchResultPage(_context.Driver);

		public SearchResultsSteps(UiContext context)
		{
			_context = context;
		}

		[When(@"I search for (.*)")]
		public void WhenISearchForPrintedDress(string text)
		{
			MainPage.SearchBox.Textbox.EnterValue(text);
		}

		[Then(@"(\d+) items should be displayed on the Search Result page")]
		public void VerifySearchResultCount(int expectedCount)
		{
			SearchResultPage.GetSearchResults().Count.Should().Be(expectedCount);
		}
	}
}
