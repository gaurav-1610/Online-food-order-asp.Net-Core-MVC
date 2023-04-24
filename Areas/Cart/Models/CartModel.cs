using System.Data;

namespace FoodOrder.Areas.Cart.Models
{
    public class CartModel 
    {
        internal object cid;

        public int? CartID { get; set; }
        public int FoodID { get; set; }
        public string Food { get; set; }
        public int CatogaryID { get; set; }
        public decimal Price { get; set; }
        public string Rate { get; set; }
        public string Type { get; set; }
        public IFormFile File { get; set; }
        public string PhotoPath { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }

    }


}
