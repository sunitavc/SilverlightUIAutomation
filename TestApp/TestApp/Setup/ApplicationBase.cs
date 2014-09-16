using ArtOfTest.WebAii.Silverlight;

namespace TestApp.Setup
{
    /// <summary>
    /// A wrapper to the current Silverlight App
    /// If you're wondering why this wasn't part of the TestBase then think of a situation
    /// when the landing page of the application is a HTML page
    /// And your TestBase tried to find a SilverlightApps()[0]
    /// It would fail because at that time the Silverlight plugin did not contain any silverlight app
    /// Abstracting ApplicationBase outside of TestBase allows the tester to use this as a BasePage for only Silverlight apps
    /// and have maybe another base page for a html page.
    /// </summary>
    public class ApplicationBase : TestBase
    {
        /// <summary>
        /// Gets the current Silverlight Application.
        /// </summary>
        /// <value>
        /// The current silverlight application.
        /// </value>
        public SilverlightApp Application { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBase"/> class.
        /// </summary>
        public ApplicationBase()
        {
            Application = Driver.Browser.SilverlightApps()[0];
        }
    }
}
