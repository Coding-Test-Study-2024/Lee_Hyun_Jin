using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy.Week_01
{
    public class Num_Of_Relatives
    {
        int total;
        int start;
        int end;
        int[] parent;
        bool[,] graph;

        public void Run()
        {
            Input(); 
            Search();
            Result();
        }

        public void Input()
        {
            total = int.Parse(Console.ReadLine()) + 1;
            graph = new bool[total,total];

            string[] str = Console.ReadLine().Split(" ");
            start = int.Parse(str[0]); //첫번째가 출발지
            end = int.Parse(str[1]); //두번째가 도착지

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++) 
            {
                str = Console.ReadLine().Split(" ");

                int x = int.Parse(str[0]);
                int y = int.Parse(str[1]);
                //양방향 그래프로 제작
                graph[x , y] = true; 
                graph[y , x] = true;
            }
        }


        void Search()
        {
            //변수 생성 및 초기화 
            Queue<int> queue = new Queue<int>();
            parent = new int[total];
            bool[] visited = new bool[total];
            for (int i = 0; i < total; i++)
            {
                parent[i] = -1;
            }

            //시작 정점을 지정
            visited[start] = true;
            queue.Enqueue(start);

            //넓이 탐색 시작
            while (queue.Count > 0 )
            {
                int current = queue.Dequeue();
                for (int i = 0; i < total; i++)
                {
                    if (visited[i] == false && graph[current,i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                        parent[i] = current;
                        //목표를 발견했는지 확인
                        if (i == end)
                            return;
                    }
                }
            }
        }

        void Result()
        {
            int save = parent[end];
            //탐색에 실패했을 경우
            if (save == -1) 
                Console.WriteLine(-1);
            else
            {
                int count = 0;
                //시작지점에 도착할때까지 거슬러 올라가기
                while (parent[save] != -1)
                {
                    save = parent[save];
                    count++;
                }
                Console.WriteLine(count + 1);
            }
        }
    }
}
