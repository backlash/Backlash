using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Prism.ViewModel;
using System.Runtime.CompilerServices;

namespace rb.Framework.Backlash.Common.Base
{
    public abstract class FrameworkViewModel : NotificationObject, IDisposable
    {
        #region Member Variables

        #endregion

        #region Ctr
        public FrameworkViewModel()
        {

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

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
