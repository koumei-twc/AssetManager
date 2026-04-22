using AssetManager.Data;
using AssetManager.Dtos.BankAccounts;
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

        public List<BankAccountResponseDto> GetAll()
        {
            return _context.BankAccounts
                .Where(x => x.IsActive)
                .Select(ToDto)
                .ToList();
        }

        public BankAccountResponseDto? GetById(int id)
        {
            var entity = _context.BankAccounts
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            return entity == null ? null : ToDto(entity);
        }

        public BankAccountResponseDto Create(BankAccountCreateDto dto)
        {
            var entity = new BankAccount
            {
                Name = dto.Name,
                Balance = dto.Balance,
                Currency = dto.Currency,
                IsActive = true
            };

            _context.BankAccounts.Add(entity);
            _context.SaveChanges();

            return ToDto(entity);
        }

        public bool Update(int id, BankAccountUpdateDto dto)
        {
            var entity = _context.BankAccounts.FirstOrDefault(x => x.Id == id);

            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.Balance = dto.Balance;
            entity.Currency = dto.Currency;
            entity.IsActive = dto.IsActive;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.BankAccounts.FirstOrDefault(x => x.Id == id);

            if (entity == null) return false;

            entity.IsActive = false;
            _context.SaveChanges();

            return true;
        }

        // 👉 mapping 集中在這裡（重點🔥）
        private static BankAccountResponseDto ToDto(BankAccount x)
        {
            return new BankAccountResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Balance = x.Balance,
                Currency = x.Currency,
                IsActive = x.IsActive
            };
        }
    }
}