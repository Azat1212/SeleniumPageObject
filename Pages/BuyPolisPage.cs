using System;
using OpenQA.Selenium;

namespace SeleniumPageObject.Pages
{
    internal class BuyPolisPage : BasePage
    {
        public BuyPolisPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url { get; set; } = "https://shop.vsk.ru/calculator/travel";

        public BuyPolisPage SelectCountry(string country)
        {
            Driver.FindElement(By.XPath(".//div[@class='ng-value-container']/div[@class='ng-input']/input")).SendKeys(country);
            SelectFirstCountryInList();
            return this;
        }

        public BuyPolisPage MakeAPolicyBtnElement()
        {
            Driver.FindElement(By.XPath("//*[@id='sidebar_step_next']")).Click();
            return this;
        }

        private void SelectFirstCountryInList()
        {
            Driver.FindElement(By.XPath(".//div[@class='scrollable-content']/div[2]")).Click();
        }

        public BuyPolisPage FillBeginDate(DateTime date)
        {
            var element = Driver.FindElement(By.XPath("//*[@id='mat-input-6']"));
            element.Clear();
            element.SendKeys(date.Date.ToString("d"));
            return this;
        }

        public BuyPolisPage FillEndDate(DateTime date)
        {
            var element = Driver.FindElement(By.XPath("//*[@id='mat-input-8']"));
            element.Clear();
            element.SendKeys(date.Date.ToString("d"));
            return this;
        }
        
        //public IWebElement InsuredHeader(DateTime date)
        //{
        //}


    }
}