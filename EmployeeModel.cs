using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace ClassLibrary1
{
   public class EmployeeModel
    {
        public EmployeeModel()
        {
            LstEmployee = new List<EmployeeModel>();
        }
        [JsonProperty("_id")]
        public int _id { get; set; }
        [JsonProperty("EmployeeName")]
        public string EmployeeName { get; set; }
        [JsonProperty("EmployeeData")]
        public string EmployeeData { get; set; }
        public List<EmployeeModel> LstEmployee { get; set; }
    }
}
