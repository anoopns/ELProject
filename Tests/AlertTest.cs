using Framework.Driverutilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EL.Tests
{
    class AlertTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Driver.Goto("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [Test]
        public void JSAlertTest()
        {
            //manual test name: User can click on JS alert button
            Alert.ClickAlert("Alert");
            var alert = Alert.SwitchToAlert();
            Assert.AreEqual("I am a JS Alert", alert.Text);
            alert.Accept();
            Assert.AreEqual("You successfuly clicked an alert", Alert.getResult());

        }

        [Test]
        public void JSConfirmTest()
        {
            //manual test name: User can click on JS Confirm button, validating Alert Accept
            Alert.ClickAlert("Confirm");
            var alert = Alert.SwitchToAlert();
            Assert.AreEqual("I am a JS Confirm", alert.Text);
            alert.Accept();
            Assert.AreEqual("You clicked: Ok", Alert.getResult());
        }

        [Test]
        public void JSConfirmCancelTest()
        {
            //manual test name: User can click on JS Confirm button, validating Alert Cancel
            Alert.ClickAlert("Confirm");
            var alert = Alert.SwitchToAlert();
            Assert.AreEqual("I am a JS Confirm", alert.Text);
            alert.Dismiss();
            Assert.AreEqual("You clicked: Cancel", Alert.getResult());
        }

        [Test]
        public void JSPromptTest()
        {
            //manual test name: User can click on JS Prompt button
            var alertMessage = "Test";
            Alert.ClickAlert("Prompt");
            var alert = Alert.SwitchToAlert();
            Assert.AreEqual("I am a JS prompt", alert.Text);
            Alert.EnterAlertText("Test", alert);
            alert.Accept();
            Assert.AreEqual($"You entered: {alertMessage}", Alert.getResult());
        }

        [Test]
        public void JSPromptCancelTest()
        {
            //manual test name: User can click on JS Prompt button, validating Cancel
            Alert.ClickAlert("Prompt");
            var alert = Alert.SwitchToAlert();
            Assert.AreEqual("I am a JS prompt", alert.Text);
            alert.Dismiss();
            Assert.AreEqual("You entered: null", Alert.getResult());
        }

    }

    public static class Alert
    {
        public static void ClickAlert(string type)
        {
            IList<IWebElement> buttons = Driver.Current.FindElements(By.CssSelector("li > button"));
            buttons.First(x => x.Text.Contains(type)).Click();
        }

        public static IAlert SwitchToAlert()
        {
            IAlert alert = Driver.Current.SwitchTo().Alert();
            return alert;
        }

        public static string getResult()
        {
            return Driver.Current.FindElement(By.CssSelector("#result")).Text;
        }

        public static void EnterAlertText(string message, IAlert alert)
        {
            alert.SendKeys(message);
        }

    }

}
