using Esports.Model;
using Esports.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public HomeController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model1>>> GetModels()
        {
            var models = await _playerService.GetAllModelsAsync();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model1>> GetModel(int id)
        {
            var model = await _playerService.GetModelByIdAsync(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Model1>> PostModel(Model1 model)
        {
            var createdModel = await _playerService.CreateModelAsync(model);
            return CreatedAtAction(nameof(GetModel), new { id = createdModel.Id }, createdModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model1 model)
        {
            var updated = await _playerService.UpdateModelAsync(id, model);
            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var deleted = await _playerService.DeleteModelAsync(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
