
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFramework
{
    public class Dropdown
    {
        public static void Select(By Dropdown, string Text)
        {
            //Find Dropdown element and select option
            IWebElement WebElement = Browser.WebDriver.FindElement(Dropdown);
            SelectElement SelectElement = new SelectElement(WebElement);
            SelectElement.SelectByText(Text);

            //Take screenshot
            Helper.TakeScreenshot("Dropdown_Select");
        }
    }
}
