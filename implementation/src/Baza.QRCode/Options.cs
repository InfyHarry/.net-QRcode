using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Baza.QRCode
{
    public class Options
    {
        public static readonly string DefaultImageFormatContentType = "image/png";

        /// <summary>
        /// 错误纠正级别。
        /// </summary>
        public ErrorCorrectionLevel ErrorCorrectionLevel { get; set; } = ErrorCorrectionLevel.M;

        /// <summary>
        /// 二维码的空白像素，默认2.
        /// </summary>
        public QuietZoneModule QuietZone { get; set; } = QuietZoneModule.Two;

        /// <summary>
        /// 生成二维码的默认大小，默认是3，生成出来的图片大小是195x195。
        /// </summary>
        public int ModuleSize { get; set; } = 3;

        public ImageFormat ImageFormat { get; set; } = ImageFormat.Png;

        /// <summary>
        /// 图片对应 Http Header Content-Type。
        /// </summary>
        public string ContentType { get; } = DefaultImageFormatContentType;

        public Brush Brush { get; set; } = Brushes.Black;

        public Brush BackgroundBrush { get; set; } = Brushes.White;

        internal void Validate()
        {
            if (ModuleSize <= 0)
                throw new InvalidOperationException("ModuleSize值不能小于1.");

            if (ImageFormat != ImageFormat.Png)
                throw new NotSupportedException("仅支持输出png格式图片");
        }
    }
}
