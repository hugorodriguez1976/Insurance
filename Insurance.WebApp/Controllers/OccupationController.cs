using Insurance.Model;
using Insurance.WebApp.Repository;
using Ninject;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;

namespace Insurance.WebApp.Controllers
{
    public class OccupationController : ApiController
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly IRatingRepository _ratingRepository;

        public OccupationController(IOccupationRepository occupationRepository, IRatingRepository ratingRepository)
        {
            _occupationRepository = occupationRepository;
            _ratingRepository = ratingRepository;
        }

        [Route("api/occupation/getall")]
        [HttpGet]
        [ResponseType(typeof(List<Occupation>))]
        public IHttpActionResult GetAll()
        {
            var occupationItems = _occupationRepository.GetAll();
            return Ok(occupationItems);
        }

        [Route("api/occupation/{id}")]
        [HttpGet]
        [ResponseType(typeof(Occupation))]
        public IHttpActionResult GetById(int id)
        {
            var occupationItem = _occupationRepository.GetById(id);
            return Ok(occupationItem);
        }

        [Route("api/occupation/calculatepremium")]
        [HttpGet]
        [ResponseType(typeof(double))]
        public IHttpActionResult CalculatePremium(int OccupationId, double Amount, int Age)
        {
            double premium = 0.00;
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
