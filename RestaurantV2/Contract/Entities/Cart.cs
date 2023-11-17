
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantV2.Contract.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isChecked { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public Order? Order { get; set; }

        public IEnumerable<Meal> meals { get; set; }
    }
}
