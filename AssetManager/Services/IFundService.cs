using AssetManager.Dtos.Funds;
using AssetManager.Models;

namespace AssetManager.Services
{
    public interface IFundService
    {
        List<FundResponseDto> GetAll();
        FundResponseDto? GetById(int id);
        FundResponseDto Create(FundCreateDto dto);
        bool Update(int id, FundUpdateDto dto);
        bool Delete(int id);
        //CurrentAmount
        bool AddAmount(int id, decimal amount);
        bool RemoveAmount(int id, decimal amount);
    }
}