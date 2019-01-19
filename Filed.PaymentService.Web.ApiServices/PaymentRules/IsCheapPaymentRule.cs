using Filed.PaymentService.Web.ApiServices.Gateways;

namespace Filed.PaymentService.Web.ApiServices.PaymentLinks
{
    public class IsCheapPaymentRule : PaymentRule
    {
        public override IGateway Execute(decimal ammount)
        {
            if (ammount < 20)
            {
                return RandomlyReturnInstanceOrNull<CheapPaymentGateway>();
            }

            return base.Execute(ammount);
        }
    }
}