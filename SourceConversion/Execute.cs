using Newtonsoft.Json;
using System;
using System.Collections;
using System.Configuration;
using System.IO;
using BidModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BidConversion
{
    public static class Execute
    {
        public static async Task<string> ReadTxtFile()
        {
            //defined filenames in app config 
            var strText = File.ReadAllText(ConfigurationManager.AppSettings["InputFilePath"]);
            string[] lines = File.ReadAllLines(ConfigurationManager.AppSettings["InputFilePath"]);
            List<Employee> empList = new List<Employee>();
            foreach (string line in lines)
            {
                var single_line = line.Trim();
                if (single_line.Length > 0)
                {
                    //split ea line by pipe separator
                    var value_split = single_line.Split(Char.Parse("|"));                                 
                    Employee employee = new Employee();
                    //build employee obj
                    employee.id = value_split[0].ToString();
                    employee.firstname = value_split[1].ToString();
                    employee.surname = value_split[2].ToString();
                    employee.email = value_split[3].ToString();
                    employee.gender = value_split[4].ToString();
                    employee.ip = value_split[5].ToString();
                    //build employee list
                    empList.Add(employee);
                }
            }            
            //return serialized data
            return JsonConvert.SerializeObject(empList);
        }


        public static async void WriteJSONFile(string jsonText)
        {
            //dispose writer when done
            using (StreamWriter writer = File.CreateText(ConfigurationManager.AppSettings["OutputFilePath"]))
            {
                //write output to file
                await writer.WriteAsync(jsonText);
            }
        }        
    }
}
