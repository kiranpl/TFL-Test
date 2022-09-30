using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Emit;

namespace SeleniumFramework
{
    public class Browser : IDisposable
    {
        private static IWebDriver chromeDriver = new ChromeDriver();

        public static IWebDriver WebDriver
        {
            get => chromeDriver;
        }

        public static void GoToUrl(string Url)
        {
            chromeDriver.Navigate().GoToUrl(Url);
        }

        public static bool IsElementVisible(By Element)
        {
            return chromeDriver.FindElements(Element).Count() > 0;
        }

        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
            }
        }
    }
}