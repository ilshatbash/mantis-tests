using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests_project
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {

        [Test]
        public void ProjectRemoveTest()
        {
            AccountData account = new AccountData("administrator", "root");
            if (!app.Projects.IsProjectIn(account))
            {           
                ProjectData proj = new ProjectData(GenerateRandomString(30));
                app.Projects.CreateMantis(proj, account);
            }
            List<ProjectData> oldProjects = app.Projects.GetProjectsList(account);
            app.Projects.Remove(0);
            List<ProjectData> newProjects = app.Projects.GetProjectsList(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}

