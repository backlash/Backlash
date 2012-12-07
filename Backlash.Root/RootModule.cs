using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using rb.Framework.Backlash.Common.Base;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using rb.Framework.Backlash.Root.Shell;
using rb.Framework.Backlash.Root.Splash;
using rb.Framework.Backlash.Root.Splash.Events;
using rb.Framework.Backlash.Root.Splash.Factories;

namespace rb.Framework.Backlash.Root
{
    public sealed class RootModule : FrameworkModule
    {
        #region Member Variables

        #endregion

        #region Ctr
        public RootModule(IUnityContainer _container, IRegionManager _regionManager)
            : base(_container, _regionManager)
        {

        }
        #endregion

        #region Overrides
        protected override void Register()
        {
            try
            {
                #region plumbing
                this.container.RegisterType<CloseSplashView>();
                this.container.RegisterType<UpdateSplashViewStatus>();
                #endregion

                #region factories
                this.container.RegisterType<ISplashFactory, SplashFactory>();
                #endregion

                #region models

                #endregion

                #region view models
                this.container.RegisterType<SplashView>();
                this.container.RegisterType<ShellViewModel>();                
                #endregion

                #region views
                this.container.RegisterType<SplashViewModel>();
                this.container.RegisterType<ShellView>();
                #endregion
            }
            catch
            {

            }
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Properties

        #endregion
    }
}
