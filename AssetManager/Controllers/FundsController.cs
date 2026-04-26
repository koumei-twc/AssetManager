using AssetManager.Dtos.Funds;
using AssetManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundsController : ControllerBase
    {
        private readonly IFundService _service;

        public FundsController(IFundService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FundResponseDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<FundResponseDto> GetById(int id)
        {
            var fund = _service.GetById(id);

            if (fund == null)
                return NotFound();

            return Ok(fund);
        }

        [HttpPost]
        public ActionResult<FundResponseDto> Create(FundCreateDto dto)
        {
            var created = _service.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, FundUpdateDto dto)
        {
            var success = _service.Update(id, dto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
        [HttpPost("{id}/add")]
        public IActionResult AddAmount(int id, AmountDto dto)
        {
            var success = _service.AddAmount(id, dto.Amount);

            if (!success)
                return BadRequest();

            return NoContent();
        }
        [HttpPost("{id}/remove")]
        public IActionResult RemoveAmount(int id, AmountDto dto)
        {
            var success = _service.RemoveAmount(id, dto.Amount);

            if (!success)
                return BadRequest();

            return NoContent();
        }
    }
}