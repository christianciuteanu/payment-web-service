using System;
using Filed.PaymentService.Web.ApiContracts.Payment;
using Filed.PaymentService.Web.ApiServices;
using Filed.PaymentService.Web.ApiServices.Payments;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private IPaymentService _mockPaymentService;
        private Mock<IGatewayFactory> _mockGatewayFactory;

        [SetUp]
        public void Setup()
        {
            _mockGatewayFactory = new Mock<IGatewayFactory>();
            _mockPaymentService = new PaymentService(_mockGatewayFactory.Object);
        }

        [Test]
        public void TestProcessingCheap()
        {
            var reqData = new PaymentRequestData
            {
                CreditCardNumber = "4556394887258090",
                CardHolder = "Client",
                ExpirationDate = new DateTime(2019, 5, 10),
                SecurityCode = "123",
                Amount = 19
            };

            Assert.DoesNotThrow(() => _mockPaymentService.ProcessPaymentAsync(reqData));
        }

        [Test]
        public void TestProcessingExpensive()
        {
            var reqData = new PaymentRequestData
            {
                CreditCardNumber = "4556394887258090",
                CardHolder = "Client",
                ExpirationDate = new DateTime(2019, 5, 10),
                SecurityCode = "123",
                Amount = 400
            };

            Assert.DoesNotThrow(() => _mockPaymentService.ProcessPaymentAsync(reqData));
        }

        [Test]
        public void TestProcessingPremium()
        {
            var reqData = new PaymentRequestData
            {
                CreditCardNumber = "4556394887258090",
                CardHolder = "Client",
                ExpirationDate = new DateTime(2019, 5, 10),
                SecurityCode = "123",
                Amount = 521
            };

            Assert.DoesNotThrow(() => _mockPaymentService.ProcessPaymentAsync(reqData));
        }
    }
}