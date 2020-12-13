using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.pages
{
    class ListPage
    {
        private IWebDriver _driver;
        public ListPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement addButton => _driver.FindElement(By.CssSelector("#add"));


    }
}
