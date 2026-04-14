using System.ComponentModel.DataAnnotations;

namespace AssetManager.Dtos.BankAccounts
{
    public class BankAccountUpdateDto
    {
        [Required]
        [StringLength(100)]
        [RegularExpression(@"\S+", ErrorMessage = "Name cannot be empty or whitespace.")]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be greater than or equal to 0.")]
        public decimal Balance { get; set; }

        [Required]
        [StringLength(10)]
        public string Currency { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}