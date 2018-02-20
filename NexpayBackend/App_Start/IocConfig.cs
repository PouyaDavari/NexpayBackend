using Autofac;
using Autofac.Integration.WebApi;
using NextpayBackend.Data.DAL;
using System.Reflection;
using System.Web.Http;

namespace NexpayBackend.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            // Autofac configurations
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>().InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}