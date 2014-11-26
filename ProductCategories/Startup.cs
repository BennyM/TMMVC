using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductCategories.Startup))]
namespace ProductCategories
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
