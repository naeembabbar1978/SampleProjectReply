using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestTask.Pages
{
    public class ActivityPage
    {

        private readonly IWebDriver _driver;
        private string activitylogTobeDeleted;
        public ActivityPage(IWebDriver driver) => _driver = driver;

        IWebElement reportMenu => _driver.FindElement(By.Id("grouptab-5"));
        IWebElement btnReport => _driver.FindElement(By.XPath("/html/body/nav/div[2]/div[6]/div[3]/a"));
        IWebElement inputLog1 => _driver.FindElement(By.CssSelector(".listView > tbody > tr:nth-child(1) > td.listViewTd.listViewMeta > div > input"));
        IWebElement inputLog2 => _driver.FindElement(By.CssSelector(".listView > tbody > tr:nth-child(2) > td.listViewTd.listViewMeta > div > input"));
        IWebElement inputLog3 => _driver.FindElement(By.CssSelector(".listView > tbody > tr:nth-child(3) > td.listViewTd.listViewMeta > div > input"));
        IWebElement inputlog1Text => _driver.FindElement(By.CssSelector(".listView > tbody > tr:nth-child(1) > td:nth-child(2)"));
        IWebElement btnAction => _driver.FindElement(By.CssSelector(".listview-actions button"));
        IWebElement btndelete => _driver.FindElement(By.CssSelector(".popup-default > div > div.menu-option.single > div:nth-child(2)"));



        public void NavigateActivityPage()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(reportMenu).Perform();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            wait.Until(d => btnReport.Displayed);
            btnReport.Click();


        }


        public void SelectActivityLogs()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            wait.Until(d => inputlog1Text.Displayed);
            activitylogTobeDeleted = inputlog1Text.Text;
            inputLog1.Click();
            inputLog2.Click();
            inputLog3.Click();
        }


        public void DeleteLogItems()
        {
            btnAction.Click();
            Thread.Sleep(2000);
            btndelete.Click();


            var alert = _driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void ValidateRecordsDeleted()
        {
            var logText = inputlog1Text.Text;
            Assert.AreNotSame(activitylogTobeDeleted, logText);
        }

    }
}
