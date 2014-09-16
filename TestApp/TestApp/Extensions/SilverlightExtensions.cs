using System;
using System.Collections.Generic;
using System.Threading;
using ArtOfTest.Common.Exceptions;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace TestApp.Extensions
{
    /// <summary>
    /// Extension methods on the Silverlight App
    /// </summary>
    public static class SilverlightAppExtensions
    {
      
        /// <summary>
        /// Gets the root element.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static FrameworkElement GetRootElement(this SilverlightApp instance)
        {
            return instance.Find.ByName<Grid>("LayoutRoot").Parent();
        }

        /// <summary>
        /// Waits for message to appear.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="message">The message.</param>
        public static void WaitForMessageToAppear(this SilverlightApp instance, string message)
        {
            instance.Find.Strategy = FindStrategy.AlwaysWaitForElementsVisible;
            var tryCount = 0;
            //Get all of the loading messages on the page
            while (tryCount < 3)
            {
                try
                {
                    instance.Find.AllByTextContent("~" + message);
                }
                catch (FindElementException)
                {
                    tryCount++;
                    Thread.Sleep(1000);
                }
            }

        }

        /// <summary>
        /// Tries to find item.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="searchFunction">The search function.</param>
        /// <param name="MaxTryCount">The maximum try count.</param>
        /// <param name="TryInterval">The try interval.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Element can not be found</exception>
        public static FrameworkElement TryFindItem(this SilverlightApp instance, Func<FrameworkElement> searchFunction,
                                                   int MaxTryCount = 5, int TryInterval = 1000)
        {
            var OriginalStrategy = instance.Find.Strategy;
            FrameworkElement element = null;
            var tryCount = 0;
            var blnFound = false;
            while (tryCount < MaxTryCount && !blnFound)
            {
                try
                {
                    var originalStrategy = instance.Find.Strategy;
                    instance.Find.Strategy = FindStrategy.WhenNotVisibleReturnNull;
                    instance.RefreshVisualTrees();
                    element = searchFunction.Invoke();
                    blnFound = true;
                    instance.Find.Strategy = originalStrategy;
                }
                catch (Exception)
                {
                    //do nothing
                }
                finally
                {
                    Thread.Sleep(TryInterval);
                    tryCount++;
                    instance.Find.Strategy = OriginalStrategy;
                }
            }
            if (blnFound)
            {
                return element;
            }
            throw new Exception("Element can not be found");

        }

        /// <summary>
        /// Tries to find item.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="searchFunction">The search function.</param>
        /// <param name="MaxTryCount">The maximum try count.</param>
        /// <param name="TryInterval">The try interval.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Element can not be found</exception>
        public static FrameworkElement TryFindItem(this SilverlightApp instance, Action searchFunction,
                                                   int MaxTryCount = 5, int TryInterval = 1000)
        {
            var OriginalStrategy = instance.Find.Strategy;
            FrameworkElement element = null;
            var tryCount = 0;
            var blnFound = false;
            while (tryCount < MaxTryCount && !blnFound)
            {
                try
                {
                    var originalStrategy = instance.Find.Strategy;
                    instance.Find.Strategy = FindStrategy.WhenNotVisibleReturnElementProxy;
                    instance.RefreshVisualTrees();
                    searchFunction.Invoke();
                    blnFound = true;
                    instance.Find.Strategy = originalStrategy;
                }
                catch (Exception)
                {
                    //do nothing
                }
                finally
                {
                    Thread.Sleep(TryInterval);
                    tryCount++;
                    instance.Find.Strategy = OriginalStrategy;
                }
            }
            if (blnFound)
            {
                return element;
            }
            throw new Exception("Element can not be found");

        }


        /// <summary>
        /// Tries to find item.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="searchFunction">The search function.</param>
        /// <param name="MaxTryCount">The maximum try count.</param>
        /// <param name="TryInterval">The try interval.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Element can not be found</exception>
        public static IList<FrameworkElement> TryFindItem(this SilverlightApp instance,
                                                          Func<IList<FrameworkElement>> searchFunction,
                                                          int MaxTryCount = 5, int TryInterval = 1000)
        {
            var OriginalStrategy = instance.Find.Strategy;
            IList<FrameworkElement> elements = null;
            var tryCount = 0;
            var blnFound = false;
            while (tryCount < MaxTryCount && !blnFound)
            {
                try
                {
                    var originalStrategy = instance.Find.Strategy;
                    instance.Find.Strategy = FindStrategy.WhenNotVisibleThrowException;
                    instance.RefreshVisualTrees();
                    elements = searchFunction.Invoke();
                    blnFound = true;
                    instance.Find.Strategy = originalStrategy;
                }
                catch (Exception)
                {
                    //do nothing
                }
                finally
                {
                    Thread.Sleep(TryInterval);
                    tryCount++;
                }
            }
            if (!blnFound)
            {
                throw new Exception("Element can not be found");
            }
            instance.Find.Strategy = OriginalStrategy;
            return elements;
        }
    }
}