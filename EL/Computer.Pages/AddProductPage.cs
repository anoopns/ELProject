using Framework.Driverutilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EL.Computer.Pages
{
    public class AddProductPage 
    {
        private IWebDriver _driver;
        public AddProductPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _pageHeading => _driver.FindElement(By.CssSelector("#main > h1"));
        private IWebElement _computerName => _driver.FindElement(By.CssSelector("#name"));
        private IWebElement _introducedDate => _driver.FindElement(By.CssSelector("#introduced"));
        private IWebElement _discontinuedDate => _driver.FindElement(By.CssSelector("#discontinued"));
        private IWebElement _companyDropDown => _driver.FindElement(By.CssSelector("#company"));
        private IWebElement _nameErrorMessage => _driver.FindElement(By.CssSelector("#name + .help-inline"));
        private IWebElement _inValidDate1ErrorMessage => _driver.FindElement(By.CssSelector("#introduced + .help-inline"));
        private IWebElement _inValidDate2ErrorMessage => _driver.FindElement(By.CssSelector("#discontinued + .help-inline"));
        private IWebElement _createButton => _driver.FindElement(By.CssSelector(".actions > input"));
        private IWebElement _deleteButton => _driver.FindElement(By.CssSelector(".danger"));
        private IWebElement _cancelButton => _driver.FindElement(By.CssSelector(".actions > a"));


        public bool isPageLoaded()
        {
            return Driver.Wait.Until(WaitConditions.ElementDisplayed(_pageHeading));
        }
        public string GetPageHeading()
        {
            return _pageHeading.Text;
        }

        public void EnterName(string name)
        {
            _computerName.SendKeys(name);
        }

        public void EnterIntroducedDate(string date)
        {
            _introducedDate.SendKeys(date);
        }

        public void EnterDiscontinuedDate(string date)
        {
            _discontinuedDate.SendKeys(date);
        }

        public void SelectCompanyByText(string name)
        {
            var selectElem = new SelectElement(_companyDropDown);
            selectElem.SelectByText(name);
        }

        public bool CheckNameMissingMessage(string message)
        {
            if (Driver.Wait.Until(WaitConditions.ElementDisplayed(_nameErrorMessage)))
            {
                return _nameErrorMessage.Text.Equals(message) ? true : false;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIntroducedDateMissingMessage(string message)
        {
            if (Driver.Wait.Until(WaitConditions.ElementDisplayed(_inValidDate1ErrorMessage)))
            {
                return _inValidDate1ErrorMessage.Text.Equals(message) ? true : false;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDiscontinuedDateMissingMessage(string message)
        {
            if (Driver.Wait.Until(WaitConditions.ElementDisplayed(_inValidDate2ErrorMessage)))
            {
                return _inValidDate2ErrorMessage.Text.Equals(message) ? true : false;
            }
            else
            {
                return false;
            }
        }

        public void ClickCreate()
        {
            if (Driver.Wait.Until(WaitConditions.ElementDisplayed(_createButton)))
                _createButton.Click();
            else
                throw new NoSuchElementException();
        }

        public void ClickCancel()
        {
            if (Driver.Wait.Until(WaitConditions.ElementDisplayed(_cancelButton)))
                _cancelButton.Click();
            else
                throw new NoSuchElementException();
        }
        public void ClickDeleteButton()
        {
            if (Driver.Wait.Until(WaitConditions.ElementDisplayed(_deleteButton)))
                _deleteButton.Click();
            else
                throw new NoSuchElementException();
        }

    }
}
