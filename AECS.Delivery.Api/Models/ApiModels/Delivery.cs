namespace AECS.Delivery.Api.Models.ApiModels
{
    public class Delivery
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int Code { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
    }
}
