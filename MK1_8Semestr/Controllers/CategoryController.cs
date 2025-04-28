using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MK1_8Semestr.Context;
using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;
using MK1_8Semestr.Services;

namespace MK1_8Semestr.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(DataContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        // GET: api/v1/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }

        // GET: api/v1/categories/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            return Ok(await _categoryService.GetCategory(id));
        }

        // POST: api/v1/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO categoryDto)
        {
            return Ok(await _categoryService.CreateCategory(categoryDto));
        }

        // PUT: api/v1/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(Guid id, CategoryDTO categoryDTO)
        {
            await _categoryService.EditCategory(id, categoryDTO);
            return Ok();
        }

        // DELETE: api/v1/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
