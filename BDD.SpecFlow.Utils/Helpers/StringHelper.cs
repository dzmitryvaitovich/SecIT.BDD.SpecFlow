using System.Text.RegularExpressions;

namespace BDD.SpecFlow.Utils.Helpers
{
	public static class StringHelper
	{
		public static string RemoveTabsAndWhitespaces(string input)
		{
			return Regex.Replace(input, @"\s+", string.Empty);
		}

		//public static string GenerateRandomEmail()
		//{

		//}
	}
}
