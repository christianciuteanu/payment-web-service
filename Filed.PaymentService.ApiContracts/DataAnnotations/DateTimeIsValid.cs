using System;
using System.ComponentModel.DataAnnotations;

namespace Filed.PaymentService.Web.ApiContracts.DataAnnotations
{
    public class DateTimeIsValid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Convert.ToDateTime(value) >= DateTime.Now;
        }
    }
}