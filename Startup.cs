using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BancosMDacosta.Startup))]
namespace BancosMDacosta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
