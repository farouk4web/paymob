using Microsoft.AspNetCore.Mvc;
using Paymob.Services.Payment;

namespace Paymob.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        //just for test
        [HttpGet(nameof(GetLink))]
        public async Task<IActionResult> GetLink(decimal a, string u)
        {
            string link = await _paymentService.GetPaymentLinkAsync(a, u);

            return Ok(link);
        }


        //[HttpPost(nameof(PostPaymentCallback))]
        //public async Task<IActionResult> PostPaymentCallback(PaymobCallbackPostModel model)
        //{
        //    if (!model.obj.success)
        //        return Ok();

        //    //string hmacAsString = model.obj.amount_cents.ToString() + model.obj.created_at + model.obj.currency + model.obj.error_occured + model.obj.has_parent_transaction + model.obj.id + model.obj.integration_id + model.obj.is_3d_secure + model.obj.is_auth + model.obj.is_capture + model.obj.is_refunded + model.obj.is_standalone_payment + model.obj.is_voided + model.obj.order.id + model.obj.owner + model.obj.pending + model.obj.source_data.pan + model.obj.source_data.sub_type + model.obj.source_data.type + model.obj.success;
        //    bool result = true;// await _paymobService.ValidateHMACAsync(hmacAsString, model.obj.data.secure_hash.ToString());
        //    if (result)
        //    {
        //        // UPDATE Order
        //        Guid.TryParse(model.obj.order.merchant_order_id.ToString(), out Guid orderId);
        //        var orderInDb = await _unitOfWork.Repository<Domain.Entities.Orders.Order>().GetByIdAsync(orderId);
        //        if (orderInDb.Status == OrderStatus.Initialized && !orderInDb.IsCanceled && !orderInDb.IsPaidOff)
        //        {
        //            orderInDb.IsPaidOff = true;
        //            await _unitOfWork.CompleteAsync();
        //        }
        //    }

        //    return Ok();
        //}
    }
}