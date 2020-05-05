using System.Configuration;

namespace BDD.SpecFlow.Utils.Helpers
{
	public class ConfigurationHelper
	{
		public static string ApplicationUrl
		{
			get { return ConfigurationManager.AppSettings["applicationUrl"]; }
		}

		public static string Browser
		{
			get { return ConfigurationManager.AppSettings["browser"]; }
		}

		public static int DefaultTimeout
		{
			get { return int.Parse(ConfigurationManager.AppSettings["defaultTimeout"]); }
		}
	}
}
