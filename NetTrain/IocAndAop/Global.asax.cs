using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using IocAndAop.Core;
using System.Reflection;
using System.Web;
using System.Web.Caching;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
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

            //config



            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpRuntime.Cache.Insert("Cache1", "This is Cache1.", null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        private void SetupResolverRules(ContainerBuilder builder)
        {
            //builder.RegisterType<OutlookEmail>().As<iSendEmail>().AsSelf();
            //builder.RegisterType<QqEmail>().As<iSendEmail>().AsSelf();

            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Email"))
                   .AsImplementedInterfaces().AsSelf();

            //Assembly.GetCallingAssembly().me

            log4net.Config.XmlConfigurator.Configure();
            builder.RegisterModule(new LoggingModule());
            //builder.Register(c => LogManager.GetLogger(typeof(Object))).As<ILog>();
        }
    }
}
