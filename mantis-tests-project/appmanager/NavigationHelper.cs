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
        private string mantisVersion;
        public NavigationHelper(ApplicationManager manager, string baseURL, string mantisVersion) : base(manager)
        {
            this.baseURL = baseURL;
            this.mantisVersion = mantisVersion;


        }
        public void OpenHomePage()
        {
            if(driver.Url == baseURL+ mantisVersion)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + mantisVersion);
        }

        public void GoToProjectPage()
        {
            if (driver.Url == baseURL + mantisVersion+ "/manage_proj_page.php"
                && IsElementPresent(By.XPath("//button[@class='btn btn-primary btn-white btn-round']")))
            {
                return;
            }
            driver.FindElement(By.CssSelector("i.fa-gears")).Click();
            driver.FindElement(By.CssSelector("a[href='/mantisbt-"+mantisVersion+"/manage_proj_page.php']")).Click();
          

        }
    }
}
