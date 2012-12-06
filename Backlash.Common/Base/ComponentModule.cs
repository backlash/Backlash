using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using rb.Framework.Backlash.Common.Interfaces;

namespace rb.Framework.Backlash.Common.Base
{
    public abstract class ComponentModule : IModule, IDisposable
    {
        #region Member Variables
        protected readonly IUnityContainer container;
        protected readonly IRegionManager regionManager;
        #endregion

        #region Ctr
        public ComponentModule(IUnityContainer _container, IRegionManager _regionManager)
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
        public abstract IComponentView InstantiateView(string _componentId);
        #endregion

        #region Protected Methods
        protected abstract void RegisterAllComponentObjects();

        protected void RegisterComponent<TView, TViewModel>()
            where TView : class, IComponentView
            where TViewModel : class, IComponentViewModel
        {
            this.container.RegisterType<TViewModel>();
            this.container.RegisterType<TView>();
        }

        protected void RegisterModel<TModel>()
            where TModel : class, IComponentModel
        {
            this.container.RegisterType<TModel>();
        }

        protected void RegisterRegion<TRegionView, TRegionViewModel>(string _regionId)
            where TRegionView : class, IComponentRegion
            where TRegionViewModel : class, IComponentViewModel
        {
            this.container.RegisterType<TRegionViewModel>();
            this.container.RegisterType<TRegionView>();
            this.regionManager.RegisterViewWithRegion(_regionId, () => this.container.Resolve<TRegionView>());
        }

        protected virtual void Dispose(bool _isDisposing)
        {
            if (_isDisposing == true)
            {
                
            }
        }
        #endregion

        #region Private Methods
 
        #endregion

        #region Properties

        #endregion

        #region IModule Members
        public void Initialize()
        {
            RegisterAllComponentObjects();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
