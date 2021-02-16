using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;
using MongoDB.Bson;
using WebApplication3.Models;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using System.Web.Http.Cors;
using MongoDB.Driver.Linq;
using System.Xml.Linq;

namespace WebApplication3.Controllers
{
    public class EmployeeController : ApiController
    {
      
        [Authorize]
        [Route("api/insertemployee")]
        [HttpPost]
        public bool Addemployee(Employee objVM)
        {
         
            var dbClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var Db = dbClient.GetDatabase("TestDB");
        var collection = Db.GetCollection<BsonDocument>("Employee");
            var document = new BsonDocument { { "_id", objVM._id }, { "EmployeeName", objVM.EmployeeName }, { "EmployeeData", objVM.EmployeeData } };
            collection.InsertOne(document);
            return true;
    }
        [Route("api/UpdateEmployee")]
        [HttpPut]
        public bool UpdateCollection(Employee objVM)
        {
            var dbClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var Db = dbClient.GetDatabase("TestDB");

            var collection = Db.GetCollection<Employee>("Employee");
            var update = collection.FindOneAndUpdateAsync(Builders<Employee>.Filter.Eq("Id", objVM._id), Builders<Employee>.Update.Set("EmployeeName", objVM.EmployeeName).Set("EmployeeData", objVM.EmployeeData));
            return true;
        }
        #region DeleteEmployee  
        [Route("api/delete")]
        [HttpGet]
        public object Delete(string name)
        {
            try
            {
                string constr = ConfigurationManager.AppSettings["connectionString"];
                var Client = new MongoClient(constr);
                var DB = Client.GetDatabase("TestDB");
                var collection = DB.GetCollection<BsonDocument>("Employee");
                var deleteFilter = Builders<BsonDocument>.Filter.Eq("EmployeeName", name);
                collection.DeleteOne(deleteFilter);
                return new Status
                { Result = "Success", Message = "Employee Details Delete  Successfully" };
            }
            catch (Exception ex)
            {
                return new Status
                { Result = "Error", Message = ex.Message.ToString() };
            }
        }
        #endregion

        #region Getemployeedetails  
        [Route("api/getAllemployee")]
        [HttpGet]
        public object GetAllEmployee()
        {
            string constr = ConfigurationManager.AppSettings["connectionString"];
            var Client = new MongoClient(constr);
            var db = Client.GetDatabase("TestDB");
            var collections = db.GetCollection<Employee>("Employee");

         
            var collection = db.GetCollection<Employee>("Employee").Find(new BsonDocument()).ToList();
            return Json(collection);
        }


        [Route("api/GetEmployeeDetailsById")]
        [HttpGet]
        public Employee GetEmployeeById(int id)
        {
            string constr = ConfigurationManager.AppSettings["connectionString"];
            var Client = new MongoClient(constr);
            var db = Client.GetDatabase("TestDB");
            var coll = db.GetCollection<Employee>("Employee");
            Employee emp = coll.Find(_ => _._id == id).FirstOrDefault();
            return emp;
        }

       
        #endregion
    }
}
