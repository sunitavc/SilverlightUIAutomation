using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.TestTemplates;

namespace TestApp.Setup
{
    /// <summary>
    /// A Driver Factory, could use it to return a fake webaii driver too for Unit Tests
    /// </summary>
    public abstract class DriverFactory : BaseTest
    {
        private static Settings Setting
        {
            get { return GetSettings(); }
        }

        /// <summary>
        /// Gets the WebAii driver.
        /// </summary>
        /// <returns></returns>
        public static WebAiiDriver GetWebAiiDriver()
        {
            var driver = new WebAiiDriver(Setting);
            return driver;
        }

    }
}
