namespace RestaurantV2.Contract.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Meal>? meals { get; set; }
    }
}
