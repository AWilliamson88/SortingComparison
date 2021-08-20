using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace PayrollSortingComparison
{
    class Program
    {
        static void Main(string[] args)
        {


            PayrollSorter dataset = new PayrollSorter(1000);
            dataset.SetPathWithDataSize("SortTimes.csv");
            dataset.Sort100Times();
            dataset.SaveResultsToCSV();

            Console.WriteLine("Done");
            Console.ReadLine();


        }

        
    }
}
