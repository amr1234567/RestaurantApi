using RestaurantV2.Contract.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantV2.Contract.DTO
{
    public class MealResponse
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public float price { get; set; }
        public string? recipe { get; set; }
        public double? Rate { get; set; }
        public string CategoryName { get; set; }
    }
}
