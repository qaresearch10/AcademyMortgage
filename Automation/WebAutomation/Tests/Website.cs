using NUnit.Framework;
using OpenQA.Selenium;
using WebAutomation.Utilities;
using WebAutomation.TestManagement;
using WebAutomation.PageObjects;

namespace WebAutomation
{
    public class Tests : TestBaseClass
    {        

        [Test]
        public void VerifyWhoWeArePageLoads()
        {
            #region Arrange
            //Navigate to the home page
            SeleniumUtils.GoToURL(SiteUrl);
            #endregion

            #region Act
            //Navigate to the WhoWeAre page
            Menu.ClickAboutUs();
            SeleniumUtils.Action.Click(Menu.Elements.WhoWeAreLink);
            bool isImageVisible = SeleniumUtils.Wait.UntilElementVisible(WhoWeArePage.Elements.MainImage);
            string actualURL = SeleniumUtils.driver.Url;
            #endregion

            #region Assert
            Assert.Multiple(() => 
            {
                Assert.True(isImageVisible);
                Assert.AreEqual("https://academymortgage.com/about-us/who-we-are", actualURL, "URL address is not correct");
            });
            #endregion            
        }

        [Test]
        public void VerifyWhatSetsUsApartPageLoads()
        {
            #region Arrange
            //Navigate to the home page
            SeleniumUtils.GoToURL(SiteUrl);
            #endregion

            #region Act
            //Navigate to the WhatSetsUsApartPage page
            Menu.ClickAboutUs();
            SeleniumUtils.Action.Click(Menu.Elements.WhatSetsUsApartLink);
            bool isBannerTitleVisible = SeleniumUtils.Wait.UntilElementVisible(WhatSetsUsApartPage.Elements.PageBannerTitle);
            IWebElement element = SeleniumUtils.driver.FindElement(WhatSetsUsApartPage.Elements.PageBannerTitle);
            string bannerText = element.Text;
            #endregion

            #region Assert     
            Assert.Multiple(() =>
            {
                Assert.AreEqual("What Sets Us Apart", bannerText, "Banner text is not correct");
                Assert.True(isBannerTitleVisible, "Page banner title is not visible");
            });                    
            #endregion

        }

        [Test]
        public void VerifyHowWeMeasureOurSuccessPageLoads()
        {
            #region Arrange
            //Navigate to the home page
            SeleniumUtils.GoToURL(SiteUrl);
            #endregion

            #region Act
            //Navigate to the HowWeMeasureOurSuccess page
            Menu.ClickAboutUs();
            SeleniumUtils.Action.Click(Menu.Elements.HowWeMeasureSuccessLink);
            bool isBannerTitleVisible = SeleniumUtils.Wait.UntilElementVisible(HowWeMeasureOurSuccessPage.Elements.PageBannerTitle);
            IWebElement element = SeleniumUtils.driver.FindElement(HowWeMeasureOurSuccessPage.Elements.PageBannerTitle);
            string bannerText = element.Text;
            #endregion

            #region Assert     
            Assert.Multiple(() =>
            {
                Assert.AreEqual("How We Measure Success", bannerText, "Banner text is not correct");
                Assert.True(isBannerTitleVisible, "Page banner title is not visible");
            });
            #endregion

        }
    }
}