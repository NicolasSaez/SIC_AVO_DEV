using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIC_AVO_DEV.Startup))]
namespace SIC_AVO_DEV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
