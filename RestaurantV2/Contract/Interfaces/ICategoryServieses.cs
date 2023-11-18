using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.Entities;

namespace RestaurantV2.Contract.Interfaces
{
    public interface ICategoryServieses
    {
        IEnumerable<CategoryResponse> GetCategories();
        CategoryResponse GetCategory(int id);
        IEnumerable<string> GetAllNames();
        CategoryResponse GetCategoryByName(string name);
        CategoryResponse AddCategory(CategoryRequest category);
        CategoryResponse DeleteCategory(int id);
        CategoryResponse UpdateCategory(int id,CategoryRequestPut category);
    }
}
