using RestaurantV2.Contract.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantV2.Contract.DTO
{
    public class MealRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required , Range(1,int.MaxValue)]
        public float price { get; set; } = 0;
        [Required, Range(1, int.MaxValue)]
        public int stock { get; set; } = 0;
        public string recipe { get; set; } = string.Empty;
        [Required]
        public int CategoryID { get; set; } = 0;
    }

    public class MealRequestPut
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float price { get; set; } = 0;
        public int stock { get; set; } = 0;
        public string recipe { get; set; } = string.Empty;
        public int CategoryID { get; set; } = 0;
    }
}
