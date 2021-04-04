using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPageObject.Pages
{
    internal abstract class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public virtual string Url { get; set; } = "https://shop.vsk.ru/";

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void WaitLoadForElement(By locator, ushort seconds = 10)
        {
            var waitForElement = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));

            Func<IWebDriver, bool> waiter = new Func<IWebDriver, bool>((IWebDriver web) =>
            {
                try
                {
                    web.FindElement(locator);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            });

            waitForElement.Message = $"Failed to wait load element {locator} on page {Driver.Url}";
            waitForElement.Until(waiter);
        }
    }
}