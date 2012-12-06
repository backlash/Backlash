using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;

namespace rb.Framework.Backlash.Common.Base
{
    public abstract class FrameworkModule : IModule
    {
        #region Member Variables
        protected readonly IUnityContainer container;
        protected readonly IRegionManager regionManager;
        #endregion

        #region Ctr
        public FrameworkModule(IUnityContainer _container, IRegionManager _regionManager)
        {
            #region Pre-conditions
            Contract.Requires(_container != null);
            Contract.Requires(_regionManager != null);
            #endregion

            this.container = _container;
            this.regionManager = _regionManager;
        }
        #endregion

        #region Public Methods

        #endregion

        #region Protected Methods
        protected abstract void Register();
        #endregion

        #region Private Methods

        #endregion

        #region Properties

        #endregion

        #region IModule Members
        public void Initialize()
        {
            Register();
        }
        #endregion
    }
}
