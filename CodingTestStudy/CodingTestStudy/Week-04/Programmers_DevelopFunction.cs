using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy.Week_04
{
    public class Programmers_DevelopFunction
    {
        public void Run()
        {
            int[] first = { 95, 90, 99, 99, 80, 99 };
            int[] second = { 1, 1, 1, 1, 1, 1 };
            int[] returnValue =  solution(first, second);
            foreach (int i in returnValue) 
            { 
                Console.Write($"{i} ");
            }
        }
        public enum WorkState
        { 
            Work, Finish, Clear,
        }
        public class WorkProcess
        {
            int progress;
            int speed;
            bool isFinish;
            public WorkProcess(int progress, int speed)
            {
                this.progress = progress; ;
                this.speed = speed;
            }

            public WorkState Work()
            {
                if (isFinish)
                    return WorkState.Finish;
                progress += speed;
                if (progress >= 100)
                {
                    isFinish = true;
                    return WorkState.Clear;
                }
                else
                    return WorkState.Work;
            }
        }
        public int[] solution(int[] progresses, int[] speeds)
        {
            List<WorkProcess> calcul = new List<WorkProcess>();
            for (int i = 0; i < progresses.Length; i++)
                calcul.Add(new WorkProcess(progresses[i], speeds[i]));

            List<int> result = new List<int>();

            while(calcul.Count > 0)
            {
                bool isRemove = false; ;
                List<WorkProcess> removeProcess = new List<WorkProcess> ();
                for (int i = 0; i < calcul.Count; i++)
                {
                    WorkState workState = calcul[i].Work();
                    if (i == 0 && workState != WorkState.Work)
                        isRemove = true;
                    
                    if (workState != WorkState.Work)
                    { 
                        if(isRemove)
                            removeProcess.Add(calcul[i]);
                    }
                    else
                    {
                        isRemove = false;
                    }
                }
                if(removeProcess.Count > 0)
                {
                    result.Add(removeProcess.Count);
                    for (int i = 0; i < removeProcess.Count; i++)
                        calcul.Remove(removeProcess[i]);
                    removeProcess.Clear();
                }
            }
            return result.ToArray();
        }
    }
}
