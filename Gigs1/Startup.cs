using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gigs1.Startup))]
namespace Gigs1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
