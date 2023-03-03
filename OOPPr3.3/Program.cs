using System;
using System.Drawing;
using System.IO;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Bitmap image2 = new Bitmap("image2.jpg");

            
            Func<Bitmap, Bitmap> greenscale = (Bitmap image) =>
            {
                Bitmap greenImage = new Bitmap(image.Width, image.Height);

                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        int greenValue = (int)(0.255 * pixelColor.R + 0.255 * pixelColor.G + 0.255 * pixelColor.B);
                        Color greenColor = Color.FromArgb(pixelColor.A, greenValue, greenValue, greenValue);
                        greenImage.SetPixel(x, y, greenColor);
                    }
                }

                return greenImage;
            };

            Action<Bitmap> display = (Bitmap image) =>
            {
                image.Save("processed.jpg");
                System.Diagnostics.Process.Start("processed.jpg");
            };

            Bitmap processedImage2 = greenscale(image2);

            Console.WriteLine("Processed image is opening in your computer");

            display(processedImage2);
        }
    }
}