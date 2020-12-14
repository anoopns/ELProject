using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Driverutilities
{
    public class Wait
    {
        private readonly WebDriverWait _wait;

        public Wait(int time)
        {
            _wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(time))
            {
                PollingInterval = TimeSpan.FromMilliseconds(1000)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
            );
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        public Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver)
            {
                return element.Displayed;
            }

            return condition;
        }
    }
}
