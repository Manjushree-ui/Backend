using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace emp
{
    public class Class1
    {
        EmployeeController emp = new EmployeeController();
        List<Employee> e = null;
        bool _true = false;

        public static bool Addemployee(Employee objVM)

        {
            //string constr = ConfigurationManager.AppSettings["connectionString"];
            //var Client = new MongoClient(constr);
            var dbClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var Db = dbClient.GetDatabase("TestDB");
            var collection = Db.GetCollection<BsonDocument>("Employee");
            var document = new BsonDocument { { "_id", objVM._id }, { "EmployeeName", objVM.EmployeeName }, { "EmployeeData", objVM.EmployeeData } };
            collection.InsertOne(document);
            return true;

        }
        public static int Divide(int numerator, int denominator)
        {
            int result = numerator / denominator;
            return result;
        }
        public static bool Updateemployee(Employee objVM)
        {
            var dbClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var Db = dbClient.GetDatabase("TestDB");
            var collection = Db.GetCollection<BsonDocument>("Employee");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objVM._id);
            var update = Builders<BsonDocument>.Update.Set("EmployeeName", objVM.EmployeeName);
            collection.UpdateOne(filter, update);
            return true;
        }
        public static bool GetAllUserDetails()
        {
            var dbClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var Db = dbClient.GetDatabase("TestDB");
            var collections = Db.GetCollection<BsonDocument>("userdetails");

            var documents = collections.Find(new BsonDocument()).ToList();

            //var collection = db.GetCollection<Employee>("Employee").Find(new BsonDocument()).ToList();
            return true;
        }
       
    }
}
