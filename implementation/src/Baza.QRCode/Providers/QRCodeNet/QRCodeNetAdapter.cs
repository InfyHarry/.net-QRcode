using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.IO;

namespace Baza.QRCode.Providers.QRCodeNet
{
    public class QRCodeNetAdapter : IQRCode
    {
        public Stream Generate(string content, Options options = null)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("content不能为空");

            if (options == null)
            {
                options = new Options();
            }

            var encoder = new QrEncoder(ToErrorCorrectionLevel(options.ErrorCorrectionLevel));
            var code = encoder.Encode(content);
            var render = new GraphicsRenderer(new FixedModuleSize(options.ModuleSize, ToQuietZoneModules(options.QuietZone)), options.Brush, options.BackgroundBrush);
            MemoryStream stream = new MemoryStream();
            render.WriteToStream(code.Matrix, options.ImageFormat, stream);
            return stream;
        }

        Gma.QrCodeNet.Encoding.ErrorCorrectionLevel ToErrorCorrectionLevel(ErrorCorrectionLevel level)
        {
            switch (level)
            {
                case ErrorCorrectionLevel.L:
                    return Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.L;
                case ErrorCorrectionLevel.M:
                    return Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M;
                case ErrorCorrectionLevel.Q:
                    return Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.Q;
                case ErrorCorrectionLevel.H:
                    return Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.H;
                default:
                    throw new NotSupportedException("不受支持的ErrorCorrectionLevel值: " + level.ToString());
            }
        }

        QuietZoneModules ToQuietZoneModules(QuietZoneModule quietZone)
        {
            switch (quietZone)
            {
                case QuietZoneModule.Zero:
                    return QuietZoneModules.Zero;
                case QuietZoneModule.Two:
                    return QuietZoneModules.Two;
                case QuietZoneModule.Four:
                    return QuietZoneModules.Four;
                default:
                    throw new NotSupportedException("不受支持的quietZone值: " + quietZone.ToString());
            }
        }
    }
}
