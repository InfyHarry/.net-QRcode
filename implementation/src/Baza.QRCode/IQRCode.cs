using System.IO;

namespace Baza.QRCode
{
    public interface IQRCode
    {
        Stream Generate(string content, Options options = null);
    }
}
