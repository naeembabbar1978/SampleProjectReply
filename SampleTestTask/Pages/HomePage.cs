using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestTask.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = TestContext.Parameters["webAppUrl"]?? "https://demo.1crmcloud.com";

        public HomePage(IWebDriver driver) => _driver = driver;

        public void NavigateHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
        }
    }
}
