namespace Baza.QRCode
{
    /// <summary>
    /// 纠错能力（数据恢复功能）
    /// </summary>
    public enum ErrorCorrectionLevel
    {
        /// <summary>
        /// 可恢复约7%的码字
        /// </summary>
        L,
        /// <summary>
        /// 可恢复约15%的码字
        /// </summary>
        M,
        /// <summary>
        /// 可恢复约25%的码字
        /// </summary>
        Q,
        /// <summary>
        /// 可恢复约30%的码字
        /// </summary>
        H
    }
}
