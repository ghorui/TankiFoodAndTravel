using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TankiFoodAndTravel.Startup))]
namespace TankiFoodAndTravel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
