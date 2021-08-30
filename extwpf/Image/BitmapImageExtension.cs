using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace WpfExtensions.Image
{
    public static class BitmapImageEx
    {
        public static BitmapImage GetImage(this byte[] source)
        {
            try
            {
                if (source == null || source.Length == 0) return new BitmapImage();
                using (var ms = new MemoryStream(source))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            catch
            {
                return null;
            }
        }

        public static BitmapImage GetImage(this Uri uri)
        {
            var bitmap = new BitmapImage();
            try
            {
                bitmap.BeginInit();
                bitmap.UriSource = uri;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                return null;
            }
        }
        public static BitmapImage GetImage(this string uriString)
        {
            Uri uri = new Uri(uriString);
            return uri.GetImage();
        }
        public static byte[] GetBytesFrom(this BitmapSource bitmapImage, BitmapEncoder encoder)
        {
            byte[] result;
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    encoder.Save(stream);
                    result = stream.ToArray();
                    return result;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    stream.Close();
                }
            }
        }
        public static byte[] GetBytesFromJpeg(this BitmapSource bitmapImage)
        {
            return bitmapImage.GetBytesFrom(new JpegBitmapEncoder());
        }
        public static byte[] GetBytesFromPng(this BitmapSource bitmapImage)
        {
            return bitmapImage.GetBytesFrom(new PngBitmapEncoder());
        }
        public static byte[] GetBytesFromBmp(this BitmapSource bitmapImage)
        {
            return bitmapImage.GetBytesFrom(new BmpBitmapEncoder());
        }
        public static byte[] GetBytesFromGif(this BitmapSource bitmapImage)
        {
            return bitmapImage.GetBytesFrom(new GifBitmapEncoder());
        }
        public static byte[] GetBytesFromTiff(this BitmapSource bitmapImage)
        {
            return bitmapImage.GetBytesFrom(new TiffBitmapEncoder());
        }
        public static byte[] GetBytesFromWmp(this BitmapSource bitmapImage)
        {
            return bitmapImage.GetBytesFrom(new WmpBitmapEncoder());
        }
    }
}
