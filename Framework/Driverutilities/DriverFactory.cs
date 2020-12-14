using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Driverutilities
{
    public static class DriverFactory
    {
        public static string CURRENT_DIRECTORY = Path.GetFullPath(@"../../../../");
        public static IWebDriver Create(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new ChromeDriver(CURRENT_DIRECTORY + "/Framework/Drivers");
                default:
                    throw new ArgumentException("browser not found");
            }
        }
    }
}
