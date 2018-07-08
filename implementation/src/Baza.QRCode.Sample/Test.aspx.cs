using Baza.QRCode.Providers.QRCodeNet;
using System;
using System.IO;

namespace Baza.QRCode.Sample
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                var generator = new QRCodeNetAdapter();
                var options = new Options();
                options.ErrorCorrectionLevel = ErrorCorrectionLevel.L;
                options.ModuleSize = 5;
                options.Brush = System.Drawing.Brushes.GreenYellow;
                options.BackgroundBrush = System.Drawing.Brushes.White;
                var stream = generator.Generate(Request["content"], options) as MemoryStream;
                Response.ContentType = Options.DefaultImageFormatContentType;
                Response.OutputStream.Write(stream.GetBuffer(), 0, (int)stream.Length);
            }
        }
    }
}