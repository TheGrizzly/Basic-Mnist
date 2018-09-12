using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Basic_Mnist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numIndex;

            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.ReadLine();
            //}
            Console.WriteLine("Ingresa el indice de la imagen: ");
            numIndex = Int32.Parse(Console.ReadLine());

            FileStream fileLabel = new FileStream(@"C:\Users\pc\Desktop\Escuela\ceti\5to\AI\Basic Mnist\t10k-labels.idx1-ubyte", FileMode.Open);
            FileStream fileImg = new FileStream(@"C:\Users\pc\Desktop\Escuela\ceti\5to\AI\Basic Mnist\t10k-images.idx3-ubyte", FileMode.Open);

            BinaryReader brLabels = new BinaryReader(fileLabel);
            BinaryReader brImg = new BinaryReader(fileImg);

            int x1 = brImg.ReadInt32();
            int numImages = brImg.ReadInt32();
            int numRows = brImg.ReadInt32();
            int numCols = brImg.ReadInt32();

            int x2 = brImg.ReadInt32();
            int numLabels = brImg.ReadInt32();

            byte[][] pixels = new byte[28][];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = new byte[28];
            
            for (int i=0; i< 1000; i++)
            {
                for(int j = 0; j<28; j++)
                {
                    for(int k =0; k < 28; k++)
                    {
                        byte b = brImg.ReadByte();
                        pixels[j][k] = b;
                    }
                }

                byte lbl = brLabels.ReadByte();

                if (i == numIndex-1)
                {
                    string s = "";
                    for (int l = 0; l < 28; l++)
                    {
                        for (int m = 0; m < 28; m++)
                        {
                            if (pixels[l][m] == 0)
                                s += " ";
                            else if (pixels[l][m] == 255)
                                s += "0";
                            else
                                s += ".";
                        }
                        s += "\n";
                    }
                    Console.WriteLine(s);
                    Console.WriteLine("Se imprimio el: " + lbl.ToString());
                    Console.ReadLine();
                }
            }

            fileImg.Close();
            brImg.Close();
            fileLabel.Close();
            brLabels.Close();
        }

        /*public class DigitImage
        {
            public byte[][] pixels;
            public byte label;

            public DigitImage(byte[][] pixel, byte label)
            {
                this.pixels = new byte[28][];
                for (int i = 0; i < this.pixels.Length; i++)
                    this.pixels[i] = new byte[28];

                for (int i = 0; i < 28; i++)
                    for (int j = 0; j < 28; j++)
                        this.pixels[i][j] = pixels[i][j];

                this.label = label;
            }

            public override string ToString()
            {
                string s = "";
                for (int i= 0; i < 28 ; i++)
                {
                    for (int j = 0; j < 28 ; j++)
                    {
                        if (this.pixels[i][j] == 0)
                            s += " ";
                        else if (this.pixels[i][j] == 255)
                            s += "0";
                        else
                            s += ".";
                    }
                    s += "\n";
                } 
                return s;
            }
        }*/
    }
}
