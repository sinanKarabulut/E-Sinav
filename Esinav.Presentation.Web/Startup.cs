using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Esinav.Presentation.Web.Startup))]
namespace Esinav.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
