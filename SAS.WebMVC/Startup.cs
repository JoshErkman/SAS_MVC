using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAS.WebMVC.Startup))]
namespace SAS.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
