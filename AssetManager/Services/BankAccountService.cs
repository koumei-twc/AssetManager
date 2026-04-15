using AssetManager.Data;
using AssetManager.Models;

namespace AssetManager.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly AppDbContext _context;
        public BankAccountService(AppDbContext context)
        {
            _context = context;
        }

        public List<BankAccount> GetAll()
        {
            return _context.BankAccounts
                .Where(x => x.IsActive)
                .ToList();
        }

        public BankAccount? GetById(int id)
        {
            return _context.BankAccounts
                .FirstOrDefault(x => x.Id == id && x.IsActive);
        }

        public BankAccount Create(BankAccount bankAccount)
        {
            _context.BankAccounts.Add(bankAccount);
            _context.SaveChanges();

            return bankAccount;
        }

        public bool Update(int id, BankAccount updated)
        {
            var bankAccount = _context.BankAccounts.FirstOrDefault(x => x.Id == id);

            if (bankAccount == null)
                return false;

            bankAccount.Name = updated.Name;
            bankAccount.Balance = updated.Balance;
            bankAccount.Currency = updated.Currency;
            bankAccount.IsActive = updated.IsActive;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var bankAccount = _context.BankAccounts.FirstOrDefault(x => x.Id == id);

            if (bankAccount == null)
                return false;

            bankAccount.IsActive = false;

            _context.SaveChanges();

            return true;
        }
    }
}