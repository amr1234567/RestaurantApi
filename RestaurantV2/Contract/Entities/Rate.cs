namespace RestaurantV2.Contract.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public double Rating { get; set; }

        public IEnumerable<User>? Users { get; set; }
        public IEnumerable<Meal>? Meals { get; set; }
    }
}
