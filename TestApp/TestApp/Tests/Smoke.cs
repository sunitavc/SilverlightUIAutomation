using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestApp.Pages;
using TestApp.Setup;

namespace TestApp.Tests
{

    /// <summary>
    /// Plain ol' NUnit Tests. They inherit from TestBase as the metadata tags for setups and teardown
    /// is different for NUnit and for SpecFlow
    /// TIP: It's totally ok to have sanity tests in NUnit and business level tests in SpecFlow in the same repo
    /// Since Specflow also can use NUnit as a runner you can setup the pipeline to run NUnit Smoke tests first
    /// and if it all passes run the longer e2e scenarios.
    /// </summary>
    public class Smoke:TestBase
    {
        [Test]
        public void TestMenuNavigation()
        {
            var page = homePage.MainMenu().OpenWelcomePage();
            Assert.True(page.PageContent().Equals("XAML Spy"));
        }

        [Test]
        public void TestVisualSampleCheckBox()
        {
            var checkbox = homePage.MainMenu().OpenVisualSamplesPage().Uncheck();
            Assert.True(checkbox.IsChecked().Equals(true));
        }
    }
}
