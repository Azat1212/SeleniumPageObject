using OpenQA.Selenium;

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
    }
}