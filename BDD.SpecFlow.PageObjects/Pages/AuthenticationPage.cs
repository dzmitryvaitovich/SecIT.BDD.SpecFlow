using BDD.SpecFlow.PageObjects.Common;
using BDD.SpecFlow.PageObjects.Controls;
using BDD.SpecFlow.PageObjects.Extensions;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Pages
{
	public class AuthenticationPage : ContextBase
	{
		public AuthenticationPage(IWebDriver webDriver)
			: base(webDriver)
		{
		}

		public Textbox CreateAnAccount_EmailAddress => GetControl<Textbox>(_driver.WaitFindElement(By.CssSelector("input#email_create")));

		private IWebElement CreateAnAccountButton => _driver.WaitFindElement(By.Id("SubmitCreate"));

		public void CreateAnAccount()
		{
			CreateAnAccountButton.Click();
		}
	}
}
