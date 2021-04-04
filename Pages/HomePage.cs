using OpenQA.Selenium;

namespace SeleniumPageObject.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TravelLinkElement()
        {
            return Driver.FindElement(By.LinkText("Путешествия"));
        }
    }
}