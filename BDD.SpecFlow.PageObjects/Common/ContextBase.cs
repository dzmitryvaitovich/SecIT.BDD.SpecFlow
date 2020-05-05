using OpenQA.Selenium;
using System;

namespace BDD.SpecFlow.PageObjects.Common
{
	public class ContextBase
	{
		protected IWebDriver _driver;

		public ContextBase(IWebDriver webDriver)
		{
			_driver = webDriver;
		}

		public T GetContext<T>() where T : ContextBase
		{
			return GetContext<T>(_driver);
		}

		protected T GetContext<T>(IWebDriver webDriver) where T : ContextBase
		{
			var args = new object[] { webDriver };
			var content = Activator.CreateInstance(typeof(T), args) as T;
			return content;
		}

		protected T GetControl<T>(IWebElement webElement) where T : ControlBase
		{
			return GetControl<T>(_driver, webElement);
		}

		protected T GetControl<T>(IWebDriver webDriver, IWebElement webElement) where T : ControlBase
		{
			var args = new object[] { webDriver, webElement };
			var control = Activator.CreateInstance(typeof(T), args) as T;
			return control;
		}
	}
}