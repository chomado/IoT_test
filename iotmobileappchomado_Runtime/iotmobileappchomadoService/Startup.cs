using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(iotmobileappchomadoService.Startup))]

namespace iotmobileappchomadoService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}