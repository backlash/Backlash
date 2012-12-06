using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace rb.Framework.Backlash.Root.Splash
{
    internal partial class SplashView : Window
    {
        #region Ctr
        public SplashView(SplashViewModel _viewmodel)
        {
            #region Pre-conditions
            Contract.Requires(_viewmodel != null);
            #endregion

            InitializeComponent();

            DataContext = _viewmodel;
        }
        #endregion
    }
}
