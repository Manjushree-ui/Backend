using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class Repository
    {
        public bool Addemployee(Employee objVM)
        {
            //string constr = "mongodb://localhost:27017/";

            //var Client = new MongoClient(constr);
            var dbClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var Db = dbClient.GetDatabase("TestDB");
            var collection = Db.GetCollection<BsonDocument>("Employee");
            var document = new BsonDocument { { "_id", objVM._id }, { "EmployeeName", objVM.EmployeeName }, { "EmployeeData", objVM.EmployeeData } };
            collection.InsertOne(document);
            return true;
        }

        public bool Updateemployee(Employee objVM)
        {
            string constr = ConfigurationManager.AppSettings["connectionString"];
            var Client = new MongoClient(constr);
            var Db = Client.GetDatabase("TestDB");
            var collection = Db.GetCollection<BsonDocument>("Employee");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objVM._id);
            var update = Builders<BsonDocument>.Update.Set("EmployeeName", objVM.EmployeeName);
            collection.UpdateOne(filter,update);
            return true;
        }
        public bool GetAllUserDetails()
        {
            string constr = ConfigurationManager.AppSettings["connectionString"];
            var Client = new MongoClient(constr);
            var db = Client.GetDatabase("TestDB");
            var collections = db.GetCollection<BsonDocument>("userdetails");

            var documents = collections.Find(new BsonDocument()).ToList();

            //var collection = db.GetCollection<Employee>("Employee").Find(new BsonDocument()).ToList();
            return true;
        }
    }
}