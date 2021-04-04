using OpenQA.Selenium;

namespace SeleniumPageObject.Pages
{
    internal class TravelPage : BasePage
    {
        public TravelPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url { get; set; } = "https://shop.vsk.ru/travel";

        public IWebElement GetBuyPolisyBtnElement()
        {
            By locator = By.XPath("//*[@id='travel_banner_button_buy]"); 
            return Driver.FindElement(locator);
        }
    }
}