using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Prism.Events;
using rb.Framework.Backlash.Common.Base;
using rb.Framework.Backlash.Root.Splash.Events;

namespace rb.Framework.Backlash.Root.Splash
{
    internal sealed class SplashViewModel : FrameworkViewModel
    {
        #region Member Variables
        private readonly IEventAggregator eventAggregator;
        private string status;
        #endregion

        #region Ctr
        public SplashViewModel(IEventAggregator _eventAggregator)
        {
            #region Pre-conditions
            Contract.Requires(_eventAggregator != null);
            #endregion

            this.eventAggregator = _eventAggregator;

            Initialize();
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool _isDisposing)
        {
            if (_isDisposing == true)
            {

            }
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private void Initialize()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            #region Pre-conditions
            Contract.Assume(this.eventAggregator != null);
            #endregion

            this.eventAggregator.GetEvent<UpdateSplashViewStatus>().Subscribe(x => UpdateStatus(x));
        }

        private void UpdateStatus(UpdateSplashViewStatus _status)
        {
            #region Pre-conditions
            Contract.Assume(_status != null);
            #endregion
        }
        #endregion

        #region Properties
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                if (this.status != value)
                {
                    this.status = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
}
