using Insurance.Model;
using Insurance.WebApp.Controllers;
using Insurance.WebApp.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Insurance.WebAppTest
{
    [TestClass]
    public class OccupationControllerTest
    {
        private Mock<IOccupationRepository> _mockOccupationRepository;
        private Mock<IRatingRepository> _mockRatingRepository;
        private OccupationController controller;

        [SetUp]
        public void Setup()
        {
            var testOccupationData = new List<Occupation>() {
                new Occupation() {  Id= 1, Description="Ocupation 1", RatingId=1},
                new Occupation() {  Id= 2, Description="Ocupation 2", RatingId=2},
                new Occupation() {  Id= 3, Description="Ocupation 3", RatingId=3},
                new Occupation() {  Id= 4, Description="Ocupation 4", RatingId=4}
                };

            _mockOccupationRepository = new Mock<IOccupationRepository>();
            _mockOccupationRepository.Setup(m => m.GetAll()).Returns( testOccupationData );
            _mockOccupationRepository.Setup(m => m.GetById(2)).Returns( testOccupationData[1] );

            _mockOccupationRepository.Setup(m => m.CalculatePremium( It.IsAny<Double>() , It.IsAny<int>() , It.IsAny<Double?>())).Returns(500.00);

            _mockRatingRepository = new Mock<IRatingRepository>();

            controller = new OccupationController(_mockOccupationRepository.Object, _mockRatingRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }

        [Test]
        public void GetAllTest()
        {           
            IHttpActionResult getallMethodResponse = controller.GetAll();
            var contentResult = getallMethodResponse as OkNegotiatedContentResult<List<Occupation>>;
         
            // Assert
            NUnit.Framework.Assert.IsNotNull(contentResult, "Result Content cant be null");
            NUnit.Framework.Assert.IsNotNull(contentResult.Content, "Result Content cant be null");
            NUnit.Framework.Assert.AreEqual(4, contentResult.Content.Count,"There should be 4 elements");

        }

        [Test]
        public void GetByIdTest()
        {
            IHttpActionResult getByIdMethodResponse = controller.GetById(2);
            var contentResult = getByIdMethodResponse as OkNegotiatedContentResult<Occupation>;

            // Assert
            NUnit.Framework.Assert.IsNotNull(contentResult, "Result Content cant be null");
            NUnit.Framework.Assert.IsNotNull(contentResult.Content, "Result Content cant be null");
            NUnit.Framework.Assert.AreEqual(2, contentResult.Content.Id, "OccupationId is invalid");
            NUnit.Framework.Assert.AreEqual("Ocupation 2", contentResult.Content.Description, "Occupation Description is invalid");
            NUnit.Framework.Assert.AreNotEqual(999, contentResult.Content.RatingId, "RatingId expect value 1");
        }

        [Test]
        public void CalculatePremiumTest()
        {
            IHttpActionResult getCalculateMethodResponse = controller.CalculatePremium(2 , 1000.00 , 45);
            var contentResult = getCalculateMethodResponse as OkNegotiatedContentResult<Double>;

            // Assert
            NUnit.Framework.Assert.IsNotNull(contentResult, "Premoium amount  cant be null");
            NUnit.Framework.Assert.IsNotNull(contentResult.Content, "premium amount cant be null");
            NUnit.Framework.Assert.AreEqual(500.00 , contentResult.Content, "Premium amount is invalid");
            NUnit.Framework.Assert.AreNotEqual(123.00 , contentResult.Content, "Expected 500 as a premium amount");
        }
    }
}