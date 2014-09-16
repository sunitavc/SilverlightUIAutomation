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
            var checkbox = homePage.MainMenu().OpenVisualSamplesPage().Check();
            Assert.True(checkbox.IsChecked().Equals(true));
        }
    }
}
