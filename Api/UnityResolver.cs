using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace Api
{
    /// <summary>
    /// 
    /// </summary>
    public class UnityResolver : IDependencyResolver
    {
        /// <summary>
        /// 
        /// </summary>
        protected IUnityContainer container;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            container.Dispose();
        }

    }
}