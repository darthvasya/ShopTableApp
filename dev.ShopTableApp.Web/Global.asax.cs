using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using dev.ShopTableApp.Web.CastleDI;

namespace dev.ShopTableApp.Web
{
    public class WebApiApplication : HttpApplication
    {
        private readonly IWindsorContainer _container;

        public WebApiApplication()
        {
            _container =
                new WindsorContainer().Install(new DependencyInstaller());
        }

        public override void Dispose()
        {
            _container.Dispose();
            base.Dispose();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorActivator(_container));
        }
    }
}