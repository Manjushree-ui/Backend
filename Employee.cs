using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication3.Models
{
    public class Employee
    {
        public Employee()
        {
            LstEmployee = new List<Employee>();
        }
        [JsonProperty("_id")]
        public int _id { get; set; }
        [JsonProperty("EmployeeName")]
        public string EmployeeName { get; set; }
        [JsonProperty("EmployeeData")]
        public string EmployeeData { get; set; }
        public List<Employee> LstEmployee { get; set; }

        public Employee(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jEmployee = jObject["Employee"];
            EmployeeName = (string)jEmployee["EmployeeName"];
            EmployeeData = (string)jEmployee["EmployeeData"];
           
        }

    }


}