namespace FoodOrder.Areas.Payment.Models
{
    public class PaymentModel
    {
        public int? PaymentID { get; set; }
        public string cardName { get; set; }
        public decimal ReceivedAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int? OrderID { get; set; }
    }
    
}
