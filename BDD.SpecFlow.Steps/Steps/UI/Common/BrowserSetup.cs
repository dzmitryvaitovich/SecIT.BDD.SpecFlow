using BDD.SpecFlow.PageObjects.Browser;
using BDD.SpecFlow.Tests.Steps.UI.Common;
using BDD.SpecFlow.Utils.Helpers;
using TechTalk.SpecFlow;

namespace BDD.SpecFlow.Tests.Steps.UI
{
	[Binding]
	[Scope(Tag = "UI")]
	public class BrowserSetup
	{
		private readonly UiContext _context;

		public BrowserSetup(UiContext context)
		{
			_context = context;
		}

		[BeforeScenario]
		public void ScenarioSetup()
		{
			var driver = BrowserFactory.GetWebDriver(ConfigurationHelper.Browser);
			_context.Driver = driver;
			driver.Navigate().GoToUrl(ConfigurationHelper.ApplicationUrl);
		}

		[AfterScenario]
		public void ScenarioCleanup()
		{
			_context.Driver.Quit();
		}
	}
}
