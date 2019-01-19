using Filed.PaymentService.Web.ApiServices.Gateways;
using Filed.PaymentService.Web.ApiServices.Utilities;
using System;

namespace Filed.PaymentService.Web.ApiServices.PaymentLinks
{
    public class IsExpensivePaymentRule : PaymentRule
    {
        public override IGateway Execute(decimal ammount)
        {
            IGateway gateway;

            if (ammount > 21 && ammount < 500)
            {
                gateway = RandomlyReturnInstanceOrNull<ExpensivePaymentGateway>();
                if (gateway == null)
                {
                    gateway = RetryMechanism.Do(RandomlyReturnInstanceOrNull<CheapPaymentGateway>, TimeSpan.FromSeconds(1), 1);
                }

                return gateway;
            }

            return base.Execute(ammount);
        }
    }
}