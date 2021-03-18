using BidWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Conversion
{
    public class ExecuteConversion
    {                
        public List<Employee> GetEmployees()
        {
            //reads json output file
            using (StreamReader outText = new StreamReader(ConfigurationManager.AppSettings["OutputFilePath"]))
            {
                string jsonText = outText.ReadToEnd();
                //deserialize json object to collection
                var emp = JsonConvert.DeserializeObject<List<Employee>>(jsonText);
                return emp;
            }
        }
    }
}
