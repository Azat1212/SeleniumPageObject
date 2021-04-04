using OpenQA.Selenium;

namespace SeleniumPageObject.Pages
{
    internal class TravelPage : BasePage
    {
        public TravelPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url { get; set; } = "https://shop.vsk.ru/travel";

        public IWebElement GetBuyPolisBtnElement()
        {
            return Driver.FindElement(By.Id("travel_banner_button_buy"));
        }
    }
}