using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests_project
{
   public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            if(driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToProjectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php"
                && IsElementPresent(By.XPath("//button[@class='btn btn-primary btn-white btn-round']")))
            {
                return;
            }
            driver.FindElement(By.CssSelector("i.fa-gears")).Click();
            driver.FindElement(By.CssSelector("a[href='/mantisbt-2.25.3/manage_proj_page.php']")).Click();
        }
    }
}
