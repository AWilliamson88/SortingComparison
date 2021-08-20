using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSortingComparison
{
    class PayrollSorter
    {
        private int dataSize;
        private int minValue;
        private int maxValue;
        private List<int> unsortedList = new List<int>();

        private string path;
        
        private MergeSort ms;
        private QuickSort qs;
        private InsertionSort insertion;


        public PayrollSorter(int newDataSize) : this(newDataSize, 10000, 10000000)
        {
        }

        public PayrollSorter(int newDataSize, int newMinValue, int newMaxValue)
        {
            dataSize = newDataSize;
            minValue = newMinValue;
            maxValue = newMaxValue;

            ms = new MergeSort();
            qs = new QuickSort();
            insertion = new InsertionSort();

        }

        public void Sort100Times()
        {
            for (int i = 1; i <= 100; i++)
            {
                ClearList();
                FillList();

                ms.Sort(GetUnsortedList());
                qs.Sort(GetUnsortedList());
                insertion.Sort(GetUnsortedList());

                DisplayCount(i);

            }

            // Shows the last random list.
            Display();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Shows the last ordered list.
            ms.Display();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Shows the last ordered list.
            qs.Display();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            insertion.Display();
        }

        private void DisplayCount(int count)
        {
            Console.WriteLine(count);
        }
        public void Display()
        {
            foreach (int i in GetUnsortedList())
            {
                Console.WriteLine(i);
            }
        }

        private void FillList()
        {
            Random rnd = new Random();

            int size = GetSize();
            int min = GetMinValue();
            int max = GetMaxValue();

            for (int i = 0; i < size; i++)
            {
                unsortedList.Add(rnd.Next(min, max));
            }
        }

        private void ClearList()
        {
            unsortedList = new List<int>();
        }

        public void SaveResultsToCSV()
        {
            try
            {
                int size = GetSize();
                string filePath = GetPath();

                List<double> mergeTime = ms.GetSortTime();
                List<double> quickTime = qs.GetSortTime();
                List<double> insertTime = qs.GetSortTime();

                string csv = "";

                    using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create)))
                    {
                        sw.WriteLine("Dataset Size, Merge Sort, Quick Sort, Insertion Sort");
                        sw.WriteLine(size);

                        for (int i = 0; i < mergeTime.Count(); i++)
                        {
                            csv = "," + mergeTime[i] + "," + quickTime[i] + "," + insertTime[i];

                            sw.WriteLine(csv);
                        }

                    }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to write data to file.");
            }
        }


        public void SetPathWithDataSize(string newPath)
        {
            path = GetSize() + newPath;
        }

        public string GetPath()
        {
            return path;
        }

        private List<int> GetUnsortedList()
        {
            return unsortedList;
        }

        public int GetSize()
        {
            return dataSize;
        }

        public int GetMinValue()
        {
            return minValue;
        }

        public int GetMaxValue()
        {
            return maxValue;
        }
    }
}
