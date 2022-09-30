using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    class Helper
    {
        public static void TakeScreenshot(String FileName)
        {
            //Create folder if it doesn't exist already
            string ScreenshotFolder = AppContext.BaseDirectory + Path.DirectorySeparatorChar + "Screenshots";
            Directory.CreateDirectory(ScreenshotFolder);

            //Take screenshot
            string Timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot Screenshot = ((ITakesScreenshot)Browser.WebDriver).GetScreenshot();
            string FilePath = Path.Combine(ScreenshotFolder, FileName + "_" + Timestamp + ".png");
            Screenshot.SaveAsFile(FilePath);
        }
    }
}
