using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kohviautomaat.Startup))]
namespace Kohviautomaat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
