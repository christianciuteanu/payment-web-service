using System.Threading.Tasks;
using Filed.PaymentService.Web.ApiContracts.Payment;
using Filed.PaymentService.Web.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Filed.PaymentService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("processPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestData model)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            await _paymentService.ProcessPaymentAsync(model); 
            
            return Ok();
        }
    }
}
