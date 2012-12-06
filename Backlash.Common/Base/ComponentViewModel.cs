using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Prism.ViewModel;
using rb.Framework.Backlash.Common.Interfaces;
using System.Runtime.CompilerServices;

namespace rb.Framework.Backlash.Common.Base
{
    public abstract class ComponentViewModel : NotificationObject, IComponentViewModel, IDisposable
    {
        #region Member Variables
        protected readonly ISandbox sandbox;
        protected readonly IFrameworkFacade frameworkFacade;
        #endregion

        #region Ctr
        public ComponentViewModel(ISandbox _sandbox, IFrameworkFacade _frameworkFacade)
        {
            #region Pre-conditions
            Contract.Requires(_sandbox != null);
            Contract.Requires(_frameworkFacade != null);
            #endregion

            this.sandbox = _sandbox;
            this.frameworkFacade = _frameworkFacade;
        }
        #endregion

        #region Overrides
        protected override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
        }
        #endregion

        #region Public Methods

        #endregion

        #region Protected Methods
        protected abstract void Dispose(bool _isDisposing);
        #endregion

        #region Private Methods

        #endregion

        #region Properties

        #endregion

        #region IComponentViewModel Members
        public ISandbox Sandbox
        {
            get
            {
                return this.sandbox;
            }
        }

        public IFrameworkFacade FrameworkFacade
        {
            get
            {
                return this.frameworkFacade;
            }
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
