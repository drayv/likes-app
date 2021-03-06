﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using LikesApp.Core.PageLikes;

namespace LikesApp.Application.Infrastructure
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(FromAssembly.Named("LikesApp.Core"));

            container.Register(Component.For<IPageLikesManager>().ImplementedBy<PageLikesManager>().LifeStyle.Transient);
        }
    }
}
