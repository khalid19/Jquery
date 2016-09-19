using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharjsaSolution.ERP365.Web.Startup))]
namespace CharjsaSolution.ERP365.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
