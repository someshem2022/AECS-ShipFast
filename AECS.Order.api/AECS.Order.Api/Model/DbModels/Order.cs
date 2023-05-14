namespace AECS.Order.Api.Model.DbModels
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
    }
}
