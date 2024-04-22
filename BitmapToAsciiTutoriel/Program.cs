using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace BitmapToAsciiTutoriel
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string path = @"C:\Users\V-Vik\Desktop\test_2.png";
            Bitmap image = new Bitmap(path);
            double[,] intensityValues = GetIntensityValues(image);
            WriteTextToFile(intensityValues, @"C:\Users\V-Vik\Desktop\ascii.txt");
            Console.ReadKey();

            // test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static double[,] GetIntensityValues(Bitmap bmp)
        {
            double[,] intensityValues = new double[bmp.Width, bmp.Height];

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color currentPixel = bmp.GetPixel(x, y);

                    int r = currentPixel.R;
                    int g = currentPixel.G;
                    int b = currentPixel.B;

                    intensityValues[x, y] = Math.Round(((r + g + b) / 3) / 255.0, 1);
                }
            }

            return intensityValues;
        }

        static void WriteTextToFile(double[,] intensityValues, string path)
        {
            using (StreamWriter sr = new StreamWriter(path))
            {
                for (int y = 0; y < intensityValues.GetLength(1); y++)
                {
                    for (int x = 0; x < intensityValues.GetLength(0); x++)
                    {
                        string character = " ";

                        switch (intensityValues[x, y])
                        {
                            case 0: character = "@"; break;
                            case 0.1: character = "%"; break;
                            case 0.2: character = "#"; break;
                            case 0.3: character = "*"; break;
                            case 0.4: character = "+"; break;
                            case 0.5: character = "="; break;
                            case 0.6: character = "-"; break;
                            case 0.7: character = ":"; break;
                            case 0.8: character = "."; break;

                        }

                        Console.Write(character + character);
                        sr.Write(character + character);
                    }

                    Console.WriteLine();
                    sr.WriteLine();
                }
            }
        }
    }
}
