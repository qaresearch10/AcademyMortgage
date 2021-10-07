using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAutomation.Utilities
{
    public static class Drivers
    {
		#region Variables
		private const string DownloadFolderPath = @"C:\Users\Downloads";
		#endregion
		static Drivers()
        {

        }

		/// <summary>
		/// Creates a new instance of Chrome Driver 		
		/// </summary>
		/// <param name="options">Optional Parameter for ChromeOptions <seealso cref="ChromeOptions"/></param>
		/// <returns></returns>
		public static IWebDriver ChromeDriver(DriverOptions options = null)
		{
			ChromeOptions opts;
			if ((options as ChromeOptions) != null)
			{
				opts = (ChromeOptions)options;
			}
			else
			{
				opts = new ChromeOptions();
				opts.AddUserProfilePreference("credentials_enable_service", false);
				opts.AddUserProfilePreference("profile.password_manager_enabled", false);
				opts.AddArguments("--disable-extensions");
				opts.AddArguments("--start-maximized");
				opts.AddUserProfilePreference("profile.default_content_settings.popups", 0);
				opts.AddUserProfilePreference("download.default_directory", DownloadFolderPath);
				opts.AddUserProfilePreference("download.prompt_for_download", false);
				
			}			
			ChromeDriverService service = ChromeDriverService.CreateDefaultService();
			return new ChromeDriver(service, opts);
		}

		/// <summary>
		/// Creates a new instance of Chrome Mobile Emulator Driver 		
		/// </summary>
		/// <param name="options">Optional Parameter for ChromeOptions <seealso cref="ChromeOptions"/></param>
		/// <returns></returns>
		public static IWebDriver ChromeMobileEmulatorDriver(DriverOptions options = null)
		{
			ChromeOptions opts;
			if ((options as ChromeOptions) != null)
			{
				opts = (ChromeOptions)options;
			}
			else
			{
				opts = new ChromeOptions();
				opts.AddUserProfilePreference("credentials_enable_service", false);
				opts.AddUserProfilePreference("profile.password_manager_enabled", false);
				opts.AddArguments("--disable-extensions");
				opts.AddArguments("--start-maximized");
				opts.AddUserProfilePreference("profile.default_content_settings.popups", 0);
				opts.AddUserProfilePreference("download.default_directory", DownloadFolderPath);
				opts.AddUserProfilePreference("download.prompt_for_download", false);
				opts.EnableMobileEmulation("iPhone X");
				opts.AddArguments("use-fake-ui-for-media-stream");				
			}
			
			ChromeDriverService service = ChromeDriverService.CreateDefaultService();
			return new ChromeDriver(service, opts);
		}		

		/// <summary>
		/// Supported Browser Types		
		/// </summary>
		public enum Browser
		{
			/// <summary>
			/// ChromeDriver
			/// </summary>
			Chrome = 1,
			
			/// <summary>
			/// MobileEmulatorDriver
			/// </summary>
			MobileEmulator = 2
		};

		/// <summary>
		/// Creates a new Browser instance of the given browser name and optional DriverOptions. If BrowserName is not recognized, default is chrome.
		/// </summary>
		/// <param name="BrowserName">name of the browser like chrome, firefox, ie, edge</param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static IWebDriver GetBrowser(string BrowserName, DriverOptions options = null)
		{
			var ret = Browser.Chrome;
			try
			{
				ret = (Browser)Enum.Parse(typeof(Browser), BrowserName);
			}
			catch (Exception)
			{
				// is defaulted to Chrome				
			}
			return GetBrowser(ret, options);
		}

		/// <summary>
		/// Creates a new Browser instance of the provided browser type and optional DriverOptions
		/// </summary>
		/// <param name="browser"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static IWebDriver GetBrowser(Browser browser, DriverOptions options = null)
		{
			switch (browser)
			{
				case Browser.Chrome:
					return ChromeDriver(options);
				case Browser.MobileEmulator:
					return ChromeMobileEmulatorDriver(options);

				default:
					return ChromeDriver();
			}
		}
	}
}
