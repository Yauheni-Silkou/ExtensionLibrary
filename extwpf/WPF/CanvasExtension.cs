using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfExtensions
{
    public enum ImageFormat
    {
        Bmp, Jpeg, Png, Tiff
    }
    public static partial class CanvasEx
    {
        public static void SaveImage(string path, string name, Canvas canvas, ImageFormat format)
        {
            SaveImage($"{path}/{name}", canvas, format);
        }
        public static void SaveImage(string fullName, Canvas canvas, ImageFormat format)
        {
            int width = (int)canvas.RenderSize.Width,
                height = (int)canvas.RenderSize.Height;
            RenderTargetBitmap rtb = new RenderTargetBitmap(width,
                height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(canvas);

            var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, width, width));

            BitmapEncoder encoder;
            switch (format)
            {
                case ImageFormat.Jpeg: encoder = new JpegBitmapEncoder(); break;
                case ImageFormat.Png: encoder = new PngBitmapEncoder(); break;
                case ImageFormat.Tiff: encoder = new TiffBitmapEncoder(); break;
                case ImageFormat.Bmp:
                default: encoder = new BmpBitmapEncoder(); break;
            }
            encoder.Frames.Add(BitmapFrame.Create(crop));

            using (var fs = System.IO.File.OpenWrite($"{fullName}.{format.ToString().ToLower()}"))
            {
                encoder.Save(fs);
            }
        }

    }
}
