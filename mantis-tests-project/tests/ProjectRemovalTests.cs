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
            if (!app.Projects.IsProjectIn())
            {
                ProjectData proj = new ProjectData(GenerateRandomString(30));
                app.Projects.Create(proj);
            }
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();
            app.Projects.Remove(0);
            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

