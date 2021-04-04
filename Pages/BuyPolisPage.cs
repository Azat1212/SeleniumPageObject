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

        public IWebElement CountryFieldElement()
        {
            return Driver.FindElement(By.XPath(".//div[@class='ng-value-container']/div[@class='ng-input']/input"));
        }

        public IWebElement MakeAPolicyBtnElement()
        {
            return Driver.FindElement(By.XPath("//*[@id='sidebar_step_next']"));
        }

        public void SelectFirstCountryInList()
        {
            Driver.FindElement(By.XPath(".//div[@class='scrollable-content']/div[2]")).Click();
        }

        public void FillBeginDate(DateTime date)
        {
            var element = Driver.FindElement(By.XPath("//*[@id='mat-input-6']"));
            element.Clear();
            element.SendKeys(date.Date.ToString("d"));
        }

        public void FillEndDate(DateTime date)
        {
            var element = Driver.FindElement(By.XPath("//*[@id='mat-input-8']"));
            element.Clear();
            element.SendKeys(date.Date.ToString("d"));
        }
    }
}