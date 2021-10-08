﻿using Insurance.WebApp.Repository;
using Ninject;
using System.Reflection;
using System.Web.Http;

namespace Insurance.WebApp.Controllers
{
    public class RatingController : ApiController
    {
        private readonly IRatingRepository _ratingRepository;

        //todo: to fix issue with DI
        public RatingController()
        {
            StandardKernel _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            _ratingRepository = _kernel.Get<IRatingRepository>();
        }
        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [Route("api/rating/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var ratingItems = _ratingRepository.GetAll();
            return Ok(ratingItems);
        }

        [Route("api/rating/{id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var ratingItem = _ratingRepository.GetById(id);
            return Ok(ratingItem);
        }

    }
}
