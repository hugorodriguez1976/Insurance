using Insurance.WebApp.Repository;
using Ninject;
using System.Reflection;
using System.Web.Http;

namespace Insurance.WebApp.Controllers
{
    public class OccupationController : ApiController
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly IRatingRepository _ratingRepository;

        //todo: to fix issue with DI
        OccupationController()
        {
            StandardKernel _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            _occupationRepository = _kernel.Get<IOccupationRepository>();
            _ratingRepository = _kernel.Get<IRatingRepository>();
        }
        OccupationController(IOccupationRepository occupationRepository, IRatingRepository ratingRepository)
        {
            _occupationRepository = occupationRepository;
            _ratingRepository = ratingRepository;
        }

        [Route("api/occupation/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var occupationItems = _occupationRepository.GetAll();
            return Ok(occupationItems);
        }

        [Route("api/occupation/{id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var occupationItem = _occupationRepository.GetById(id);
            return Ok(occupationItem);
        }

        [Route("api/occupation/calculatepremium")]
        [HttpGet]
        public IHttpActionResult CalculatePremium(int OccupationId, double Amount, int Age)
        {
            double premium = 0L;
            var occupationItem = _occupationRepository.GetById(OccupationId);
            if (occupationItem != null)
            {
                var ratingItem = _ratingRepository.GetById(occupationItem.RatingId);
                premium = _occupationRepository.CalculatePremium(Amount, Age, ratingItem?.Factor);
            }
            return Ok(premium);
        }
    }
}
