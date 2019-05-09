using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestCasesDemo.Startup))]
namespace TestCasesDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
