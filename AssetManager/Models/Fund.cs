namespace AssetManager.Models
{
    public class Fund
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
