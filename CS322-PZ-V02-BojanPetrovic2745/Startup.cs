using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CS322_PZ_V02_BojanPetrovic2745.Startup))]
namespace CS322_PZ_V02_BojanPetrovic2745
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
