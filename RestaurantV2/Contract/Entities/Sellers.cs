using RestaurantV2.Contract.Interfaces;

namespace RestaurantV2.Contract.Entities
{
    public class Sellers : UserParent
    {
        public IEnumerable<Order>? Orders { get; set; }
    }
}
