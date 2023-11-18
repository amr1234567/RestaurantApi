using RestaurantV2.Contract.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantV2.Contract.DTO
{
    public class CategoryRequest
    {
        [Required,StringLength(maximumLength:500,MinimumLength =3)]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public Category ToCategory(CategoryRequest request)
        {
            var category = new Category()
            {
                Description = request.Description,
                Name = request.Name,
            };
            return category;
        }
    }

    public class CategoryRequestPut
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public void MapCategory(CategoryRequestPut request,Category category)
        {
            category.Name = (request.Name != string.Empty) ? request.Name : category.Name;
            category.Description = (request.Description != string.Empty) ? request.Description : category.Description;

        }
    }
}
