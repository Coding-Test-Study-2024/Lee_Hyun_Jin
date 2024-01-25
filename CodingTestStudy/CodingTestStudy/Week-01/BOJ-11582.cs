using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy.Week_01
{
    public class BOJ_11582
    {
        int[] arr;
        int worker;
        public void Run()
        {
            Input(); //입력
            MergeSort(0, arr.Count() - 1, 1); //분할정렬
            Out(); //출력
        }

        void Input()
        {
            int arraySize = int.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(" ");
            worker = int.Parse(Console.ReadLine());
            arr = new int[arraySize];   

            for (int i = 0; i < arraySize; i++)
                arr[i] = int.Parse(str[i]);
        }

        void MergeSort(int start, int last,int count) //시작지점 ,종료지점 ,일하고있는 인원
        {
            if (start == last)//더이상 분할 불가할 경우 점프
                return;

            count <<= 1; //작업인원 2배 증가
            int mid = (start + last) >> 1; //중간 지점 추출(양 끝을 더한 뒤 2로 나눈 값)
            MergeSort(mid + 1,  last,   count); //중간지점으로부터 앞부분 재귀
            MergeSort(start,    mid,    count); //중간지점으로부터 뒷부분 재귀

            if (count <= (worker)) //일하고있는 인원이 확인하고싶은 지점보다 같거나 작을 경우 정렬 점프
                return;
            else
                Merge(start,mid,last);
        }

        void Merge(int start,int mid, int last) //병합 정렬
        {
            int left = start; //앞부분 시작지점
            int leftLast = mid;//앞부분 종료지점

            int right = mid + 1; //뒷부분 시작지점
            int rightLast = last;//뒷부분 종료지점

            List<int> ints = new List<int>((last + 1) - start); //임시저장배열

            while(left <= leftLast && right <= rightLast)
            {
                if (arr[left] > arr[right])
                    ints.Add(arr[right++]);
                else
                    ints.Add(arr[left++]);
            }

            if (left > leftLast)
                while (right <=rightLast)
                    ints.Add(arr[right++]);
            else
                while(left<= leftLast)
                    ints.Add(arr[left++]);

            for (int i = 0; i < ints.Count; i++)
                arr[i + start] = ints[i];
        }

        void Out() //출력
        {
            StringBuilder sb = new StringBuilder(); 
            for (int i = 0; i < arr.Count(); i++)
            {
                sb.Append(arr[i]); 
                sb.Append(' ');
            }
            Console.Write(sb.ToString());
        }
    }
}
