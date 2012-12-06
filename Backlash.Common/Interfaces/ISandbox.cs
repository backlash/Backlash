using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace rb.Framework.Backlash.Common.Interfaces
{
    public interface ISandbox
    {
        #region Methods

        #endregion

        #region Properties
        IUnityContainer UnityContainer { get; }
        IRegionManager RegionManager { get; }
        #endregion
    }
}
