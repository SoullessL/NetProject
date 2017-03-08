using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using IocAndAop.Core;
using System.Reflection;

namespace IocAndAop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // autofac
            var builder = new ContainerBuilder();
            SetupResolverRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void SetupResolverRules(ContainerBuilder builder)
        {
            builder.RegisterType<OutlookEmail>().As<iSendEmail>();
        }
    }
}
