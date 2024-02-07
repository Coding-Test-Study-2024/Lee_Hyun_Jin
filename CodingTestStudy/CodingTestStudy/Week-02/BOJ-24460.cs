using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy.Week_02
{
    internal class BOJ_24460
    {
        public void Main()
        {
            int count = int.Parse(Console.ReadLine());
            if (count == 0)
                return;
            int[,] array = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                string[] value = Console.ReadLine().Split(" ");
                for (int j = 0; j < value.Length; j++)
                {
                    array[i, j] = int.Parse(value[j]);
                }
            }

            List<int> numTwo = new List<int>();

            Split(array, 0, 0, count, count, numTwo);
            numTwo.Sort();
            if (numTwo.Count > 1)
                Console.WriteLine(numTwo[1]);
            else
                Console.WriteLine(numTwo[0]);
        }

        private void Split(int[,] array, int yPos, int xPos, int ySize, int xSize, List<int> save)
        {
            if (ySize > 2)
            {
                Split(array, yPos + (ySize >> 1), xPos + (xSize >> 1), ySize >> 1, xSize >> 1, save);
                Split(array, yPos, xPos + (xSize >> 1), ySize >> 1, xSize >> 1, save);
                Split(array, yPos + (ySize >> 1), xPos, ySize >> 1, xSize >> 1, save);
                Split(array, yPos, xPos, ySize >> 1, xSize >> 1, save);
            }
            else
            {
                List<int> list = new List<int>();
                for (int i = yPos; i < yPos + ySize; i++)
                {
                    for (int j = xPos; j < xPos + xSize; j++)
                    {
                        list.Add(array[i, j]);
                    }
                }
                list.Sort();
                save.Add(list[1]);
            }
        }
    }

}
