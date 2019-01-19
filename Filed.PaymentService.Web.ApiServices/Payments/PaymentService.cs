using System.Threading.Tasks;
using Filed.PaymentService.Web.ApiContracts.Payment;

namespace Filed.PaymentService.Web.ApiServices.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IGatewayFactory _gatewayFactory;

        public PaymentService(IGatewayFactory gatewayFactory)
        {
            _gatewayFactory = gatewayFactory;
        }

        public async Task ProcessPaymentAsync(PaymentRequestData paymentProcessData)
        {
            var paymentProcessingGateway = await _gatewayFactory.GetPaymentProcessingGatewayAsync(paymentProcessData.Amount);

            await paymentProcessingGateway?.ProcessPaymentAsync(paymentProcessData);
        }
    }
}
