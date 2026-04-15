using AssetManager.Dtos.BankAccounts;
using AssetManager.Models;
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
            var accounts = _service.GetAll();

            var result = accounts.Select(ToResDto).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<BankAccountResponseDto> GetById(int id)
        {
            var account = _service.GetById(id);            
            if (account == null)
            {
                return NotFound();
            }
            return Ok(ToResDto(account));
        }

        [HttpPost]
        public ActionResult<BankAccountResponseDto> Create(BankAccountCreateDto dto)
        {
            var bankAccount = new BankAccount()
            {
                Name = dto.Name,
                Balance = dto.Balance,
                Currency = dto.Currency,
                IsActive = true,
            };

            var created = _service.Create(bankAccount);            

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, ToResDto(created));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BankAccountUpdateDto dto)
        {
            var updated = new BankAccount
            {
                Name = dto.Name,
                Balance = dto.Balance,
                Currency = dto.Currency,
                IsActive = dto.IsActive
            };

            var success = _service.Update(id, updated);

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

        private static BankAccountResponseDto ToResDto(BankAccount bankAccount)
        {
            return new BankAccountResponseDto
            {
                Id = bankAccount.Id,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                Currency = bankAccount.Currency,
                IsActive = bankAccount.IsActive
            };
        }
    }
}