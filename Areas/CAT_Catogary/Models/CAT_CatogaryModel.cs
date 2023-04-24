using Microsoft.Build.Framework;

namespace FoodOrder.Areas.CAT_Catogary.Models
{
    public class CAT_CatogaryModel
    {
        [Required]
        public int? CatogaryID { get; set; }
        [Required]
        public string Catogary { get; set; }
    }
}
