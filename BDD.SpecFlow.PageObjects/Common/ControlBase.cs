using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Common
{
	public class ControlBase : ContextBase
	{
		protected IWebElement _root;

		public ControlBase(IWebDriver webDriver, IWebElement root)
			: base(webDriver)
		{
			_root = root;
		}
	}
}
