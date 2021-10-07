using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.PageObjects
{
    public static class WhoWeArePage
    {
        public static class Elements
        {
            public static By
                MainImage = By.XPath("//img[@class='image-container']"),
                CardOne = By.Id("Main_C031_Col00"),
                CardTwo = By.Id("Main_C031_Col01"),
                CardThree = By.Id("Main_C031_Col02"),
                CardFour = By.Id("Main_C031_Col03"),
                CardFive = By.Id("Main_C031_Col04")
            ;
        }
    }
}
