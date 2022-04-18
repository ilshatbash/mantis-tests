using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests_project
{
    public class APIHelper : HelperBase
    {
        private string baseURL;
        public APIHelper(ApplicationManager manager):
            base(manager)
        {
            
        }
    }
}
