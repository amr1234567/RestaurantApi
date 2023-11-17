using Microsoft.EntityFrameworkCore;
using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.Entities;
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
            return ConvertToResponse(meal);
        }

        public  MealResponse ConvertToResponse(Meal meal)
        {
            MealResponse meatResponse = new MealResponse();
            meatResponse.price = meal.price;
            meatResponse.Name = meal.Name;
            meatResponse.recipe = meal.recipe;
            meatResponse.Description = meal.Description;
            meatResponse.CategoryName = GetCategoryName(meal.CategoryID);

            return meatResponse;
        }

        public Meal Convert(MealRequest mealRequest)
        {
            var meal = new Meal();
            meal.price = mealRequest.price;
            meal.Name = mealRequest.Name;
            meal.CategoryID = mealRequest.CategoryID;
            meal.Description = mealRequest.Description;
            meal.stock = mealRequest.stock;
            meal.recipe = mealRequest.recipe;
            return meal;
        }

        public IEnumerable<MealResponse> GetMealResponses()
        {
            var meals = context.meals.ToList();
            if (meals == null) return null;
            var newMeals = new List<MealResponse>();
            foreach (var meal in meals)
            {
                newMeals.Add(ConvertToResponse(meal));
            }
            return newMeals;
        }

        public MealResponse AddMeal(MealRequest mealRequest)
        {
            var meal = Convert(mealRequest);
            context.meals.Add(meal);
            context.SaveChanges();
            return ConvertToResponse(meal);
        }

        public MealResponse EditMeal(MealRequestPut request,int id )
        {
            var meal = context.meals.FirstOrDefault(x => x.Id == id);
            if (meal == null) return null;
            meal.price = (request.price != 0) ? request.price : meal.price;
            meal.Name = (request.Name != string.Empty) ? request.Name : meal.Name;
            meal.recipe = (request.recipe != string.Empty) ? request.recipe : meal.recipe;
            meal.stock = (request.stock != 0) ? request.stock : meal.stock;
            meal.Description = (request.Description != string.Empty) ? request.Description : meal.Description;
            meal.CategoryID = (request.CategoryID != 0) ? request.CategoryID : meal.CategoryID;
            context.SaveChanges();
            return ConvertToResponse(meal);
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
