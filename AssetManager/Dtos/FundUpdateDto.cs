using System.ComponentModel.DataAnnotations;

namespace AssetManager.Dtos.Funds
{
    public class FundUpdateDto
    {
        [Required]
        [StringLength(100)]
        [RegularExpression(@"\S+", ErrorMessage = "Name cannot be empty or whitespace.")]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be greater than or equal to 0.")]
        public decimal TargetAmount { get; set; }
    }
}