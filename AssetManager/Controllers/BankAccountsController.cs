using Microsoft.AspNetCore.Mvc;
using AssetManager.Models;
using AssetManager.Dtos.BankAccounts;

namespace AssetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private static readonly List<BankAccount> _bankAccounts = new()
        {
            new BankAccount
            {
                Id = 1,
                Name = "台新",
                Balance = 75000m,
                Currency = "TWD",
                IsActive = true,
            },
            new BankAccount
            {
                Id = 2,
                Name = "中信",
                Balance = 1000m,
                Currency = "TWD",
                IsActive = true,
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<BankAccountResponseDto>> GetAll()
        {
            var result = _bankAccounts.Where(x => x.IsActive).Select(ToResDto).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<BankAccountResponseDto> GetById(int id)
        {
            var result = _bankAccounts.FirstOrDefault(x => x.Id == id && x.IsActive);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(ToResDto(result));
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

            var newId = _bankAccounts.Any() ? _bankAccounts.Max(x => x.Id) + 1 : 1;
            bankAccount.Id = newId;

            _bankAccounts.Add(bankAccount);

            return CreatedAtAction(nameof(GetById), new { id = bankAccount.Id }, ToResDto(bankAccount));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BankAccountUpdateDto updatedBankAccount)
        {
            var bankAccount = _bankAccounts.FirstOrDefault(x => x.Id == id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            bankAccount.Name = updatedBankAccount.Name;
            bankAccount.Balance = updatedBankAccount.Balance;
            bankAccount.Currency = updatedBankAccount.Currency;
            bankAccount.IsActive = updatedBankAccount.IsActive;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // 1. 找資料
            var bankAccount = _bankAccounts.FirstOrDefault(x => x.Id == id);
            // 2. 找不到 -> NotFound()
            if (bankAccount == null)
            {
                return NotFound();
            }
            // 3. 從 _bankAccounts 軟刪除
            bankAccount.IsActive = false;
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