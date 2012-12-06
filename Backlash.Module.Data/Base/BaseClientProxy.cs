using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using rb.Framework.Backlash.Common.Interfaces;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace rb.Framework.Backlash.Module.Data.Base
{
    public abstract class BaseClientProxy<T> : IDisposable where T : class
    {
        #region Member Variables
        private readonly ISandbox sandbox;
        private readonly Binding binding;
        private readonly EndpointAddress endpoint;
        private readonly object syncroot;
        protected IChannelFactory<T> channelFactory;
        protected T channel;
        private bool isDisposed;
        #endregion

        #region Ctr
        public BaseClientProxy(ISandbox _sandbox, Binding _binding, EndpointAddress _endpoint)
        {
            #region Pre-conditions
            Contract.Requires(_sandbox != null);
            Contract.Requires(_binding != null);
            Contract.Requires(_endpoint != null);
            #endregion

            this.sandbox = _sandbox;
            this.syncroot = new object();
            this.binding = _binding;
            this.endpoint = _endpoint;

            Initialize();
        }

        ~BaseClientProxy()
        {
            Dispose(false);
        }
        #endregion

        #region Public Methods

        #endregion

        #region Protected Methods
        protected void CloseChannel()
        {
            if (this.channel != null)
            {
                ((ICommunicationObject)this.channel).Close();
            }
        }

        protected virtual void Dispose(bool _isDisposing)
        {
            if (this.isDisposed == false)
            {
                if (_isDisposing == true)
                {
                    lock (this.syncroot)
                    {
                        CloseChannel();
                        if (this.channelFactory != null)
                        {
                            ((IDisposable)this.channel).Dispose();
                        }

                        this.channel = null;
                        this.channelFactory = null;
                    }
                }

                this.isDisposed = true;
            }
        }
        #endregion

        #region Private Methods
        private void Initialize()
        {
            lock (this.syncroot)
            {
                if (this.channel == null)
                {
                    this.channelFactory = new ChannelFactory<T>(this.binding);
                    this.channel = this.channelFactory.CreateChannel(this.endpoint);
                }
            }
        }
        #endregion

        #region Properties
        protected T Channel
        {
            get
            {
                return this.channel;
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
