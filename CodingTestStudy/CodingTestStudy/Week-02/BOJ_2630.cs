using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy.Week_02
{
    internal class BOJ_2630
    {
        public void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int[,] array = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                for (int j = 0; j < count; j++)
                {
                    array[i, j] = int.Parse(str[j]);
                }
            }
            int white = 0;
            int blue = 0;

            Check(array, 0, 0, count, count, ref white, ref blue);
            Console.WriteLine(white);

            Console.WriteLine(blue);


        }

        private void Check(int[,] array, int xPos, int yPos, int xSize, int ySize, ref int white, ref int blue)
        {
            if (Split(array, xPos, yPos, xSize, ySize))
            {
                if (array[xPos, yPos] == 0)
                    white++;
                else
                    blue++;
                return;
            }
            else
            {
                Check(array, xPos + (xSize >> 1), yPos + (ySize >> 1), xSize >> 1, ySize >> 1, ref white, ref blue);
                Check(array, xPos + (xSize >> 1), yPos, xSize >> 1, ySize >> 1, ref white, ref blue);
                Check(array, xPos, yPos + (ySize >> 1), xSize >> 1, ySize >> 1, ref white, ref blue);
                Check(array, xPos, yPos, xSize >> 1, ySize >> 1, ref white, ref blue);
            }
        }

        private bool Split(int[,] array, int xPos, int yPos, int xSize, int ySize)
        {
            int blue = array[xPos, yPos];
            for (int i = xPos; i < xPos + xSize; i++)
            {
                for (int j = yPos; j < yPos + ySize; j++)
                {
                    if (blue != array[i, j])
                        return false;
                }
            }
            return true;
        }
    }
}
