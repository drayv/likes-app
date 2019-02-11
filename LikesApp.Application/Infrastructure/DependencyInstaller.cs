using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LikesApp.Application.PageLikes;

namespace LikesApp.Application.Infrastructure
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPageLikesService>().ImplementedBy<PageLikesService>());
        }
    }
}
