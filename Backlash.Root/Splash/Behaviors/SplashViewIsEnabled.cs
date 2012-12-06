using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Windows;

namespace rb.Framework.Backlash.Root.Splash.Behaviors
{
    public class SplashViewIsEnabled
    {
        #region Member Variables

        #endregion

        #region Ctr
        public SplashViewIsEnabled()
        {

        }
        #endregion

        #region Public Methods
        public static bool GetIsEnabled(DependencyObject _dependencyObject)
        {
            return (bool)_dependencyObject.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject _dependencyObject, bool _newValue)
        {
            _dependencyObject.SetValue(IsEnabledProperty, _newValue);
        }
        #endregion

        #region Private Methods

        #endregion

        #region Event Methods
        private static void OnIsEnabledPropertyChanged(DependencyObject _dependencyObject, DependencyPropertyChangedEventArgs _args)
        {
            Window splashview = _dependencyObject as Window;
            if (splashview != null)
            {
                if (_args.NewValue is bool)
                {
                    if ((bool)_args.NewValue == true)
                    {
                        splashview.Closed += (sender, e) =>
                            {
                                splashview.DataContext = null;
                                splashview.Dispatcher.InvokeShutdown();
                            };
                        splashview.MouseDoubleClick += (sender, e) => splashview.Close();
                        splashview.MouseLeftButtonDown += (sender, e) => splashview.DragMove();
                    }
                }
            }
        }
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(SplashViewIsEnabled), new PropertyMetadata(OnIsEnabledPropertyChanged));
        #endregion

        #region Properties

        #endregion
    }
}
