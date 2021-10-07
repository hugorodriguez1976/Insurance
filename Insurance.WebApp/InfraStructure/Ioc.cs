using Insurance.WebApp.Repository;
using Ninject;
using System.Reflection;

namespace Insurance.WebApp.InfraStructure
{
    public class Ioc
    {
        public void LoadModules()
        {
            StandardKernel _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            _kernel.Bind<IOccupationRepository>().To<OccupationRepository>();
            _kernel.Bind<IRatingRepository>().To<RatingRepository>();
        }
    }
}