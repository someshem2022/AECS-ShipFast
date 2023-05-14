
namespace AECS.Delivery.Api.Controllers
{
    using AECS.Delivery.Api.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using DO = Models.DbModels;
    using SO = Models.ApiModels;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeliveryController : Controller
    {
        private readonly DeliveryDbContext dbContext;
        public DeliveryController(DeliveryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetStatus(int code)
        {
            if (code <= 0)
            {
                return BadRequest("Tracking Code required");
            }
            return Ok(await dbContext.Deliveries.FirstOrDefaultAsync(a=>a.Code == code));
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(SO.CancelDelivery model)
        {
            if (model.UserId <= 0)
            {
                return BadRequest("User Id required");
            }
            var deliveryData = new DO.Delivery()
            {
               OrderId = model.OrderId,
               Code = model.Code,
               UserId = model.UserId,
               Status = 3
            };
            
            dbContext.Deliveries.Update(deliveryData);
            await dbContext.SaveChangesAsync();
            return Ok(deliveryData);

        }

        [HttpPost]
        public async Task<IActionResult> AddDelivery(SO.Delivery model)
        {
            if (model.UserId <= 0)
            {
                return BadRequest("User Id required");
            }
            var orderData = new DO.Delivery()
            {
                OrderId = model.OrderId,
                Code = model.Code,
                Status = 1,
                PlannedDate =  model.PlannedDate,
                UserId = model.UserId
            };
            await dbContext.Deliveries.AddAsync(orderData);
            await dbContext.SaveChangesAsync();
            return Ok(orderData);

        }

    }
}
