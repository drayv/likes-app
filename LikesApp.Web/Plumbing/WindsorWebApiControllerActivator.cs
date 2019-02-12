using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace LikesApp.Plumbing
{
    public class WindsorWebApiControllerActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorWebApiControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)this._container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(
                    () => this._container.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }
    }
}
