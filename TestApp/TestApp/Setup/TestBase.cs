using System;
using System.Drawing;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.TestTemplates;
using NUnit.Framework;
using TestApp.Pages;

namespace TestApp.Setup
{
    /// <summary>
    /// The Base Test class for Silverlight Tests
    /// Inherits from the WebAii BaseTest
    /// Opens a browser, navigates to BaseUrl and gives handle to the WebAii Driver (Manager)
    /// </summary>

    public class TestBase : BaseTest
    {
        #region Members

        /// <summary>
        /// Gets the silverlight app setting.
        /// </summary>
        /// <value>
        /// The setting.
        /// </value>
        protected static internal Settings Setting
        {
            get { return GetSettings(); }
        }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        protected static internal WebAiiDriver Driver
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        protected static string BaseUrl
        {
            get { return Setting.Web.BaseUrl; }
        }

        /// <summary>
        /// Gets the browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        protected static internal Browser Browser
        {
            get { return Driver.ActiveBrowser; }
        }

        protected HomePage homePage { get; private set; }
        #endregion
        
        #region SetUp/TearDown
        /// <summary>
        /// The base setup required before running a test fixture
        /// </summary>
        [TestFixtureSetUp]
        public static void TestBaseFixtureSetup()
        {
            Driver = DriverFactory.GetWebAiiDriver();
            Driver.LaunchNewBrowser();
        }

        [SetUp]
        public void Setup()
        {
            Driver.Browser.NavigateTo(BaseUrl);
            Maximize();
            homePage = new HomePage();
            homePage.Refresh();
        }
        [TearDown]
        public void TearDown()
        {
            RecordFailures();
        }

        /// <summary>
        /// The base fixture tear down
        /// </summary>
        [TestFixtureTearDown]
        public void TestBaseFixtureTearDown()
        {
            CleanUp();
            ShutDown();
        }

        
        #endregion

        #region Helper methods

        /// <summary>
        /// Captures the screen shot.
        /// </summary>
        /// <param name="imageName">Name of the image.</param>
        public void CaptureScreenShot(string imageName)
        {
            Driver.Log.CaptureBrowser(Browser, imageName);
        }

        /// <summary>
        /// Tries the capture screen shot.
        /// </summary>
        /// <param name="imageName">Name of the image.</param>
        public void TryCaptureScreenShot(string imageName)
        {
            try
            {
                CaptureScreenShot(imageName);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to save snapshot of {0} : {1}", imageName, exception);
            }
        }

        /// <summary>
        /// Refreshes this application.
        /// </summary>
        public void Reload()
        {
            Browser.Refresh();
        }

        /// <summary>
        /// Maximizes the browser.
        /// </summary>
        public static void Maximize()
        {
            Browser.Window.Maximize();
        }

        /// <summary>
        /// Hard Refresh of this application.
        /// </summary>
        public void Reset()
        {
            Driver.Browser.ClearCache(BrowserCacheType.Cookies);
            Driver.Browser.NavigateTo(BaseUrl);
        }

        /// <summary>
        /// Images this instance.
        /// </summary>
        public Bitmap Capture()
        {
            return Driver.Browser.Capture();
        }

        /// <summary>
        /// Shut down and clean-up.
        /// </summary>
        public new void RecordFailures()
        {
            //  
            // Place any additional cleanup here  
            //  
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                Driver.Log.WriteLine("Failed Step: " + TestContext.CurrentContext.Test.FullName);
                Driver.Log.CaptureBrowser(Browser, TestContext.CurrentContext.Test.FullName);
            }

        }
        #endregion

    }

}
