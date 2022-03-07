using Autofac;
using Repository;
using Service.Mapping;
using System.Reflection;

namespace API.Modules
{
    public class RepoServiceModul:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //First Take Assembly
            var apiAssembly = Assembly.GetExecutingAssembly();

            //AppDbContext Data always member
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            //Service 
            var serviceAssembly =Assembly.GetAssembly(typeof(MapProfile));



        }
    }
}
