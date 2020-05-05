using BDD.SpecFlow.PageObjects.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.SpecFlow.PageObjects.Controls
{
	public class RadioButtonGroup : ControlBase
	{
		public RadioButtonGroup(IWebDriver webDriver, IWebElement root)
			: base(webDriver, root)
		{
		}

		public List<RadioButtonItem> Items
		{
			get
			{
				var elements = _root.FindElements(By.CssSelector("div.radio-inline"));
				return elements.Select(e => GetControl<RadioButtonItem>(e)).ToList();
			}
		}

		public void Select(string value)
		{
			var item = Items.Single(i => i.Label.Equals(value));
			item.Select();
		}
	}
}
