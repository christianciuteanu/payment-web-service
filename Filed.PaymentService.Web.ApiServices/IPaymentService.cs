using Filed.PaymentService.Web.ApiContracts.Payment;
using System.Threading.Tasks;

namespace Filed.PaymentService.Web.ApiServices
{
    public interface IPaymentService
    {
        Task ProcessPaymentAsync(PaymentRequestData paymentProcessData);
    }
}
