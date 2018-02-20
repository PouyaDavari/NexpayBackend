using NextpayBackend.Data.DAL;
using System.Web.Http;

namespace NexpayBackend.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        //Dependency injection
        private IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            this._paymentRepository = paymentRepository;
        }

        // Create Payment
        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post([FromBody]NextpayBackend.Data.Models.Payment payment)
        {
            if (payment == null)
                return BadRequest();

            var result = _paymentRepository.Add(payment);

            if(result)
                _paymentRepository.LogPayment(payment);            
            else
                return InternalServerError();
                       
            return Created("", payment);
        }
    }
}
