using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestTask.Pages
{
    public class ReportsPage
    {

        private readonly IWebDriver _driver;
        public ReportsPage(IWebDriver driver) => _driver = driver;
        IWebElement reportMenu => _driver.FindElement(By.Id("grouptab-5"));
        IWebElement btnReport => _driver.FindElement(By.XPath("/html/body/nav/div[2]/div[6]/div[1]/a"));
        IWebElement txtSearchReport => _driver.FindElement(By.Name("filter_text"));
        IWebElement listViewNameLink => _driver.FindElement(By.ClassName("listViewNameLink"));
        IWebElement FilterForm_applyButton => _driver.FindElement(By.Name("FilterForm_applyButton"));
        ReadOnlyCollection<IWebElement> reportTable => _driver.FindElements(By.ClassName("listViewRow"));


        public void NavigateToReportPage()
        {
            var salemenu = _driver.FindElement(By.Id("grouptab-5"));

            Actions action = new Actions(_driver);
            action.MoveToElement(salemenu).Perform();

            Thread.Sleep(3000);
            btnReport.Click();
           // btnReport.Click();
            Thread.Sleep(5000);

        }

        public void OpenProjectProfitReport()
        {

            txtSearchReport.SendKeys("Project Profit");
            txtSearchReport.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            listViewNameLink.Click();
            Thread.Sleep(3000);

            FilterForm_applyButton.Click();
            Thread.Sleep(3000);


        }


        public void ValidateReportData()
        {
            Assert.True(reportTable.Count > 0);
        }





    }
}
