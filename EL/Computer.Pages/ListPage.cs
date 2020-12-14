using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Framework.Driverutilities;

namespace EL.Computer.Pages
{
    public class ListPage
    {
        private IWebDriver _driver;
        public ListPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _addButton => _driver.FindElement(By.CssSelector("#add"));
        private IWebElement _searchButton => _driver.FindElement(By.CssSelector("#searchsubmit"));
        private IWebElement _searchBox => _driver.FindElement(By.CssSelector("#searchbox"));
        private IList<IWebElement> _colHeadings => _driver.FindElements(By.CssSelector(".computers > thead > tr > th"));
        private IWebElement _nameHeading => _colHeadings.First(x => x.FindElement(By.CssSelector("a")).Text.Equals("Computer name"));
        private IWebElement _introducedDate => _colHeadings.First(x => x.FindElement(By.CssSelector("a")).Text.Equals("Introduced"));
        private IWebElement _discontinuedDate => _colHeadings.First(x => x.FindElement(By.CssSelector("a")).Text.Equals("Discontinued"));
        private IWebElement _comapyHeading => _colHeadings.First(x => x.FindElement(By.CssSelector("a")).Text.Equals("Company"));
        private IWebElement _mainHeading => _driver.FindElement(By.CssSelector("#main > h1"));
        private IWebElement _seccussMessage => _driver.FindElement(By.CssSelector(".alert-message"));
        private IList<IWebElement> _productRows => _driver.FindElements(By.CssSelector(".computers > tbody > tr"));

        public void EnterSearchKeyWord(string keyWord)
        {
            _searchBox.SendKeys(keyWord);
        }

        public void ClickSearchButton()
        {
            _searchButton.Click();
        }

        public void ClickAddButton()
        {
            _addButton.Click();
        }

        public int GetComputerCount()
        {
            var text = _mainHeading.Text.Split(' ').First();
            return Int32.Parse(text);
        }
        
        public bool IsSuccessMessagePresent()
        {
            return Driver.Wait.Until(WaitConditions.ElementDisplayed(_seccussMessage));
        }

        public void ClickProduct()
        {
            _productRows.FirstOrDefault().FindElement(By.CssSelector("td > a")).Click();
        }
    }
}
