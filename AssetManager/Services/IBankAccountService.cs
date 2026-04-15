using AssetManager.Models;

namespace AssetManager.Services
{
    public interface IBankAccountService
    {
        List<BankAccount> GetAll();
        BankAccount? GetById(int id);
        BankAccount Create(BankAccount bankAccount);
        bool Update(int id, BankAccount updated);
        bool Delete(int id);
    }
}