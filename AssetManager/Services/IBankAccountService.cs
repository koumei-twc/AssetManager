using AssetManager.Dtos.BankAccounts;
using AssetManager.Models;

namespace AssetManager.Services
{
    public interface IBankAccountService
    {
        List<BankAccountResponseDto> GetAll();
        BankAccountResponseDto? GetById(int id);
        BankAccountResponseDto Create(BankAccountCreateDto dto);
        bool Update(int id, BankAccountUpdateDto dto);
        bool Delete(int id);
    }
}