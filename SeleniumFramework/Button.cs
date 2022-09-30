using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFramework
{
    public class Button
    {
        public static void Click(By button)
        {
            //Wait for the button to be clickable
            IWebElement WebElement = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(button));
            WebElement.Click();

            //Take screenshot
            Helper.TakeScreenshot("Button_Click");
        }
    }
}
