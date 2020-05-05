using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BDD.SpecFlow.PageObjects.Browser
{
	public static class BrowserFactory
	{
		public static IWebDriver GetWebDriver(string browserType)
		{
			switch (browserType.ToLower())
			{
				case "chrome":
					var options = new ChromeOptions();
					options.AddArgument("--start-maximized");
					return new ChromeDriver(options);
				default:
					throw new NotSupportedException();
			}
		}
	}
}
