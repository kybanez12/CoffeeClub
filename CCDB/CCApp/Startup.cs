using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCApp.Startup))]
namespace CCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
