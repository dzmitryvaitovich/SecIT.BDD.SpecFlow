using BDD.SpecFlow.Utils.Helpers;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Extensions
{
	public static class WebElementExtensions
	{
		public static bool DoesElementExist(IWebElement element, By by)
		{
			try
			{
				element.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}

		public static IWebElement WaitFindElement(this IWebElement element, By by)
		{
			return WaitFindElement(element, by, ConfigurationHelper.DefaultTimeout);
		}

		public static IWebElement WaitFindElement(this IWebElement element, By by, int timeoutInSeconds)
		{
			var timeSpentInMs = 0;
			var intervalInMs = 50;
			var timeoutInMs = timeoutInSeconds * 1000;

			while(timeSpentInMs <= timeoutInMs)
			{
				try
				{
					return element.FindElement(by);
				}
				catch (NoSuchElementException)
				{
					timeSpentInMs += intervalInMs;
				}
			}

			throw new NoSuchElementException();
		}

		public static string GetClass(this IWebElement element)
		{
			return element.GetAttribute("class");
		}
	}
}
