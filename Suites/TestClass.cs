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
        private IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        
        [OneTimeTearDown]
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [TestCase]
        public void CheckBuyPolis()
        {
             
            var homePage = new HomePage(driver);

            //a.Перейти на сайт _https://shop.vsk.ru/ 
            homePage.GoToPage();

            //b.Перейти на вкладку «Путешествия» 

            //почему то клик не работает
            //homePage.TravelLinkElement().Click();
            var travelLink = homePage.TravelLinkElement().GetAttribute("href");
            driver.Navigate().GoToUrl(travelLink);

            //c.Нажать кнопку «Купить полис» 
            var travelPage = new TravelPage(driver);
            travelPage.GetBuyPolisBtnElement().Click();

            //d.Заполнить поля следующими данными: 
            var buyPolisPage = new BuyPolisPage(driver);

            //• Страна или город = Египет 
            buyPolisPage.CountryFieldElement().SendKeys("Египет");
            buyPolisPage.SelectFirstCountryInList();

            //• Дата начала = Сегодня + 5 дней 
            buyPolisPage.FillBeginDate(DateTime.Today.AddDays(5));

            //• Дата окончания = Сегодня + 15 дней 
            buyPolisPage.FillEndDate(DateTime.Today.AddDays(15));

            //• Нажать кнопку «Оформить полис»
            buyPolisPage.MakeAPolicyBtnElement().Click();
        }
    }
}
