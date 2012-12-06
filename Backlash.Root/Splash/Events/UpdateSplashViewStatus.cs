using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Prism.Events;

namespace rb.Framework.Backlash.Root.Splash.Events
{
    internal class UpdateSplashViewStatus : CompositePresentationEvent<UpdateSplashViewStatus>
    {
        #region Member Variables
        protected string status;
        #endregion

        #region Ctr
        public UpdateSplashViewStatus()
        {

        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

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
                this.status = value;
            }
        }
        #endregion
    }
}
