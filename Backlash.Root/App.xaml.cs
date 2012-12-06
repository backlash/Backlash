using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Backlash.Root
{
    public partial class App : Application
    {
        #region Ctr
        public App()
            : base()
        {
            SubscribeToEvents();
        }
        #endregion

        #region Overrides
        protected override void OnStartup(StartupEventArgs e)
        {
            PreventBlendFromAddingStartupUri();

#if (DEBUG)
            RunInDebug(e);
#else
            RunInRelease(e);
#endif

        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private void SubscribeToEvents()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void RunInDebug(StartupEventArgs _args)
        {

        }

        private void RunInRelease(StartupEventArgs _args)
        {

        }

        private void PreventBlendFromAddingStartupUri()
        {
            Type type = typeof(Application);
            FieldInfo info = type.GetField("_startupUri", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (info != null)
            {
                info.SetValue(this, null);
            }
        }
        #endregion

        #region Event Methods
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            
        }
        #endregion
    }
}
