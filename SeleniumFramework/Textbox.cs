using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public class Textbox
    {
        public static void TypeText(By textbox, string text)
        {
            //Wait for the Textbox to be found
            IWebElement WebElement = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(textbox));
            WebElement.SendKeys(text);

            Helper.TakeScreenshot("TypeText");
        }
    }
}
