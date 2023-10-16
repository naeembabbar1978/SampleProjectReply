using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SampleTestTask.Pages
{
    public class LoginPage
    {

        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) => _driver = driver;


        IWebElement txtUserName => _driver.FindElement(By.Name("user_name"));
        IWebElement txtPassword => _driver.FindElement(By.Name("user_password"));
        IWebElement btnLogin => _driver.FindElement(By.Id("login_button"));
        IWebElement Dashboard => _driver.FindElement(By.XPath("//span[contains(text(),'Home Dashboard')]"));



        public void EnterUserNameAndPassword(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }

        public string GetDashboardText()
        {
            return Dashboard.Text;
        }
    }
}
