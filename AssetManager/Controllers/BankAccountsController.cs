using AssetManager.Dtos.BankAccounts;
using AssetManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _service;

        public BankAccountsController(IBankAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BankAccountResponseDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BankAccountResponseDto> GetById(int id)
        {
            var account = _service.GetById(id);

            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public ActionResult<BankAccountResponseDto> Create(BankAccountCreateDto dto)
        {
            var created = _service.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BankAccountUpdateDto dto)
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
    }
}