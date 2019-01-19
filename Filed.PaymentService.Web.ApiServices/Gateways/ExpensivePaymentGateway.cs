using System;
using System.Threading.Tasks;
using Filed.PaymentService.Web.ApiContracts.Payment;

namespace Filed.PaymentService.Web.ApiServices.Gateways
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public async Task<bool> ProcessPaymentAsync(PaymentRequestData paymentRequestData)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            return true;
        }
    }
}