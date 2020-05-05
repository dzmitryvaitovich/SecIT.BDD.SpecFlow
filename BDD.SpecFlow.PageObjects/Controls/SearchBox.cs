using BDD.SpecFlow.PageObjects.Common;
using BDD.SpecFlow.PageObjects.Extensions;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Controls
{
	public class SearchBox : ControlBase
	{
		public SearchBox(IWebDriver webDriver, IWebElement root)
			: base(webDriver, root)
		{
		}

		public Textbox Textbox => GetControl<Textbox>(_driver, _root.WaitFindElement(By.Id("search_query_top")));

		public void SubmitSearch()
		{
			var submitSearchElement = _root.WaitFindElement(By.Id("submit_search"));
			submitSearchElement.Click();
		}
	}
}