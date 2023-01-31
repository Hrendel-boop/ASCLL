using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ASCLL
{
    internal class Program
    {
        private const double WIDTH_OFFSET = 1.7;       

        [STAThread]
        static void Main()
        {           
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
            };

            Console.WriteLine("Нажмитее Enter чтобы выбрать изображение...\n");
            while (true)
            {
                Console.ReadKey();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    continue;
                }               

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGray();

                var converter = new BitmapToASCII(bitmap);                              
                var rowsNegative = converter.Convert();
                File.WriteAllLines("pix.txt", rowsNegative.Select(r => new string(r)));
                Console.Clear();

                Console.WriteLine("Изображение было сохранено в папке с приложением (pix.txt)\n Ctrl - / +  , чтобы масштабировать");
                Console.WriteLine("Нажмите Enter, чтобы выбрать другое изображение");
            }

        }
        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            Console.WriteLine("Введите разрешение изображения от 3 до 421");

            
                while (true)
                {

                    int maxWidth;
                    if (int.TryParse(Console.ReadLine(), out maxWidth))
                    {
                        if (maxWidth > 421 || maxWidth < 3)
                        {
                            Console.WriteLine("Вы ввели слишком маленькое или большое значение");
                            continue;
                        }
                        var newHeight = bitmap.Height / WIDTH_OFFSET * maxWidth / bitmap.Width;
                        if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                        {
                            bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));
                        }
                        return bitmap;
                    
                    }
                    else
                    {
                        Console.WriteLine("Вводи цифры а не буквы еблан");
                        continue;
                    }
                }                                                                                     
        }
    }
}
