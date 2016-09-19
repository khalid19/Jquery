using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JqueryAjaxJsonCharja.Solution.Web.Startup))]
namespace JqueryAjaxJsonCharja.Solution.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
