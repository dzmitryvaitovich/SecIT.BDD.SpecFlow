using BDD.SpecFlow.PageObjects.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BDD.SpecFlow.PageObjects.Pages
{
	public class SearchResultPage : MainPage
	{
		public SearchResultPage(IWebDriver webDriver)
			: base(webDriver)
		{
		}

		private IWebElement ProductContainer => _driver.WaitFindElement(By.CssSelector("div.product-container"));

		private IWebElement HeaderContainer => _driver.WaitFindElement(By.CssSelector("span.heading-counter"));

		public IList<string> GetSearchResults()
		{
			var results = new List<string>();
			if (!HeaderContainer.Text.StartsWith("0"))
			{
				results = ProductContainer.FindElements(By.CssSelector("a.product-name")).Select(e => e.Text).ToList();
			}

			return results;
		}
	}
}
