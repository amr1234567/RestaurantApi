using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantV2.Contract.DTO;
using RestaurantV2.Contract.Interfaces;
using RestaurantV2.Services;

namespace RestaurantV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryServieses _categoryServises;
        public CategoryController(ICategoryServieses categoryServises) 
        {
            _categoryServises = categoryServises;
        }

        [HttpGet]
        public ActionResult GetAllCategories()
        {
            return Ok(_categoryServises.GetCategories());
        }

        [HttpGet("names")]
        public ActionResult GetAllCategoriesNames()
        {
            return Ok(_categoryServises.GetAllNames());
        }

        [HttpGet("{id}")]
        public ActionResult GetCategoryById(int id)
        {
            var category = _categoryServises.GetCategory(id);
            if (category==null) return NotFound();
            return Ok(category);
        }

        [HttpGet("{Name}")]
        public ActionResult GetCategoryByName(string name)
        {
            var category = _categoryServises.GetCategoryByName(name);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryRequest request)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var category = _categoryServises.AddCategory(request);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var cat =_categoryServises.DeleteCategory(id);
            if (cat == null) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult PutCategory(int id,CategoryRequestPut request)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            var category = _categoryServises.UpdateCategory(id, request);
            if (category == null) return NotFound();
            return Ok(category);
        }
    }
}
