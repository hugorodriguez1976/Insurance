using Insurance.WebApp.Repository;
using Ninject.Modules;

namespace Insurance.WebApp.InfraStructure
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IOccupationRepository>().To<OccupationRepository>();
            this.Bind<IRatingRepository>().To<RatingRepository>();
        }
    }
}