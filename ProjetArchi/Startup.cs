using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetArchi.Startup))]
namespace ProjetArchi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
