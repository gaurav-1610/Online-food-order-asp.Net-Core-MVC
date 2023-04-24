namespace FoodOrder.Areas.Menu.Models
{
    public class MenuModel
    {
        public string Food { get; set; }
        public decimal Price { get; set; }
        public IFormFile File { get; set; }
        public string PhotoPath { get; set; }


    }
}
