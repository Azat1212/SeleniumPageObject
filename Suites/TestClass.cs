using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPageObject.Pages;

namespace SeleniumPageObject.Suites
{

    [TestFixture]
    class TestClass
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private TravelPage _travelPage;
        private BuyPolisPage _buyPolisPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _travelPage = new TravelPage(_driver);
            _buyPolisPage = new BuyPolisPage(_driver);
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [TestCase(TestName = "_01_Переход на главную страницу"), Order(1)]
        public void GoToHomePage()
        {
            _homePage.GoToPage();
            Assert.That(_homePage.Url == _driver.Url);
        }

        [TestCase(TestName = "_02_Переход на страницу Путешествия"), Order(2)]
        public void GoToTravelPage()
        {
            var travelLink = _homePage.TravelLinkElement().GetAttribute("href");
            _driver.Navigate().GoToUrl(travelLink);
            Assert.That(_travelPage.Url == _driver.Url);
        }

        [TestCase(TestName = "_03_Переход к оформлению полиса"), Order(3)]
        public void GoToBuyPolisy()
        {
            _travelPage.GetBuyPolisyBtnElement().Click();

            Assert.That(_buyPolisPage.Url.Contains(_driver.Url));
        }

        [TestCase(TestName = "_04_Оформление полиса"), Order(4)]
        public void MakeAPolicy()
        {
            _buyPolisPage.SelectCountry("Египет")
                .FillBeginDate(DateTime.Today.AddDays(5))
                .FillEndDate(DateTime.Today.AddDays(15))
                .MakeAPolicyBtnElement();

            _buyPolisPage.WaitLoadForElement(By.XPath("//*[label='Страхователь]"));
        }
    }
}
