using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests_project
{
    [TestFixture]
    public class ProjectCreationTests:AuthTestBase
    {//fix20
        [Test]
        public void ProjectCreateTest()
        {
            ProjectData project = new ProjectData(GenerateRandomString(30));
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();
            app.Projects.Create(project);
            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects,newProjects);
        }
    }
}
