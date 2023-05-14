
namespace AECS.Delivery.Api.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using AECS.Delivery.Api.Models.DbModels;
    public class DeliveryDbContext: DbContext
    {
        public DeliveryDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}
