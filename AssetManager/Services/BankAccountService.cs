using AssetManager.Models;

namespace AssetManager.Services
{
    public class BankAccountService
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

        public List<BankAccount> GetAll()
        {
            return _bankAccounts.Where(x => x.IsActive).ToList();
        }

        public BankAccount? GetById(int id)
        {
            return _bankAccounts.FirstOrDefault(x => x.Id == id && x.IsActive);
        }

        public BankAccount Create(BankAccount bankAccount)
        {
            var newId = _bankAccounts.Any() ? _bankAccounts.Max(x => x.Id) + 1 : 1;
            bankAccount.Id = newId;

            _bankAccounts.Add(bankAccount);

            return bankAccount;
        }

        public bool Update(int id, BankAccount updated)
        {
            var bankAccount = _bankAccounts.FirstOrDefault(x => x.Id == id);

            if (bankAccount == null)
                return false;

            bankAccount.Name = updated.Name;
            bankAccount.Balance = updated.Balance;
            bankAccount.Currency = updated.Currency;
            bankAccount.IsActive = updated.IsActive;

            return true;
        }

        public bool Delete(int id)
        {
            var bankAccount = _bankAccounts.FirstOrDefault(x => x.Id == id);

            if (bankAccount == null)
                return false;

            bankAccount.IsActive = false;
            return true;
        }
    }
}