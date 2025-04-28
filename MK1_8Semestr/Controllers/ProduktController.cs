using Microsoft.AspNetCore.Mvc;
using MK1_8Semestr.Context;
using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;
using MK1_8Semestr.Services;

namespace MK1_8Semestr.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProduktController : ControllerBase
    {
        private readonly IProduktService _produktService;

        public ProduktController(IProduktService produktService)
        {
            _produktService = produktService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProdukt(ProduktChangeDTO produktChangeDTO)
        {
            return Ok(await _produktService.CreateProdukt(produktChangeDTO));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProdukt(Guid id, ProduktChangeDTO produktChangeDTO)
        {
            await _produktService.EditProdukt(id, produktChangeDTO);
            return Ok();
        }

        // DELETE: api/v1/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukt(Guid id)
        {
            await _produktService.DeleteProdukt(id);
            return Ok();
        }

        [HttpGet("by-brand/{brandId}")]
        public async Task<ActionResult<List<Produkt>>> GetProduktsByBrand(Guid brandId)
        {
            return Ok(await _produktService.GetProduktByBrand(brandId));
        }
        [HttpGet("by-categories")]
        public async Task<ActionResult<List<Produkt>>> GetProduktsByCategories([FromQuery] List<Guid> categories)
        {
            return Ok(await _produktService.GetProduktByCategories(categories));
        }
    }
}
