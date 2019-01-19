using Filed.PaymentService.Web.ApiServices.Gateways;
using Filed.PaymentService.Web.ApiServices.Utilities;
using System;

namespace Filed.PaymentService.Web.ApiServices.PaymentLinks
{
    public class IsPremiumPaymentRule : PaymentRule
    {
        public override IGateway Execute(decimal ammount)
        {
            IGateway gateway;

            if (ammount > 500)
            {
                gateway = RandomlyReturnInstanceOrNull<PremiumPaymentGateway>();
                if (gateway == null)
                {
                    gateway = RandomlyReturnInstanceOrNull<PremiumPaymentGateway>();
                }

                return gateway;
            }

            return base.Execute(ammount);
        }
    }
}