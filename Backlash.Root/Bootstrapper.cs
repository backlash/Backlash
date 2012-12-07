using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Backlash.Module.Communication;
using rb.Framework.Backlash.Module.Data;
using rb.Framework.Backlash.Module.UI;

namespace rb.Framework.Backlash.Root
{
    internal sealed class Bootstrapper : UnityBootstrapper
    {
        #region Member Variables
        private readonly StartupEventArgs startupArgs;
        #endregion

        #region Ctr
        public Bootstrapper(StartupEventArgs _cmdLineArgs)
        {
            #region Pre-conditions
            Contract.Requires(_cmdLineArgs != null);
            #endregion

            this.startupArgs = _cmdLineArgs;
        }
        #endregion

        #region Overrides
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            (this.ModuleCatalog as ModuleCatalog).AddModule(typeof(RootModule));
            (this.ModuleCatalog as ModuleCatalog).AddModule(typeof(CommunicationModule));
            (this.ModuleCatalog as ModuleCatalog).AddModule(typeof(DataModule));
            (this.ModuleCatalog as ModuleCatalog).AddModule(typeof(UIModule));
        }

        protected override IUnityContainer CreateContainer()
        {
            return base.CreateContainer();
        }

        protected override DependencyObject CreateShell()
        {
            throw new NotImplementedException();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
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
