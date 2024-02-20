using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy.Week_04
{
    public class Programmers_JoyStick
    {
        public void Run()
        {
            Console.WriteLine(solution("JEROEN"));
        }
        
        public int solution(string name)
        {
            int answer =  0;
            List<int> values = new List<int>();
            bool front = false;
            int aFront = 0;
            int aLast = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if(i > (name.Length >> 1))
                {
                    if (name[i] == 'A')
                        aFront++;
                }
                else
                {
                    if (name[i] == 'A')
                        aLast++;
                }
            }
            front = aFront > aLast ? true : false;
            //values.Add(name.Length - 1);
            List<char> set = new List<char>();

            for (int i = 0; i < name.Length; i++)
                set.Add('A');

            if(front)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] == 'A')
                        continue;
                    int value = (name[i] - 'A') - (('Z' - 'A') >> 1);
                    if (value > 0)
                    {
                        values.Add('Z' - name[i]);
                        Console.WriteLine($"Z - {name[i]} = {90 - name[i]}");
                    }
                    else
                    {
                        values.Add(name[i] - 'A');
                        Console.WriteLine($"A - {name[i]} = {name[i] - 'A'}");
                    }
                    set.Add(name[i]);
                    bool isCheck = true;
                    for (int j = 0; j < set.Count; j++)
                    {
                        if (set[i] != name[i])
                        {
                            isCheck = false;
                        }
                    }
                    if (isCheck)
                        break;
                    if (name.Length - 1 > i)
                        values.Add(1);
                }
            }
            else
            {
                for (int i = name.Length - 1; i >= 0 ; i--)
                {
                    if (name[i] == 'A')
                        continue;
                    int value = (name[i] - 'A') - (('Z' - 'A') >> 1);
                    if (value > 0)
                    {
                        values.Add('Z' - name[i]);
                        Console.WriteLine($"Z - {name[i]} = {90 - name[i]}");
                    }
                    else
                    {
                        values.Add(name[i] - 'A');
                        Console.WriteLine($"A - {name[i]} = {name[i] - 'A'}");
                    }
                    set.Add(name[i]);
                    bool isCheck = true;
                    for (int j = 0; j < set.Count; j++)
                    {
                        if (set[i] != name[i])
                        {
                            isCheck = false;
                        }
                    }
                    if (isCheck)
                        break;
                    if (0 < i)
                        values.Add(1);
                }
            }

            foreach (int i in values) { answer += i; }


            return answer;
        }
    }
}
