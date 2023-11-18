using Microsoft.EntityFrameworkCore;
using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.Entities;
using RestaurantV2.Contract.ExtentionsMethod;
using RestaurantV2.Contract.Interfaces;
using RestaurantV2.DBContext;

namespace RestaurantV2.Services
{
    public class MealServises : IMealServises
    {
        private Context context;
        
        public MealServises( Context context) 
        { 
            this.context = context;
        }


        public string GetCategoryName(int id)
        {
            var category = context.categories.Find(id);
            if (category == null)
            {
                return string.Empty;
            }
            return category.Name;
        }

        public  MealResponse GetMealResponse(int id)
        {
            var meal = context.meals.Find(id);

            if (meal == null)
            {
                return null;
            }

            return meal.ToResponse(GetCategoryName(meal.CategoryID));
        }

      
        public IEnumerable<MealResponse> GetMealResponses()
        {
            var meals = context.meals.ToList();
            if (meals == null) return null;
            var newMeals = new List<MealResponse>();
            foreach (var meal in meals)
            {
                newMeals.Add(meal.ToResponse(GetCategoryName(meal.CategoryID)));
            }
            return newMeals;
        }

        public MealResponse AddMeal(MealRequest mealRequest)
        {
            var meal = mealRequest.ToMeal(mealRequest);
            context.meals.Add(meal);
            context.SaveChanges();
            return meal.ToResponse(GetCategoryName(meal.CategoryID));
        }

        public MealResponse EditMeal(MealRequestPut request,int id )
        {
            var meal = context.meals.FirstOrDefault(x => x.Id == id);
            if (meal == null) return null;

            request.MapMeal(request, meal);
            context.SaveChanges();

            return meal.ToResponse(GetCategoryName(meal.CategoryID));
        }

        public IEnumerable<MealResponse> DeleteMeal(int id)
        {
            var meal = context.meals.Find(id);
            if (meal == null) return null;
            context.meals.Remove(meal);
            context.SaveChanges();
            var meals = context.meals.ToList();
            return GetMealResponses();
        }
    }
}
