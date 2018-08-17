using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RescueNeeds.Startup))]
namespace RescueNeeds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
