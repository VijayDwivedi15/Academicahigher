using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EducationSite.Startup))]
namespace EducationSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
