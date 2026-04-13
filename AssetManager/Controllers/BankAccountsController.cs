using Microsoft.AspNetCore.Mvc;
using AssetManager.Models;

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
            },
            new BankAccount
            {
                Id = 2,
                Name = "中信",
                Balance = 1000m,
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<BankAccount>> GetAll()
        {
            return Ok(_bankAccounts);
        }

        [HttpGet("{id}")]
        public ActionResult<BankAccount> GetById(int id)
        {
            var result = _bankAccounts.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<BankAccount> Create(BankAccount bankAccount)
        {
            // 驗證
            if (string.IsNullOrWhiteSpace(bankAccount.Name))
            {
                return BadRequest("Name can't be empty");
            }

            // 產生 Id
            var newId = _bankAccounts.Any() ? _bankAccounts.Max(x => x.Id) + 1 : 1;

            // 指定 Id
            bankAccount.Id = newId;

            // 加入清單
            _bankAccounts.Add(bankAccount);

            // 回傳 201
            return CreatedAtAction(nameof(GetById), new { id = bankAccount.Id }, bankAccount);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BankAccount updatedBankAccount)
        {
            if (string.IsNullOrWhiteSpace(updatedBankAccount.Name))
            {
                return BadRequest("Name can't be empty");
            }

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
            // 3. 從 _bankAccounts 移除
            _bankAccounts.Remove(bankAccount);
            // 4. 回傳 NoContent()
            return NoContent();
        }
    }
}