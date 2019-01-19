using System.Threading.Tasks;

namespace Filed.PaymentService.Web.ApiServices
{
    public interface IGatewayFactory
    {
        Task<IGateway> GetPaymentProcessingGatewayAsync(decimal paymentAmount);
    }
}