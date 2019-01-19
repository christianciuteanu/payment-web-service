using System;
using System.Data;
using System.Threading.Tasks;
using Filed.PaymentService.Web.ApiContracts.Payment;
using Filed.PaymentService.Web.ApiServices.Utilities;

namespace Filed.PaymentService.Web.ApiServices.Gateways
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public async Task<bool> ProcessPaymentAsync(PaymentRequestData paymentRequestData)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            return RetryMechanism.Do(() =>
            {
                Random gen = new Random();
                int prob = gen.Next(100);
                return prob <= 20 ? true : throw new DataException();
            }, TimeSpan.FromSeconds(1), 3);
        }
    }
}