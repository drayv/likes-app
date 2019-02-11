using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LikesApp.Startup))]
namespace LikesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
