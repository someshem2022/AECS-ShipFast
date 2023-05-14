
namespace AECS.Order.Api.Controllers
{
    using AECS.Order.Api.Data;
    using AECS.Order.Api.Helpers;
    using AECS.Order.Api.Model.ApiModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using RestSharp;
    using DO = AECS.Order.Api.Model.DbModels;
    using SO = AECS.Order.Api.Model.ApiModels;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly OrderDbContext dbContext;

        public OrdersController(OrderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await dbContext.Orders.ToListAsync());
        }

        [HttpPost]

        public async Task<IActionResult> AddOrder(SO.Order model)
        {
            if (model.UserId <= 0)
            {
                return BadRequest("User Id required");
            }
            var orderData = new DO.Order()
            {
               Price = model.Price,
               Product= model.Product,
               ProductId=model.ProductId,
               Quantity=model.Quantity,
               UserId = model.UserId,
               Address=model.Address,
            };

            await dbContext.Orders.AddAsync(orderData);
            await dbContext.SaveChangesAsync();

            var delivery = new Delivery
            {
                OrderId = orderData.Id,
                UserId = orderData.UserId,
                PlannedDate = DateTime.Now.AddDays(2),
                Status = 1,
                Code = GenerateCode()
            };

            await AddOrderToDeliveryAsync(delivery);
            //await Task.Run(async () =>
            //{
            //    await AddOrderToDeliveryAsync(delivery);
            //});

            return Ok(orderData);

        }

        private async Task AddOrderToDeliveryAsync(Delivery model) 
        {
            if (model.OrderId <=0 || model.UserId <= 0)
            {
                return;
            }

            UriBuilder builder = new UriBuilder("https://localhost:7156/");
            builder.AppendToPath("​api​/Delivery​/AddDelivery");
            string uri = builder.ToString();

            var client = new RestSharp.RestClient(uri);
            var request = new RestSharp.RestRequest();
            //request.AddHeader("Authorization", "Bearer " + Settings.CurrentAccessToken);
            
            request.RequestFormat = RestSharp.DataFormat.Json;
            string serialized = JsonConvert.SerializeObject(model);
            request.AddJsonBody(serialized);
            
            var response = await client.ExecutePostAsync(request);

            if (!response.IsSuccessful)
            {
                
            }

            //return response.IsSuccessful;

        }

        private int GenerateCode() 
        {            
            Random rnd = new Random();
            return rnd.Next(10001, 99999);
        }
    }
}
