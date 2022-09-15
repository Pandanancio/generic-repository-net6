using GenericRepository_NET6.Models;
using GenericRepository_NET6.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository_NET6.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _service;

        public PetController(IPetService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> Create([FromBody] Pet pet)
        {
            try
            {
                return Created("Created Sucessfully", await _service.Create(pet));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Pet>> GetById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Pet>> Update(int id,[FromBody] Pet request)
        {
            try
            {
                return Ok(await _service.Update(id, request));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Pet>> DeleteById(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok("Deleted Sucessfully");
                
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
