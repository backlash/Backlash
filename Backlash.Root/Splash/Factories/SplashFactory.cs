using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Events;
using System.Threading;
using rb.Framework.Backlash.Root.Splash.Events;
using System.Windows.Threading;

namespace rb.Framework.Backlash.Root.Splash.Factories
{
    internal interface ISplashFactory : IDisposable
    {
        #region Methods
        void Generate();
        #endregion

        #region Properties

        #endregion
    }

    internal class SplashFactory : ISplashFactory
    {
        #region Member Variables
        protected readonly IUnityContainer container;
        protected readonly IEventAggregator eventAggregator;
        protected AutoResetEvent waitOnCreation;
        #endregion

        #region Ctr
        public SplashFactory(IUnityContainer _container, IEventAggregator _eventAggregator)
        {
            #region Pre-conditions
            Contract.Requires(_container != null);
            Contract.Requires(_eventAggregator != null);
            #endregion

            this.container = _container;
            this.eventAggregator = _eventAggregator;

            this.waitOnCreation = new AutoResetEvent(false);
        }
        #endregion

        #region Public Methods

        #endregion

        #region Protected Methods
        protected virtual void Dispose(bool _isDisposing)
        {
            if (_isDisposing == true)
            {
                this.waitOnCreation.Dispose();
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Properties

        #endregion

        #region ISplashFactory Members
        public void Generate()
        {
            ThreadStart display = () =>
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
                        {
                            SplashView view = this.container.Resolve<SplashView>();
                            this.eventAggregator.GetEvent<CloseSplashView>().Subscribe(x => view.Dispatcher.BeginInvoke((Action)view.Close), ThreadOption.PublisherThread, true);
                            view.Show();
                            this.waitOnCreation.Set();
                        }));
                    Dispatcher.Run();
                };

            Thread thread = new Thread(display) { Name = "Splash Screen Thread", IsBackground = true };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            this.waitOnCreation.WaitOne();
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
