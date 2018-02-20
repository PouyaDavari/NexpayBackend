using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NexpayBackend.Controllers;
using NextpayBackend.Data.DAL;
using NextpayBackend.Data.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace NexpayBackend.Tests.Controllers
{
    [TestClass]
    class PaymentControllerTests
    {
        [TestMethod]
        public void Post_Returns_SamePayment()
        {
            // Arrange
            Payment NewPayment = new Payment
            {
                Bsb = "123-456",
                accountName = "Pooya Davari",
                AccountNumber = "123456789",
                Amount = 100,
                Reference = "Ref"
            };

            var mockRepository = new Mock<IPaymentRepository>();
            mockRepository.Setup(x => x.Add(NewPayment))
                .Returns(true);

            var controller = new PaymentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Post(NewPayment);
            var createdResult = actionResult as CreatedNegotiatedContentResult<Payment>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("123-456", createdResult.Content.Bsb);
            Assert.AreEqual(100, createdResult.Content.Amount);
        }

        [TestMethod]
        public void Post_Returns_BadRequest()
        {
            // Arrange
            Payment NewPayment = null;

            var mockRepository = new Mock<IPaymentRepository>();
            mockRepository.Setup(x => x.Add(NewPayment))
                .Returns(true);

            var controller = new PaymentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Post(NewPayment);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }
    }
}
