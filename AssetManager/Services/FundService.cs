using AssetManager.Data;
using AssetManager.Dtos.Funds;
using AssetManager.Models;

namespace AssetManager.Services
{
    public class FundService : IFundService
    {
        private readonly AppDbContext _context;

        public FundService(AppDbContext context)
        {
            _context = context;
        }

        public List<FundResponseDto> GetAll()
        {
            return _context.Funds
                .Where(x => x.IsActive)
                .Select(ToDto)
                .ToList();
        }

        public FundResponseDto? GetById(int id)
        {
            var entity = _context.Funds
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            return entity == null ? null : ToDto(entity);
        }

        public FundResponseDto Create(FundCreateDto dto)
        {
            var entity = new Fund
            {
                Name = dto.Name,
                TargetAmount = dto.TargetAmount,
                CurrentAmount = 0,
                IsActive = true
            };

            _context.Funds.Add(entity);
            _context.SaveChanges();

            return ToDto(entity);
        }

        public bool Update(int id, FundUpdateDto dto)
        {
            var entity = _context.Funds.FirstOrDefault(x => x.Id == id && x.IsActive);

            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.TargetAmount = dto.TargetAmount;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.Funds
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            if (entity == null) return false;

            entity.IsActive = false;
            _context.SaveChanges();

            return true;
        }

        // 👉 mapping 集中在這裡（重點🔥）
        private static FundResponseDto ToDto(Fund x)
        {
            return new FundResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                TargetAmount = x.TargetAmount,
                CurrentAmount= x.CurrentAmount,
                RemainingAmount = x.TargetAmount - x.CurrentAmount
            };
        }
        public bool AddAmount(int id, decimal amount)
        {
            var entity = _context.Funds
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            if (entity == null || amount <= 0) return false;

            entity.CurrentAmount += amount;

            _context.SaveChanges();
            return true;
        }
        public bool RemoveAmount(int id, decimal amount)
        {
            var entity = _context.Funds
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            if (entity == null || amount <= 0) return false;

            if (entity.CurrentAmount < amount)
                return false;

            entity.CurrentAmount -= amount;

            _context.SaveChanges();
            return true;
        }
    }
}