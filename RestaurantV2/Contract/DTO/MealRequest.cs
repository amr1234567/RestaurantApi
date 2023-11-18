using Azure.Core;
using RestaurantV2.Contract.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantV2.Contract.DTO
{
    public class MealRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required , Range(1,int.MaxValue)]
        public float price { get; set; } = 0;
        [Required, Range(1, int.MaxValue)]
        public int stock { get; set; } = 0;
        public string recipe { get; set; } = string.Empty;
        [Required]
        public int CategoryID { get; set; } = 0;

        public Meal ToMeal(MealRequest mealRequest)
        {
            var meal = new Meal()
            {
                price =  mealRequest.price,
                stock = mealRequest.stock,
                recipe = mealRequest.recipe,
                CategoryID = mealRequest.CategoryID,
                Description = mealRequest.Description,
                Name = mealRequest.Name,
            };
            return meal;
        }
    }

    public class MealRequestPut
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float price { get; set; } = 0;
        public int stock { get; set; } = 0;
        public string recipe { get; set; } = string.Empty;
        public int CategoryID { get; set; } = 0;

        public void MapMeal(MealRequestPut request,Meal meal)
        {
            meal.price = (request.price != 0) ? request.price : meal.price;
            meal.Name = (request.Name != string.Empty) ? request.Name : meal.Name;
            meal.recipe = (request.recipe != string.Empty) ? request.recipe : meal.recipe;
            meal.stock = (request.stock != 0) ? request.stock : meal.stock;
            meal.Description = (request.Description != string.Empty) ? request.Description : meal.Description;
            meal.CategoryID = (request.CategoryID != 0) ? request.CategoryID : meal.CategoryID;
        }
    }
}
