using BDD.SpecFlow.PageObjects.Common;
using BDD.SpecFlow.PageObjects.Controls;
using BDD.SpecFlow.PageObjects.Extensions;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Pages
{
	public class MainPage : ContextBase
	{
		public MainPage(IWebDriver webDriver)
			: base(webDriver)
		{
		}

		public SearchBox SearchBox => GetControl<SearchBox>(_driver.WaitFindElement(By.Id("searchbox")));

		public AuthenticationPage GoToMyAccount()
		{
			var element = _driver.WaitFindElement(By.CssSelector("a[title='Manage my customer account']"));
			element.Click();
			return GetContext<AuthenticationPage>();
		}
	}
}
