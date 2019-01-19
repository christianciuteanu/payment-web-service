using Filed.PaymentService.Web.ApiServices.PaymentLinks;
using System;
using System.Threading.Tasks;

namespace Filed.PaymentService.Web.ApiServices.Gateways
{
    public class GatewayFactory : IGatewayFactory
    {
        public async Task<IGateway> GetPaymentProcessingGatewayAsync(decimal paymentAmount)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            var rules = new IsCheapPaymentRule();
            var expensiveRule = new IsExpensivePaymentRule();
            var premiumRule = new IsPremiumPaymentRule();

            rules.SetSuccessor(expensiveRule);
            expensiveRule.SetSuccessor(premiumRule);

            return rules.Execute(paymentAmount);
        }
    }
}