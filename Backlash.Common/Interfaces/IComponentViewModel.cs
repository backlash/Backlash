using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.ComponentModel;

namespace rb.Framework.Backlash.Common.Interfaces
{
    public interface IComponentViewModel : INotifyPropertyChanged
    {
        #region Methods

        #endregion

        #region Properties
        ISandbox Sandbox { get; }
        IFrameworkFacade FrameworkFacade { get; }
        #endregion
    }
}
