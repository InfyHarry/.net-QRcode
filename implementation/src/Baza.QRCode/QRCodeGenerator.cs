using Baza.QRCode.Providers.QRCodeNet;
using System;
using System.IO;

namespace Baza.QRCode
{
    public static class QRCodeGenerator
    {
        public static Stream Generate(string content, Options options = null)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("content值不能为空");

            if (options != null)
            {
                options.Validate();
            }

            var generator = new QRCodeNetAdapter();
            return generator.Generate(content, options);
        }
    }
}
