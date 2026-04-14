namespace AssetManager.Dtos.BankAccounts
{
    public class BankAccountResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}