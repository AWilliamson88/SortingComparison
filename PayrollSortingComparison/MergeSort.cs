using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSortingComparison
{
    class MergeSort
    {

        private List<int> mList = new List<int>();
        private List<double> sortTime = new List<double>();

        Stopwatch mergeSortTime;

        public MergeSort()
        {
        }

        public void Sort(List<int> unsortedList)
        {
            ClearList();

            mergeSortTime = Stopwatch.StartNew();
            
            SetList(SortList(unsortedList));

            mergeSortTime.Stop();
            //SetSortTime(mergeSortTime.ElapsedMilliseconds);
            SetSortTime(mergeSortTime.Elapsed.TotalMilliseconds);

        }
        public void Display()
        {
            foreach (int i in GetList())
            {
                Console.WriteLine(i);
            }
        }

        private static List<int> SortList(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = SortList(left);
            right = SortList(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }



        #region accessors

        public List<int> GetList()
        {
            return mList;
        }

        private void SetList(List<int> newSortedList)
        {
            mList.AddRange(newSortedList);
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

        private void ClearList()
        {
            GetList().Clear();
        }
    }
}
