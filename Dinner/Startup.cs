using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dinner.Startup))]
namespace Dinner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
