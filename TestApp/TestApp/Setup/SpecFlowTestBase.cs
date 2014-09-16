using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;
using TestApp.Pages;

namespace TestApp.Setup
{
    public class SpecFlowTestBase:TestBase
    {

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        [BeforeScenario]
        public void Navigate()
        {
            Maximize();
            Driver.Browser.NavigateTo(BaseUrl);
            var homePage = new HomePage();
            ScenarioContext.Current.Set(homePage);
        }

        /// <summary>
        /// Runs before each specflow test.
        /// </summary>
        [BeforeTestRun]
        public static void SetUp()
        {
            TestBaseFixtureSetup();
        }

        /// <summary>
        /// Runs afters each scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            CheckFailures();
        }

        [AfterTestRun]
        public static void AfterAllScenarios()
        {
            Driver.Browser.Window.Close();
            ShutDown();
        }
        
        #region cleanup
        /// <summary>
        /// Shut down and cleanup.
        /// </summary>
        public void CheckFailures()
        {
            var imageName = ScenarioContext.Current.ScenarioInfo.Title;
            try
            {
                try
                {
                    string screenshotFile = string.Format("{0}_{1}_{2}.png",
                                                          FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                                                          ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                                                          DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                    if (ScenarioContext.Current.TestError != null)
                        screenshotFile = "FailedTest-" + screenshotFile;
                    var screenshot = Driver.Browser.Window.GetBitmap();
                    var screenshotFilePath = (Driver.Log.LogLocation + "/" + screenshotFile);
                    screenshot.Save(screenshotFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to save snapshot of {0} : {1}", imageName, ex);
                }
                Driver.Log.WriteLine(LogType.Error, "Failed test: " + ScenarioContext.Current.ScenarioInfo.Title);
            }
            catch (Exception e)
            {
                Driver.Log.WriteLine("Error occurred getting screenshot for " + imageName + ": " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        #endregion
    }
    }
}
