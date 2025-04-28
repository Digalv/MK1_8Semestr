using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BrandsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IBrandService _brandService;

        public BrandsController(DataContext context, IBrandService brandService)
        {
            _context = context;
            _brandService = brandService;
        }

        // GET: api/v1/brands
        [HttpGet]
        public  async Task<IActionResult> GetBrands()
        {
            return Ok(await _brandService.GetBrands());
        }

        
        // GET: api/v1/brands/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(Guid id)
        {
            return Ok(await _brandService.GetBrand(id));
        }

        // POST: api/v1/brands
        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandDTO brandDto)
        {
            return Ok(await _brandService.CreateBrand(brandDto));
        }

        // PUT: api/v1/brands/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBrand(Guid id, BrandDTO brandDTO)
        {
            await _brandService.EditBrand(id, brandDTO);
            return Ok();
        }

        // DELETE: api/v1/brands/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
            await _brandService.DeleteBrand(id);
            return Ok();
        }

    }
}
