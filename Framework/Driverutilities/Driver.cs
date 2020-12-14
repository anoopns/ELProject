using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Framework.Driverutilities
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _webDriver;

        [ThreadStatic]
        public static Wait Wait;

        public static void Init(string browser)
        {
            _webDriver = DriverFactory.Create(browser);
            Wait = new Wait(2000);
        }

        public static IWebDriver Current => _webDriver ?? throw new NullReferenceException("Driver not initialized");

        public static void Quit()
        {
            Current.Quit();
        }

        public static void Goto(string url)
        {
            Current.Navigate().GoToUrl(url);
        }

    }
}
