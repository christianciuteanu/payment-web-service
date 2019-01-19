using Filed.PaymentService.Web.ApiContracts.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Filed.PaymentService.Web.ApiContracts.Payment
{
    public class PaymentRequestData
    {
        [Required(ErrorMessage = "Credit card number is required.")]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Card holder required.")]
        [StringLength(60, ErrorMessage = "Card holder max length is 60.")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        [DateTimeIsValid(ErrorMessage = "Invalid expiration date.")]
        public DateTime ExpirationDate { get; set; }

        [MinLength(3, ErrorMessage = "Security code must be three digits.")]
        [MaxLength(3, ErrorMessage = "Security code must be three digits.")]
        [Required(ErrorMessage = "Security code is required.")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.0, double.PositiveInfinity)]
        public decimal Amount { get; set; }
    }
}
