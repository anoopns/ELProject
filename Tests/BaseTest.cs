using EL.Computer.Pages;
using Framework.Driverutilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace EL.Tests
{
    public class BaseTest
    {
        [SetUp]
        public virtual void BeforeEach()
        {
            Driver.Init("chrome");
            Driver.Current.Manage().Window.Maximize();
            Pages.Init();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            Driver.Quit();
        }


    }
}
