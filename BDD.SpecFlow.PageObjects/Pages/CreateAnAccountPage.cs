using BDD.SpecFlow.PageObjects.Common;
using BDD.SpecFlow.PageObjects.Controls;
using BDD.SpecFlow.PageObjects.Extensions;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Pages
{
	public class CreateAnAccountPage : ContextBase
	{
		public CreateAnAccountPage(IWebDriver webDriver)
			: base(webDriver)
		{
		}

		public RadioButtonGroup Title => GetControl<RadioButtonGroup>(_driver.WaitFindElement(By.CssSelector("div.account_creation>div.clearfix")));

		public Textbox FirstName => GetControl<Textbox>(_driver.WaitFindElement(By.Id("customer_firstname")));

		public Textbox LastName => GetControl<Textbox>(_driver.WaitFindElement(By.Id("customer_lastname")));

		public Textbox Password => GetControl<Textbox>(_driver.WaitFindElement(By.Id("passwd")));

		private IWebElement SubmitButton => _driver.WaitFindElement(By.Id("submitAccount"));

		public void Register()
		{
			SubmitButton.Click();
		}

		public void WaitPageIsLoaded()
		{
			_driver.WaitTextEquals(By.CssSelector("div#noSlide>h1.page-heading"), "CREATE AN ACCOUNT");
		}

		public bool AreExceptionsShown()
		{
			return _driver.FindElements(By.CssSelector("p.inline-infos")).Count > 0;
		}
	}
}
