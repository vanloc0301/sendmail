using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SendMailMVC.Startup))]
namespace SendMailMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
