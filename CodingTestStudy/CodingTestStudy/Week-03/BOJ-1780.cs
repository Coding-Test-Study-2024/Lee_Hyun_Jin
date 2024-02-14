using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy.Week_03
{
    public class BOJ_1780
    {

        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            int[,] map = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                for (int j = 0; j < str.Length; j++)
                {
                    map[i, j] = int.Parse(str[j]);
                }
            }

            int zeroCount, minusCount, plusCount;
            zeroCount = minusCount = plusCount = 0;

            Split(map, 0, 0, count, ref zeroCount, ref minusCount, ref plusCount);


            Console.WriteLine(minusCount);
            Console.WriteLine(zeroCount);
            Console.WriteLine(plusCount);


        }
        void Split(int[,] map, int x, int y, int size, ref int zero, ref int minus, ref int plus)
        {
            if(Check(map, x, y, size))
            {
                if (map[x, y] == 0)
                    zero++;
                else if (map[x,y] == -1)
                    minus++;
                else
                    plus++;

                return;
            }
            else
            {
                    int nextSize = size / 3;

                    Split(map, x, y, nextSize, ref zero, ref minus, ref plus);
                    Split(map, x, y + nextSize, nextSize, ref zero, ref minus, ref plus);
                    Split(map, x + nextSize, y, nextSize, ref zero, ref minus, ref plus);
                    Split(map, x + nextSize, y + nextSize, nextSize, ref zero, ref minus, ref plus); ;

                    Split(map, x + nextSize, y + nextSize + nextSize, nextSize, ref zero, ref minus, ref plus);
                    Split(map, x + nextSize + nextSize, y + nextSize, nextSize, ref zero, ref minus, ref plus);

                    Split(map, x, y + nextSize + nextSize , nextSize, ref zero, ref minus, ref plus);
                    Split(map, x + nextSize + nextSize, y, nextSize, ref zero, ref minus, ref plus);
                    Split(map, x + nextSize + nextSize, y + nextSize + nextSize, nextSize, ref zero, ref minus, ref plus); ;

            }

        }
        bool Check(int[,] map, int x, int y, int size)
        {
            int checkNum = map[x, y];
            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                    if (checkNum != map[i, j])
                        return false;
                }
            }
            return true;
        }
    }
}
