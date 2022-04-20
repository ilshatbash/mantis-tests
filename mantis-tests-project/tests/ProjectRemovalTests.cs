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
            ProjectData toBeRemoved = oldProjects[0];
            app.Projects.RemoveMantis(account, toBeRemoved);
            List<ProjectData> newProjects = app.Projects.GetProjectsList(account);
            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count());
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}

