using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BakeCake.Startup))]
namespace BakeCake
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
