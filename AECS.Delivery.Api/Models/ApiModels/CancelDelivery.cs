namespace AECS.Delivery.Api.Models.ApiModels
{
    public class CancelDelivery
    {
        public int Code { get; set; }

        public int OrderId { get; set; }
        public int UserId { get; set; }
    }
}
