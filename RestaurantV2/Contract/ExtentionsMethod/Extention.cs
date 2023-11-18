using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.Entities;

namespace RestaurantV2.Contract.ExtentionsMethod
{
    public static class Extention
    {
        public static MealResponse ToResponse(this Meal meal,string catName)
        {
            MealResponse mealResponse = new MealResponse()
            {
                price = meal.price,
                Name = meal.Name,
                Description = meal.Description,
                recipe = meal.recipe,
                CategoryName = catName,
            };

            return mealResponse;
        }
        public static CategoryResponse ToResponse(this Category category)
        {
            CategoryResponse categoryResponse = new CategoryResponse()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
            return categoryResponse;
        }

    }
}
