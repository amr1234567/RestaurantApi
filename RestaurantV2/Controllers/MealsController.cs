using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.Entities;
using RestaurantV2.Contract.Interfaces;
using RestaurantV2.DBContext;
using RestaurantV2.Services;

namespace RestaurantV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealServises mealServises;

        public MealsController(IMealServises mealServises)
        {
            this.mealServises = mealServises;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealResponse>>> GetMeals()
        {
            
            var mealsResponse = mealServises.GetMealResponses();
            return Ok(mealsResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealResponse>> GetMeal(int id)
        {
           
            var mealResponse = mealServises.GetMealResponse(id);
            if (mealResponse == null) return NotFound();

            return Ok(mealResponse);
        }

        [HttpPost]
        public ActionResult<MealResponse> AddMeal(MealRequest mealRequest)
        {
            if(!ModelState.IsValid) return BadRequest(mealRequest);

            var meal=mealServises.AddMeal(mealRequest);
            return Ok(meal);
        }

        [HttpPut("{id}")]
        public ActionResult<MealResponse> EditMeal([FromRoute]int id,MealRequestPut mealRequest)
        {
            var meal = mealServises.EditMeal(mealRequest, id);
            if (meal == null) return NotFound();
            return Ok(meal);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<MealResponse>> DeleteMeal(int id)
        {
            var meals = mealServises.DeleteMeal(id);
            if (meals == null) return NotFound();
            return Ok(meals);
        }
    }
}
