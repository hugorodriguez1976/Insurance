using Insurance.Model;
using Insurance.WebApp.Controllers;
using Insurance.WebApp.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Insurance.WebAppTest
{
    [TestClass]
    public class RatingControllerTest
    {
        private Mock<IRatingRepository> _mockRatingRepository;
        private RatingController controller;

        [SetUp]
        public void Setup()
        {
            var testRatingData = new List<Rating>() {
                new Rating() {  Id= 1, Description="Rating 1"},
                new Rating() {  Id= 2, Description="Rating 2"},
                new Rating() {  Id= 3, Description="Rating 3"},
                new Rating() {  Id= 4, Description="Rating 4"},
                new Rating() {  Id= 5, Description="Rating 5"}
                };

            _mockRatingRepository = new Mock<IRatingRepository>();
            _mockRatingRepository.Setup(m => m.GetAll()).Returns(testRatingData);
            _mockRatingRepository.Setup(m => m.GetById(2)).Returns(testRatingData[1]);

            controller = new RatingController(_mockRatingRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }

        [Test]
        public void GetAllTest()
        {
            IHttpActionResult getallMethodResponse = controller.GetAll();
            var contentResult = getallMethodResponse as OkNegotiatedContentResult<List<Rating>>;
         
            // Assert
            NUnit.Framework.Assert.IsNotNull(contentResult, "Result Content cant be null");
            NUnit.Framework.Assert.IsNotNull(contentResult.Content, "Result Content cant be null");
            NUnit.Framework.Assert.AreEqual(5, contentResult.Content.Count,"There should be 5 elements");

        }

        [Test]
        public void GetByIdTest()
        {
            IHttpActionResult getByIdMethodResponse = controller.GetById(2);
            var contentResult = getByIdMethodResponse as OkNegotiatedContentResult<Rating>;

            // Assert
            NUnit.Framework.Assert.IsNotNull(contentResult, "Result Content cant be null");
            NUnit.Framework.Assert.IsNotNull(contentResult.Content, "Result Content cant be null");
            NUnit.Framework.Assert.AreEqual(2, contentResult.Content.Id, "Rating is invalid");
            NUnit.Framework.Assert.AreEqual("Rating 2", contentResult.Content.Description, "Rating Description is invalid");
        }

    }
}