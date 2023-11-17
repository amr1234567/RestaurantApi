using RestaurantV2.Contract.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantV2.Contract.Entities
{
    public class User : UserParent
    {
        public IEnumerable<Order> Orders { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("Cart")]
        public int CartID { get; set; }

        public IEnumerable<Rate> rates { get; set; }
    }
}
