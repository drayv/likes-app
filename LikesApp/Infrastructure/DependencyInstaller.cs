using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace LikesApp.Infrastructure
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(FromAssembly.Named("LikesApp.Application"));

            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().If(c => c.Name.EndsWith("Controller")).LifestyleTransient());
        }
    }
}
