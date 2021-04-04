using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPageObject.Pages
{
    internal abstract class BasePage
    {
        public IWebDriver Driver;
        //public IWa

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public virtual string Url { get; set; } = "https://shop.vsk.ru/";

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void WaitShowElement(By locator)
        {
            var iWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            iWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}