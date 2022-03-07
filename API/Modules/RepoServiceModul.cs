using Autofac;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Repository;
using Repository.Repositories;
using Repository.UnitOfWorks;
using Service.Mapping;
using Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace API.Modules
{
    public class RepoServiceModul:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //GenericRepo
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            //GenericService
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            //Normal NotGenericUnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOFWork>();



            //First Take Assembly
            var apiAssembly = Assembly.GetExecutingAssembly();

            //AppDbContext Data always member
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            //Service 
            var serviceAssembly =Assembly.GetAssembly(typeof(MapProfile));


            //Repo Take

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //InstancePerLifetimeScope => Scope(AspNetCore)
            //InstancePerDependency => Transient

            //Service take
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();



        }
    }
}
