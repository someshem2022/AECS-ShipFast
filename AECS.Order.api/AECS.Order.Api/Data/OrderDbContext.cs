using Microsoft.EntityFrameworkCore;

namespace AECS.Order.Api.Data
{
    using AECS.Order.Api.Model.DbModels;

    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
