using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSortingComparison
{
    class QuickSort
    {
        private List<int> qList = new List<int>();
        private List<double> sortTime = new List<double>();

        Stopwatch quickSortTime;

        public QuickSort()
        {
            
        }

        // Where the sorting starts.
        public void Sort(List<int> unsortedList)
        {
            ClearList();
            SetList(unsortedList);

            int length = GetList().Count();

            quickSortTime = Stopwatch.StartNew();
            
            SortList(GetList(), 0, length - 1);

            quickSortTime.Stop();
            SetSortTime(quickSortTime.Elapsed.TotalMilliseconds);

        }

        private void ClearList()
        {
            GetList().Clear();
        }

        public void Display()
        {
            foreach (int i in GetList())
            {
                Console.WriteLine(i);
            }
        }

        private void SortList(List<int> list, int left, int right)
        {

            if (left < right)
            {
                int pivot = Partition(list, left, right);

                if (pivot > 1)
                {
                    SortList(list, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    SortList(list, pivot + 1, right);
                }
            }

        }

        private int Partition(List<int> list, int left, int right)
        {
            int pivot = list[left];
            while (true)
            {

                while (list[left] < pivot)
                {
                    left++;
                }

                while (list[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = list[left];
                    list[left] = list[right];
                    list[right] = temp;
                    
                    if (list[left] == list[right])
                    {
                        left++;
                    }

                }
                else
                {
                    return right;
                }
            }
        }

        #region accessors

        public List<int> GetList()
        {
            return qList;
        }

        private void SetList(List<int> newList)
        {
            qList.AddRange(newList);
        }

        public List<double> GetSortTime()
        {
            return sortTime;
        }

        public void SetSortTime(double newSortTime)
        {
            sortTime.Add(newSortTime);
        }

        #endregion

    }
}
