using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantV2.Contract.Entities
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
        public string? recipe { get; set; }
        public double? Rate { get; set; }

        public IEnumerable<Order>? orders { get; set; }
        public IEnumerable<Cart>? Carts { get; set; }
        public IEnumerable<Rate>? Rates { get; set; }
        public Category category { get; set; }
        [ForeignKey("category")]
        public int CategoryID { get; set; }
    }
}
