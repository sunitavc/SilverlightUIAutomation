using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Silverlight;

namespace TestApp.Extensions
{
    public static class FrameworkElementExtensions
    {
        /// <summary>
        /// Gets the automation property of type TResult and name propertyName.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static TResult Get<TResult>(this FrameworkElement instance, string propertyName)
        {
            var property = new AutomationProperty(propertyName, typeof(TResult));
            return (TResult)instance.GetProperty(property);
        }

        /// <summary>
        /// Clicks the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="System.Exception"></exception>
        public static void Click(this FrameworkElement element)
        {
            var app = (SilverlightApp)element.Host;
            app.Find.Strategy = FindStrategy.AlwaysWaitForElementsVisible;
            app.RefreshVisualTrees();
            element.ScrollToVisible();
            try
            {
                element.User.Click();
            }
            catch
            {
                throw new Exception(string.Format("Element {0} can not be clicked or found", element));
            }

        }
    }
}
