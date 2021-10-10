using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Selenium.WebDriver.WaitExtensions;

namespace WebAutomation.Utilities
{
    public static class SeleniumUtils
    {
        /// <summary>
		/// Reference of the active IWebDriver instance
		/// </summary>
		public static IWebDriver driver;

        static SeleniumUtils()
        {

        }

        /// <summary>
		/// Creates a new IWebDriver instance
		/// </summary>
		/// <returns>
		/// Returns an instance of IWebDriver
		/// </returns>
        public static IWebDriver GetNewDriver()
        {
            driver = Drivers.GetBrowser("Chrome");
            try
            {
                driver.Manage().Window.Maximize();
            }
            catch
            {
                // if headless is used then Maximize will throw an error
            }
            return driver;
        }
        public static IWebDriver SetNewDriver()
        {
            driver = GetNewDriver();

            return driver;
        }

        public static void GoToURL(string URL)
        {
            SeleniumUtils.driver.Navigate().GoToUrl(URL);
        }

        public class Wait
        {
            /// <summary>
			/// Waits until provided ByLocator is visible
			/// </summary>
			/// <param name="bylocator">By locator for element to wait for</param>
			/// <param name="timeout">Max amount of time in seconds to wait for condition to be met</param>
			/// <returns>true if condition is met, false is condition is not met</returns>
			public static bool UntilElementVisible(By bylocator, int timeout = 25)
            {
                bool conditionMet = false;
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementIsVisible(bylocator));
                    conditionMet = true;
                }
                catch (Exception e)
                {                    
                    conditionMet = false;
                }
                return conditionMet;
            }
        }

        public class Action
        {
            /// <summary>
			/// Performs a click on an IWebElement. 
			/// </summary>
			/// <param name="element">IWebElement instance to perform action on</param>
			/// <param name="timeout">Optional Paramater - timeout to allow the IWebElement to be actionable</param>
			public static void Click(IWebElement element, int timeout = 25)
            {
                try
                {
                    Actions actions = new Actions(driver);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));
                    actions.MoveToElement(element).Build().Perform();
                    element.Click();
                }
                catch(Exception e)
                {
                    //todo
                }                                  
            }

            /// <summary>
			/// Performs a click on an By Element. 
			/// </summary>
			/// <param name="element">IWebElement instance to perform action on</param>
			/// <param name="timeout">Optional Paramater - timeout to allow the IWebElement to be actionable</param>
			public static void Click(By bylocator, int timeout = 25)
            {
                try
                {
                    Actions actions = new Actions(driver);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementToBeClickable(bylocator));
                    IWebElement element = driver.FindElement(bylocator);
                    actions.MoveToElement(element).Build().Perform();
                    element.Click();
                }
                catch (Exception e)
                {
                    //todo
                }
            }
        }
    }
}
