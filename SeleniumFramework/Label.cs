using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace SeleniumFramework
{
    public class Label
    {
        public static string GetText(By label)
        {
            //Wait for the label to be found
            IWebElement element = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(label));
            return element.Text;
        }

        public static bool VerifyText(By Label, string Expected)
        {
            //Wait for the label to be found
            IWebElement element = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(Label));

            //Check if the Label contains expected text
            if (element.Text.Contains(Expected))
            {
                Helper.TakeScreenshot("TextVerified");
                return true;
            }

            return false;
        }
    }
}
