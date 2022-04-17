using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests_project
{
    public class ProjectHelper:HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) {}

        
            public List<ProjectData> GetProjectsList()
            {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToProjectPage();
            ICollection<IWebElement> elements = driver.FindElements
                (By.XPath("//i[@class='fa fa-puzzle-piece ace-icon']/../../..//tbody//tr"));
            foreach (IWebElement element in elements)
            {
                IWebElement cells = element.FindElements(By.TagName("td")).FirstOrDefault();
                ProjectData project = new ProjectData(cells.Text);
                projects.Add(project);     
            }
            return projects;
        }

        public void Remove(int index)
        {
            manager.Navigator.GoToProjectPage();
            SelectProject(index);
            RemoveProject();
        }

        private void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void ReturnToProjectsPage()
        {
            throw new NotImplementedException();
        }

        private void SelectProject(int index)
        {
            driver.FindElement(By.XPath("//i[@class='fa fa-puzzle-piece ace-icon']/../../..//tbody//tr[" + (index +1)+ "]/td[1]/a")).Click();
        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToProjectPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            ReturnToProjectPage();
 
        }

        private void ReturnToProjectPage()
        {
            driver.FindElement(By.CssSelector("a[href='manage_proj_page.php']")).Click();
        }

        private void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
        }

        private void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round']")).Click();
        }
        public bool IsProjectIn()
        {
            manager.Navigator.GoToProjectPage();
            bool i = IsElementPresent(By.XPath("//i[@class='fa fa-puzzle-piece ace-icon']/../../..//tbody//tr"));
            return i;
        }
    }
    }
