using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAutomation.PageObjects
{
    public static class Menu
    {
        public static class Elements
        {
            public static By
                AboutUsLink = By.LinkText("About Us"),
                WhoWeAreLink = By.LinkText("Who We Are"),
                WhatSetsUsApartLink = By.LinkText("What Sets Us Apart"),
                HowWeMeasureSuccessLink = By.LinkText("How We Measure Success"),
                WhereWeBeganLink = By.LinkText("Where We Began"),
                ContactUsLink = By.LinkText("Contact Us")
            ;
        }
    }
}
