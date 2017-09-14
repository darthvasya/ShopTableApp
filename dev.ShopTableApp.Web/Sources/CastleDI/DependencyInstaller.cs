using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using dev.ShopTableApp.DataAccess.Pub.Contracts;
using dev.ShopTableApp.DataAccess.Pub.Implementations;
using static Castle.MicroKernel.Registration.AllTypes;

namespace dev.ShopTableApp.Web.CastleDI
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store) => container.Register(
                //Component.For<ILogService>()
                //    .ImplementedBy<LogService>()
                //    .LifeStyle.PerWebRequest,

                Component.For<IDatabaseFactory>()
                    .ImplementedBy<DatabaseFactory>()
                    .LifeStyle.PerWebRequest,

                Component.For<IUnitOfWork>()
                    .ImplementedBy<UnitOfWork>()
                    .LifeStyle.PerWebRequest,

                FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

                FromAssemblyNamed("dev.ShopTableApp.BusinessLogic")
                    .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces().LifestylePerWebRequest(),

                FromAssemblyNamed("dev.ShopTableApp.DataAccess.Repository")
                    .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces().LifestylePerWebRequest()
            );
    }
}