using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantV2.Contract.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool isDone { get; set; }
        public bool IsDelivered { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public IEnumerable<Meal> meals { get; set; }

        public Sellers Seller { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
    }
}
