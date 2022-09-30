using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TFL_Test.PageObjects;

namespace TFL_Test.StepDefinitions
{
    [Binding]
    public class JourneyPlanner
    {
        private PlanMyJourneyPage planMyJourneyPage = new PlanMyJourneyPage();
        private JourneyResultsPage journeyResultsPage = new JourneyResultsPage();

        public JourneyPlanner()
        {
        }

        [Given(@"the user navigated to TFL website")]
        public void GivenTheUserNavigatedToTFLWebsite()
        {
            planMyJourneyPage.NavigateToStartPage();
        }

        [Given(@"user enters valid (.*) and (.*) values")]
        public void GivenUserEntersValidNewburyParkAndEustonStationValues(String FromStation, String ToStation)
        {
            planMyJourneyPage.EnterFrom(FromStation);
            planMyJourneyPage.EnterTo(ToStation);
        }

        [When(@"user clicks the Search button")]
        public void WhenUserClicksTheSearchButton()
        {
            planMyJourneyPage.ClickPlanMyJourney();   
        }

        [Then(@"user should be presented with valid results")]
        public void ThenUserShouldBePresentedWithValidResults()
        {
            journeyResultsPage.VerifyResults();
        }

        [Given(@"user enters invalid from and to values")]
        public void GivenUserEntersInvalidNewburyParkAndInvalidStationValues()
        {
            planMyJourneyPage.EnterInvalidFrom("xxxxxxxx");
            planMyJourneyPage.EnterInvalidTo("xxxxxxxx");
        }

        [Then(@"user should be presented with valid error message")]
        public void ThenUserShouldBePresentedWithValidErrorMessage()
        {
            journeyResultsPage.VerifyErrorMessage();
        }

        [Given(@"user doesn't enter any values")]
        public void GivenUserDoesntEnterAnyValues()
        {
            planMyJourneyPage.EnterInvalidFrom(" ");
            planMyJourneyPage.EnterInvalidTo(" ");
        }

        [Then(@"user should be presented with mandatory field error message")]
        public void ThenUserShouldBePresentedWithMandatoryFieldErrorMessage()
        {
            planMyJourneyPage.VerifyMandatoryFieldErrorMessage();
        }

        [Given(@"user selects Arriving option and enters valid (.*) and (.*)")]
        public void GivenUserSelectsArrivingOptionAndEntersValidTomorrowAnd(string Date, string Time)
        {
            planMyJourneyPage.SelectArrivingOption();
            planMyJourneyPage.SelectDate(Date);
            planMyJourneyPage.SelectTime(Time);
        }

        [When(@"on the results page user clicks Edit Journey button")]
        public void WhenOnTheResultsPageUserClicksEditJourneyButton()
        {
            journeyResultsPage.ClickEditJourney();
        }

        [When(@"user enters updated (.*) and (.*) values")]
        public void WhenUserEntersUpdatedIlfordAndRomfordValues(string EditedFrom, string EditedTo)
        {
            journeyResultsPage.EnterFromValue(EditedFrom);
            journeyResultsPage.EnterToValue(EditedTo);
        }

        [When(@"user clicks the Update journey button")]
        public void WhenUserClicksTheUpdateJourneyButton()
        {
            journeyResultsPage.ClickUpdate();
        }

        [When(@"user goes back to main page and clicks the Recents button")]
        public void WhenUserClicksTheRecentsButton()
        {
            planMyJourneyPage.NavigateToStartPage();
            planMyJourneyPage.ClickRecents();
        }

        [Then(@"user should be presented with previous journeys (.*) and (.*)")]
        public void ThenUserShouldBePresentedWithPreviousJourneys(string From, string To)
        {
            planMyJourneyPage.VerifyPreviousJourneys(From, To);
        }
    }
}
