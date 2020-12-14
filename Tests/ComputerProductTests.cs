using EL.Computer.Pages;
using EL.Tests;
using Framework.Driverutilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Tests
{
    public class ComputerProductTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {

            Driver.Goto("http://computer-database.gatling.io/computers");
        }


        [Test]
        public void UserCanAddComputerProduct()
        {
            //manual test name: User can add a new computer product
            Pages.Lists.ClickAddButton();
            Assert.IsTrue(Pages.ProductPage.isPageLoaded());
            Pages.ProductPage.EnterName("ABC");
            Pages.ProductPage.EnterIntroducedDate("2001-12-30");
            Pages.ProductPage.EnterDiscontinuedDate("2010-12-20");
            Pages.ProductPage.SelectCompanyByText("RCA");
            Pages.ProductPage.ClickCreate();
            Assert.IsTrue(Pages.Lists.IsSuccessMessagePresent());
        }

        [Test]
        public void UserMustEnterName()
        {
            //manual test name: User can not add a new computer with out giving a name
            Pages.Lists.ClickAddButton();
            Assert.IsTrue(Pages.ProductPage.isPageLoaded());
            Pages.ProductPage.EnterIntroducedDate("2001-12-30");
            Pages.ProductPage.EnterDiscontinuedDate("2010-12-20");
            Pages.ProductPage.SelectCompanyByText("RCA");
            Pages.ProductPage.ClickCreate();
            Assert.True(Pages.ProductPage.CheckNameMissingMessage(
                "Failed to refine type : Predicate isEmpty() did not fail."));
        }

        [Test]
        public void UserMustEnterValidIntroduedDate()
        {
            //manual test name: User can not add a new computer without giving the dates in required format
            var invalidDate = "200112-30";
            Pages.Lists.ClickAddButton();
            Assert.IsTrue(Pages.ProductPage.isPageLoaded());
            Pages.ProductPage.EnterName("ABC");
            Pages.ProductPage.EnterIntroducedDate(invalidDate);
            Pages.ProductPage.EnterDiscontinuedDate("2010-12-20");
            Pages.ProductPage.SelectCompanyByText("RCA");
            Pages.ProductPage.ClickCreate();
            Assert.True(Pages.ProductPage.CheckIntroducedDateMissingMessage(
                $"Failed to decode date : java.time.format.DateTimeParseException: Text '{invalidDate}' could not be parsed at index 0"));
        }

        [Test]
        public void UserCanUpdateProduct()
        {
            //manual test name: User can update an existing computer product
            Pages.Lists.ClickProduct();
            Assert.IsTrue(Pages.ProductPage.isPageLoaded());
            Pages.ProductPage.EnterName("ABC");
            Pages.ProductPage.EnterIntroducedDate("2001-12-30");
            Pages.ProductPage.EnterDiscontinuedDate("2010-12-20");
            Pages.ProductPage.SelectCompanyByText("RCA");
            Pages.ProductPage.ClickCreate();
            Assert.IsTrue(Pages.Lists.IsSuccessMessagePresent());
        }

        [Test]
        public void UserCanDeleteproduct()
        {
            //manual test name: User can delete a computer
            Pages.Lists.ClickProduct();
            Assert.IsTrue(Pages.ProductPage.isPageLoaded());
            Pages.ProductPage.ClickDeleteButton();
            Assert.IsTrue(Pages.Lists.IsSuccessMessagePresent());
        }

    }
}