using Insurance.WebApp.InfraStructure;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Insurance.WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            this.LoadModules();
        }

        private void LoadModules()
        {
          //  new Insurance.WebApp.InfraStructure.NinjectBindings().Load();
            //new Insurance.WebApp.InfraStructure.Ioc().LoadModules();
            // new Debtrak.Core.BusinessLibrary.IocRegister.IocRegister().LoadCore();
        }
    }
}
