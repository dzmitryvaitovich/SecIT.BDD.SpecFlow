using BDD.SpecFlow.PageObjects.Common;
using BDD.SpecFlow.PageObjects.Extensions;
using OpenQA.Selenium;

namespace BDD.SpecFlow.PageObjects.Controls
{
	public class RadioButtonItem : ControlBase
	{
		public RadioButtonItem(IWebDriver webDriver, IWebElement root)
			: base(webDriver, root)
		{
		}

		public string Label => _root.Text;

		public bool IsChecked => _root.WaitFindElement(By.TagName("span")).GetClass().ToLower().Equals("checked");

		private IWebElement Input => _root.WaitFindElement(By.CssSelector("input[type='radio']"));

		public void Select()
		{
			if (!IsChecked)
			{
				Input.Click();
			}
		}
	}
}
