using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.Windsor;
using Castle.Windsor.Installer;
using LikesApp.Plumbing;

namespace LikesApp.App_Start
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {
        readonly IWindsorContainer container;

        ContainerBootstrapper(IWindsorContainer container)
        {
            this.container = container;
        }

        public IWindsorContainer Container
        {
            get { return container; }
        }

        public static ContainerBootstrapper Bootstrap()
        {
            var container = new WindsorContainer().
                Install(FromAssembly.This());

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorWebApiControllerActivator(container));

            return new ContainerBootstrapper(container);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
