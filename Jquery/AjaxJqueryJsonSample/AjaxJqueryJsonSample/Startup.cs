using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxJqueryJsonSample.Startup))]
namespace AjaxJqueryJsonSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
