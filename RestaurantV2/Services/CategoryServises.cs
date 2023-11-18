using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.ExtentionsMethod;
using RestaurantV2.Contract.Interfaces;
using RestaurantV2.DBContext;
using System.Linq;

namespace RestaurantV2.Services
{
    public class CategoryServises : ICategoryServieses
    {
        private Context _context;
        public CategoryServises(Context context)
        {
            _context = context;
        }
        public CategoryResponse AddCategory(CategoryRequest category)
        {
            var cat = category.ToCategory(category);
            _context.categories.Add(cat);
            _context.SaveChanges();
            return cat.ToResponse();
        }

        public CategoryResponse DeleteCategory(int id)
        {
            var category = _context.categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return null; 
            _context.categories.Remove(category);
            _context.SaveChanges();
            return category.ToResponse();
        }

        public IEnumerable<string> GetAllNames()
        {
            var categories = GetCategories();
            var categoriesNames = categories.Select(c => c.Name);
            return categoriesNames;
        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            var categories =_context.categories.ToList();
            var catResponses = new List<CategoryResponse>();
            foreach (var category in categories)
                catResponses.Add(category.ToResponse());
            return catResponses;
        }

        public CategoryResponse GetCategory(int id)
        {
            var category = _context.categories.Find(id);
            if (category == null) return null;
            return category.ToResponse();
        }

        public CategoryResponse GetCategoryByName(string name)
        {
            var cat = _context.categories.FirstOrDefault(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            if (cat == null) return null;
            return cat.ToResponse();
        }

        public CategoryResponse UpdateCategory(int id, CategoryRequestPut category)
        {
            var originalCategory = _context.categories.FirstOrDefault(x => x.Id == id);
            if (originalCategory == null) return null;
            category.MapCategory(category, originalCategory);
            _context.SaveChanges();
            return originalCategory.ToResponse();
        }

        public double SetRateValue(int id)
        {
            var meal = _context.meals.Where(x => x.Id == id).Include("Rates");
            
            if (meal.Count() > 0) return meal.Count();
            var rates = meal.FirstOrDefault();
            double SumRate = 0;
            if (rates == null) return SumRate;
            foreach (var rate in rates.Rates)
                SumRate += rate.Rating;
            
            return SumRate / rates.Rates.Count();
        }
    }
}
