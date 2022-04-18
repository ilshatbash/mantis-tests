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

        
            public List<ProjectData> GetProjectsList(AccountData account)
            {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projectsm = client.mc_projects_get_user_accessible(account.Name, account.Password);

            List<ProjectData> projects = new List<ProjectData>();
            // manager.Navigator.GoToProjectPage();
            //ICollection<IWebElement> elements = driver.FindElements
            //  (By.XPath("//i[@class='fa fa-puzzle-piece ace-icon']/../../..//tbody//tr"));
            //foreach (IWebElement element in elements)
            foreach (var projectm in projectsm)
            {
                //  IWebElement cells = element.FindElements(By.TagName("td")).FirstOrDefault();
                //  ProjectData project = new ProjectData(cells.Text);
                //  projects.Add(project);     
                ProjectData project = new ProjectData(projectm.name);
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

        public void CreateMantis(ProjectData project, AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData() { name = project.Name };
            client.mc_project_add(account.Name, account.Password, projectData);

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
        public bool IsProjectIn(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projectsm = client.mc_projects_get_user_accessible(account.Name, account.Password);
            return projectsm != null && projectsm.Length > 0;
        }
    }
    }
