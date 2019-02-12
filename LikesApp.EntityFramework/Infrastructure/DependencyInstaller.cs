using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LikesApp.EntityFrameworkCore.Repositories.PageLikes;

namespace LikesApp.EntityFrameworkCore.Infrastructure
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPageLikesRepository>().ImplementedBy<PageLikesRepository>().LifeStyle.Transient);

            container.Register(Component.For<LikesDbContext>().ImplementedBy<LikesDbContext>().LifeStyle.PerThread);
        }
    }
}
