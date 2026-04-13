namespace AssetManager.Models
{
    /// <summary>
    /// 銀行帳戶資料模型
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// 帳戶唯一識別 ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 帳戶名稱
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 帳戶餘額
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 幣別
        /// </summary>
        public string Currency { get; set; } = "TWD";

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}