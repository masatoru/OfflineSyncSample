using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OfflineBackendSample.Startup))]

namespace OfflineBackendSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}