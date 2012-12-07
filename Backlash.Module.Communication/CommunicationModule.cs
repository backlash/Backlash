using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using rb.Framework.Backlash.Common.Base;


namespace Backlash.Module.Communication
{
    public sealed class CommunicationModule : FrameworkModule
    {
        #region Member Variables

        #endregion

        #region Ctr
        public CommunicationModule(IUnityContainer _container, IRegionManager _regionManager)
            : base(_container, _regionManager)
        {

        }
        #endregion

        #region Overrides
        protected override void Register()
        {
            try
            {

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
