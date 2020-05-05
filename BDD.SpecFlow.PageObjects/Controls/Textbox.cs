using BDD.SpecFlow.PageObjects.Common;
using BDD.SpecFlow.PageObjects.Extensions;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Controls
{
	public class Textbox : ControlBase
	{
		public Textbox(IWebDriver webDriver, IWebElement root)
			: base(webDriver, root)
		{
		}

		public string Value
		{
			get
			{
				return Input.GetAttribute("value");
			}
			set
			{
				Input.Clear();
				Input.SendKeys(value);
			}
		}

		private IWebElement Input => _root.TagName.Equals("input")
					? _root
					: _root.WaitFindElement(By.TagName("input"));

		public void EnterValue(string value)
		{
			Value = value + Keys.Enter;
		}
	}
}
