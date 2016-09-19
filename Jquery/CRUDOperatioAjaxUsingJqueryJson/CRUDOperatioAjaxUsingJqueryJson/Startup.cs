using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDOperatioAjaxUsingJqueryJson.Startup))]
namespace CRUDOperatioAjaxUsingJqueryJson
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
