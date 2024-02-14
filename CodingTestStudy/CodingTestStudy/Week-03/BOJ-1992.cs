using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace CodingTestStudy.Week_03
{
    public  class BOJ_1992
    {
        StringBuilder sb;
        public void Run()
        {
            sb = new StringBuilder();
            int count = int.Parse(Console.ReadLine());
            int[,] map = new int[count,count];
            for (int i = 0; i < count; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j <str.Length; j++)
                {
                    map[i,j] = int.Parse(str[j].ToString());
                }
            }
            Split(map,0,0,count);
            Console.WriteLine(sb.ToString());
        }

        void Split(int[,] map , int x,int y, int size)
        {
            if (size < 1)
            {
                sb.Append(map[x, y].ToString());
                return;
            }

            if (Check(map, x, y, size))
            {
                sb.Append(map[x, y].ToString());
                return;
            }

            sb.Append('(');

            Split(map, x ,              y , size >> 1);
            Split(map, x, y + (size >> 1), size >> 1);
            Split(map, x + (size >> 1), y , size >> 1);
            Split(map, x + (size >> 1), y +  (size >> 1), size >> 1); ;

            sb.Append(')');
        }

        bool Check(int[,]map , int x, int y, int size)
        {
            int checkNum = map[x, y];

            for (int i = y;  i < y + size; i++)
                for (int j = x; j < x + size; j++)
                    if (checkNum != map[j, i])
                        return false;

            return true;
        }
    }
}
