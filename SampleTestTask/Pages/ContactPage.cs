using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestTask.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;

       private WebDriverWait wait;

public ContactPage(IWebDriver driver)
{
    _driver = driver;
    wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Adjust the timeout as needed
}
    IWebElement txtFirstName => _driver.FindElement(By.Name("first_name"));
        IWebElement txtLastName => _driver.FindElement(By.Name("last_name"));

        IWebElement drpdownCategories => _driver.FindElement(By.Id("DetailFormcategories-input"));
        IWebElement drpdownCategoriesInput => _driver.FindElement(By.CssSelector("#DetailFormcategories-input-search-text > input"));

        IWebElement drpdownCategoriesOption => _driver.FindElement(By.Id("DetailFormcategories-input-search-list"));
        IWebElement drpdownBusinessCategories => _driver.FindElement(By.Id("DetailFormbusiness_role-input"));
        IWebElement drpdownBusinessCategoriesOption => _driver.FindElement(By.Id("DetailFormbusiness_role-input-search-list"));

        IWebElement btnSave => _driver.FindElement(By.Id("DetailForm_save2"));

        IWebElement btnCreateContact => _driver.FindElement(By.Name("SubPanel_create"));

        IWebElement listViewNameLink => _driver.FindElement(By.ClassName("listViewNameLink"));

        IWebElement lblPersonName => _driver.FindElement(By.ClassName("summary-header"));

        IWebElement lblCategory => _driver.FindElement(By.CssSelector("#le_section__summary > div > div.column.summary-main > div > div.column.summary-right > div.summary-meta > ul > li:nth-child(1)"));


        IWebElement lblRole => _driver.FindElement(By.CssSelector("#main-0 > div.row.form-row.row-odd.col-unstack > div.column.form-cell.sm-6.cell-business_role.span-1 > div > div"));

        IWebElement salemenu => _driver.FindElement(By.Id("grouptab-1"));

        IWebElement contactBtn => _driver.FindElement(By.XPath("/html/body/nav/div[2]/div[2]/div[3]/a"));

        public void NavigateContactPage()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(salemenu).Perform();

            Thread.Sleep(5000);
            contactBtn.Click();
            Thread.Sleep(1000);
            btnCreateContact.Click();

        }

        public void ValidateUser(string firstname, string lastname, string categories, string businessrole)
        {
            if (listViewNameLink != null)
            {
                listViewNameLink.Click();
                Thread.Sleep(2000);
            }

            var personName = lblPersonName.Text.Split(' ');
            Assert.AreEqual(firstname, personName[0]);
            Assert.AreEqual(lastname, personName[1]);

            var lblCategoryText = lblCategory.Text;
            Assert.AreEqual(categories, String.Join(", ", lblCategoryText.Replace("Category:", "").Trim().Split(", ").Reverse()));

            var roleText = lblRole.Text;
            Assert.AreEqual(businessrole, roleText);


        }

        public void CreateContact(string firstname, string lastname, string categories, string businessrole)

        {
            Thread.Sleep(2000);
            txtFirstName.SendKeys(firstname);
            txtLastName.SendKeys(lastname);
            foreach (var category in categories.Split(","))
            {
                drpdownCategories.Click();
                Thread.Sleep(3000);
                drpdownCategoriesInput.SendKeys(category);
                drpdownCategoriesOption.Click();
                Thread.Sleep(3000);
            }

            drpdownBusinessCategories.SendKeys(businessrole);
            drpdownBusinessCategoriesOption.Click();
            btnSave.Click();

            Thread.Sleep(3000);


        }


    }
}
