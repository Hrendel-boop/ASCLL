
using System.Drawing;


namespace ASCLL
{
    internal static class ConvertorRGB
    {
        public static void ToGray(this Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    int avg = (pixel.R + pixel.B + pixel.G) / 3;
                    bitmap.SetPixel(x,y, Color.FromArgb(pixel.A, avg, avg, avg));
                }
            }
        }
    }
}
