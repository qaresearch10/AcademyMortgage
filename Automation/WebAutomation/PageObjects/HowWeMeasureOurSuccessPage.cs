using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.PageObjects
{
    public static class HowWeMeasureOurSuccessPage
    {
        public static class Elements
        {
            public static By
                PageBannerTitle = By.XPath("//h1[@class=' page-banner-title']")
            ;
        }
    }
}
