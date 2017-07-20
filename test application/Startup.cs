using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(test_application.Startup))]
namespace test_application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
