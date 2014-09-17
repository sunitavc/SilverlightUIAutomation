using System;
using Should.Fluent;
using TechTalk.SpecFlow;
using TestApp.Pages;

namespace TestApp.StepDefinitions
{
    /// <summary>
    /// Step Definitions, the code behind for the gherkin in the SpecFlow features
    /// TIP: When you create a new StepDefinition class, don't forget to put the [Binding] metadata tag
    /// decorator on top of the class. Otherwise SpecFlow will not "collect" it.
    /// </summary>
    [Binding]
    public class SanitySteps
    {
        //TIP: Use StepDefinition instesd of When/Then/And so it shows up always in the intellisense
        [StepDefinition(@"I am on the Welcome page")]
        public void GivenIAmOnTheWelcomePage()
        {
            //HomePage was stored in the Scenario Context at the SpecFlowTestBase
            var homepage = ScenarioContext.Current.Get<HomePage>();
            homepage.MainMenu().OpenWelcomePage();
        }
        
        [When(@"I interact with the checkbox on the Visual Binding Page")]
        public void WhenIInteractWithTheCheckboxOnTheVisualBindingPage()
        {
            var homepage = ScenarioContext.Current.Get<HomePage>();
            var visualSamples = homepage.MainMenu().OpenVisualSamplesPage();
            //TIP: Use the Scenario Context dictionary to hold the instance of pages etc for sharing across steps
            ScenarioContext.Current.Set(visualSamples);
            visualSamples.Uncheck();
        }
        
        [Then(@"the checkbox should recieve my input")]
        public void ThenTheCheckboxShouldRecieveMyInput()
        {
            var visualSamples = ScenarioContext.Current.Get<VisualSamplePage>();
            //TIP: Install-Package ShouldFluent to get "Should" assertions. There are more Fluent Assertions in nuget, can use any
            visualSamples.IsChecked().Should().Be.False();
        }
    }
}
