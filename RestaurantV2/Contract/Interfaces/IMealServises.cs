using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.Entities;

namespace RestaurantV2.Contract.Interfaces
{
    public interface IMealServises
    {
        IEnumerable<MealResponse> GetMealResponses();
        MealResponse GetMealResponse(int id);
        string GetCategoryName(int id);
        MealResponse AddMeal(MealRequest request);
        MealResponse EditMeal(MealRequestPut request,int id);
        IEnumerable<MealResponse> DeleteMeal(int id);
        
    }
}
