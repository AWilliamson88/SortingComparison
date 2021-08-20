using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSortingComparison
{
    class InsertionSort
    {
        private List<int> iList = new List<int>();
        private List<double> sortTime = new List<double>();

        Stopwatch insertSortTime;

        public InsertionSort()
        {
        }

        public void Sort(List<int> unsortedList)
        {
            ClearList();
            SetList(unsortedList);

            insertSortTime = Stopwatch.StartNew();

            UseInsertionSort(GetList());

            insertSortTime.Stop();
            SetSortTime(insertSortTime.Elapsed.TotalMilliseconds);

        }

        private List<int> UseInsertionSort(List<int> inputList)
        {
            for (int i = 0; i < inputList.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputList[j - 1] > inputList[j])
                    {
                        int temp = inputList[j - 1];
                        inputList[j - 1] = inputList[j];
                        inputList[j] = temp;
                    }
                }
            }
            return inputList;
        }

        public void Display()
        {
            foreach (int i in GetList())
            {
                Console.WriteLine(i);
            }
        }


        #region accessors

        public List<int> GetList()
        {
            return iList;
        }

        private void SetList(List<int> newSortedList)
        {
            iList.AddRange(newSortedList);
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
