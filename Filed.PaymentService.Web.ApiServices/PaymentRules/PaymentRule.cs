using System;
using Filed.PaymentService.Web.ApiServices.Gateways;

namespace Filed.PaymentService.Web.ApiServices.PaymentLinks
{
    public abstract class PaymentRule
    {
        private PaymentRule nextLink;

        public void SetSuccessor(PaymentRule next)
        {
            nextLink = next;
        }

        public virtual IGateway Execute(decimal ammount)
        {
            if (nextLink != null)
            {
                return nextLink.Execute(ammount);
            }
            return null;
        }

        protected T RandomlyReturnInstanceOrNull<T>() where T : new()
        {
            dynamic result = new T();

            Random gen = new Random();
            int prob = gen.Next(100);

            return prob <= 20 ? (T)result : default(T);
        }
    }
}