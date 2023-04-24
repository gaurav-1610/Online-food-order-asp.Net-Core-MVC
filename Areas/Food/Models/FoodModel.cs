using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.Areas.Food.Models
{
    public class FoodModel
    {
        public int? FoodID { get; set; } 
        public string Food { get; set; }
        public int CatogaryID { get; set; }
        public decimal Price { get; set; }
        public string Rate { get; set; }
        public string Type { get; set; }
        public IFormFile File { get; set; }
        public string PhotoPath { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public string Catogary { get; set; }

    }
    public class Catogary_DropDownModel
    {
        public int? CatogaryID { get; set; }
        public string? Catogary { get; set; }
    }
}
