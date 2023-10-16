using LivingDoc.Dtos;
using NUnit.Framework;
using OpenQA.Selenium;
using SampleTestTask.Pages;
using System;
using System.Diagnostics.Contracts;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SampleTestTask.StepDefinitions
{
    [Binding]
    public class MainTestsSteps
    {
        private IWebDriver _driver;
        private ReportsPage _reportPage;
        private LoginPage _loginPage;
        private ContactPage _contactPage;
        private ActivityPage _activityPage;
        private HomePage _homePage;
        public MainTestsSteps(IWebDriver driver, HomePage homePage, ReportsPage reportPage, LoginPage loginPage, ContactPage contactPage, ActivityPage activityPage)
        {
            _driver = driver;
            _homePage = homePage;
            _reportPage = reportPage;
            _loginPage = loginPage;
            _contactPage = contactPage;
            _activityPage = activityPage;
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _homePage.NavigateHomePage();

        }

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword()
        {
            _loginPage.EnterUserNameAndPassword(TestContext.Parameters["webAppUserName"], TestContext.Parameters["webAppPassword"]);
            Thread.Sleep(1000);
            _loginPage.ClickLogin();
            Thread.Sleep(2000);
        }



        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            var dashboard = _loginPage.GetDashboardText();
            Assert.Multiple(() =>
            {
                Assert.NotNull(dashboard);
            });
        }

        [Given(@"I navigate to contact Page")]
        public void ThenINavigateToContactPage()
        {
            _contactPage.NavigateContactPage();
        }

        [Then(@"I enter contact information")]
        public void ThenIEnterContactInformation(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _contactPage.CreateContact((String)data.FirstName, (String)data.LastName, (String)data.Category, (String)data.BusinessRole);
        }

        [Then(@"Validate the contact information")]
        public void ThenValidateTheContactInformation(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _contactPage.ValidateUser((String)data.FirstName, (String)data.LastName, (String)data.Category, (String)data.BusinessRole);

        }

        [Given(@"I navigate to Reports AND Settings > Reports")]
        public void ThenINavigateToReportsANDSettingsReports()
        {
            _reportPage.NavigateToReportPage();
        }

        [Then(@"I run the Project Profitability report")]
        public void ThenIRunTheProjectProfitabilityReport()
        {
            _reportPage.OpenProjectProfitReport();
        }

        [Then(@"I verify that some results were returned")]
        public void ThenIVerifyThatSomeResultsWereReturned()
        {
            _reportPage.ValidateReportData();
        }

        [Given(@"I navigate to Reports AND Settings > Activity")]
        public void ThenINavigateToActivityReports()
        {
            _activityPage.NavigateActivityPage();
        }


        [Then(@"I select and delete the first 3 items in the table")]
        public void ThenISelectANDDeleteTheFirstItemsInTheTable()
        {
            _activityPage.SelectActivityLogs();
            _activityPage.DeleteLogItems();

        }

        [Then(@"I verify that the items were deleted")]
        public void ThenIVerifyThatTheItemsWereDeleted()
        {
            _activityPage.ValidateRecordsDeleted();
        }


    }
}
