using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework;

namespace TFL_Test.PageObjects
{
    public class PlanMyJourneyPage
    {
        private By CookiesHeadingLabel = By.XPath("//h2[contains(.,'Your cookie settings')]");
        private By AcceptAllCookiesButton = By.XPath("//strong[text()='Accept all cookies']");
        private By DoneButton = By.XPath("//strong[text()='Done']");
        private By FromField = By.XPath("//input[contains(@id,'From')]");
        private By ToField = By.XPath("//input[contains(@id,'To')]");
        private By ChangeTimeLink = By.XPath("//a[text()='change time']");
        private By ArrivingButton = By.XPath("//label[text()='Arriving']");
        private By DateDropdown = By.XPath("//select[@id='Date']");
        private By TimeDropdown = By.XPath("//select[@id='Time']");
        private By PlanMyJourneyButton = By.XPath("//input[@value='Plan my journey']");
        private By FromErrorLabel = By.XPath("//span[@class='field-validation-error' and contains(.,'From')]");
        private By ToErrorLabel = By.XPath("//span[@class='field-validation-error' and contains(.,'To')]");
        private By RecentsButton = By.XPath("//a[text()='Recents']");

        public void NavigateToStartPage()
        {
            Browser.GoToUrl("https://www.tfl.gov.uk");
            Assert.IsTrue(Browser.WebDriver.Title.ToLower().Contains("keeping london moving"));

            //Accept all cookies
            if (Browser.IsElementVisible(CookiesHeadingLabel))
            {
                Button.Click(AcceptAllCookiesButton);
                Thread.Sleep(1000);
                Button.Click(DoneButton);
                Thread.Sleep(1000);
            }
        }

        public void EnterFrom(string FromValue)
        {
            Textbox.TypeText(FromField, FromValue);

            By FromOption = By.XPath("//strong[text()='" + FromValue + "']");
            Button.Click(FromOption);
        }

        public void EnterInvalidFrom(string FromValue)
        {
            Textbox.TypeText(FromField, FromValue);
            Textbox.TypeText(FromField, Keys.Escape);
        }

        public void EnterTo(string ToValue)
        {
            Textbox.TypeText(ToField, ToValue);

            By ToOption = By.XPath("//strong[text()='" + ToValue + "']");
            Button.Click(ToOption);
        }

        public void EnterInvalidTo(string ToValue)
        {
            Textbox.TypeText(ToField, ToValue);
            Textbox.TypeText(ToField, Keys.Escape);
        }

        public void ClickPlanMyJourney()
        {
            Button.Click(PlanMyJourneyButton);
        }

        public void VerifyMandatoryFieldErrorMessage()
        {
            Label.VerifyText(FromErrorLabel, "The From field is required");
            Label.VerifyText(ToErrorLabel, "The To field is required");
        }

        public void SelectArrivingOption()
        {
            Button.Click(ChangeTimeLink);
            Button.Click(ArrivingButton);
        }

        public void SelectDate(string Date)
        {
            Dropdown.Select(DateDropdown, Date);
        }

        public void SelectTime(string Time)
        {
            Dropdown.Select(TimeDropdown, Time);
        }

        public void ClickRecents()
        {
            Button.Click(RecentsButton);
        }

        public void VerifyPreviousJourneys(string FromValue, string ToValue)
        {
            By RecentJourneys = By.XPath("//a[text()='" + FromValue + " to " + ToValue + "']");
            Label.VerifyText(RecentJourneys, FromValue + " to " + ToValue);
        }
    }
}
