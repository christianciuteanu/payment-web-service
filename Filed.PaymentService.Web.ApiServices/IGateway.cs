using System.Threading.Tasks;
using Filed.PaymentService.Web.ApiContracts.Payment;

namespace Filed.PaymentService.Web.ApiServices
{
    public interface IGateway
    {
        Task<bool> ProcessPaymentAsync(PaymentRequestData paymentRequestData);
    }
}