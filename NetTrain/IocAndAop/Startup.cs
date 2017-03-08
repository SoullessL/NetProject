using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IocAndAop.Startup))]
namespace IocAndAop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
