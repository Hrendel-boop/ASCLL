﻿
using System.Drawing;

namespace ASCLL
{
    public class BitmapToASCII
    {      
        private readonly char[] _asciiTableNegative = { '@', '#', '$', '%', '?', '*', '+', ':', ',', '.' };
        private readonly Bitmap _bitmap;

        public BitmapToASCII(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }      

        public char[][] Convert()
        {
            var result = new char[_bitmap.Height][];

            for (int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for (int x = 0; x < _bitmap.Width; x++)
                {
                    int mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, _asciiTableNegative.Length - 1);
                    result[y][x] = _asciiTableNegative[mapIndex];
                }
            }
            return result;
        }

        private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
        {
            return (valueToMap- start1) / (stop1 - start1) * (stop2  - start2) + start2;
        }
    }
}
