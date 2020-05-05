using BDD.SpecFlow.Utils.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace BDD.SpecFlow.PageObjects.Extensions
{
	public static class WebDriverExtensions
	{
		public static bool DoesElementExist(this IWebDriver webDriver, By by)
		{
			try
			{
				var element = webDriver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}

		public static WebDriverWait Wait(this IWebDriver webDriver, int numberOfSeconds)
		{
			return new WebDriverWait(webDriver, TimeSpan.FromSeconds(numberOfSeconds));
		}

		public static IWebElement WaitFindElement(this IWebDriver webDriver, By by)
		{
			return webDriver.WaitFindElement(by, ConfigurationHelper.DefaultTimeout);
		}

		public static IWebElement WaitFindElement(this IWebDriver webDriver, By by, int numberOfSeconds)
		{
			return webDriver.Wait(numberOfSeconds).Until(d => d.FindElement(by));
		}

		public static void WaitTextEquals(this IWebDriver webDriver, By by, string text)
		{
			WaitTextEquals(webDriver, by, text, ConfigurationHelper.DefaultTimeout);
		}

		public static void WaitTextEquals(this IWebDriver webDriver, By by, string text, int numberOfSeconds)
		{
			webDriver.Wait(numberOfSeconds).Until(d => d.DoesElementExist(by) && d.FindElement(by).Text.Equals(text));
		}

		public static object ExecuteJavaScript(this IWebDriver webDriver, string js, params object[] args)
		{
			return ((IJavaScriptExecutor)webDriver).ExecuteScript(js, args);
		}

		public static void PerformActions(this IWebDriver webDriver, Action<Actions, IWebDriver> action)
		{
			var builder = new Actions(webDriver);
			action(builder, webDriver);
			builder.Perform();
		}
	}
}