using System;
using System.Configuration;
using System.IO;
using BidConversion;

namespace BidMain
{
    class Program
    {
        static void Main(string[] args)
        {
            //main prog calling executing task
            ExecuteTask();
        }

        static async void ExecuteTask()
        {
            //reads input file and writes to output file
            Execute.WriteJSONFile(await Execute.ReadTxtFile());
        }
    }
}
