using OpenQA.Selenium;
using SeleniumFramework;

namespace TFL_Test.PageObjects
{
    public class JourneyResultsPage
    {
        private By JourneyResultsLabel = By.XPath("//span[text()='Journey results']");
        private By ResultsHeadingLabel = By.XPath("//h2[contains(.,'Fastest by public transport')]");
        private By ErrorLabel = By.XPath("//li[@class='field-validation-error']");
        private By EditJourneyLink = By.XPath("//span[text()='Edit journey']");
        private By FromField = By.XPath("//input[contains(@id,'From')]");
        private By FromFieldCloseButton = By.XPath("//a[contains(.,'Clear From location')]");
        private By ToField = By.XPath("//input[contains(@id,'To')]");
        private By ToFieldCloseButton = By.XPath("//a[contains(.,'Clear To location')]");
        private By UpdateJourneyButton = By.XPath("//input[@value='Update journey']");

        public void VerifyResults()
        {
            Label.VerifyText(JourneyResultsLabel, "Journey results");
            Label.VerifyText(ResultsHeadingLabel, "Fastest by public transport");
        }

        public void VerifyErrorMessage()
        {
            Label.VerifyText(ErrorLabel, "we can't find a journey matching your criteria");
        }

        public void ClickEditJourney()
        {
            Button.Click(EditJourneyLink);
        }

        public void EnterFromValue(string EditedFrom)
        {
            Button.Click(FromFieldCloseButton);
            Thread.Sleep(1000);
            Textbox.TypeText(FromField, EditedFrom);
            
            By FromOption = By.XPath("//strong[text()='" + EditedFrom + "']");
            Button.Click(FromOption);
        }

        public void EnterToValue(string EditedTo)
        {
            Button.Click(ToFieldCloseButton);
            Thread.Sleep(1000);
            Textbox.TypeText(ToField, EditedTo);

            By FromOption = By.XPath("//strong[text()='" + EditedTo + "']");
            Button.Click(FromOption);
        }

        public void ClickUpdate()
        {
            Button.Click(UpdateJourneyButton);
        }
    }
}
