using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Controllers;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //emp.Class1 = new emp.Class1();
        List<Employee> e = null;
        bool _true = false;
        [TestMethod]
        public void Test_Divide()
        {
            
            //Arrange
            int expected = 5;
            int numerator = 20;
            int denominator = 4;
            //Act
            int actual = emp.Class1.Divide(numerator, denominator);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void InsertEmployee()
        {
            Employee obj = new Employee { _id = 89, EmployeeName = "testing ssss", EmployeeData = "Bangalore" };
            _true = emp.Class1.Addemployee(obj);
            Assert.AreEqual(true, _true);

           
        }
        [TestMethod]
        public void UpdateEmployee()
        {
            Employee obj = new Employee { _id = 5 };
            _true = emp.Class1.Updateemployee(obj);
            Assert.AreEqual(true, _true);


        }
        [TestMethod]
        public void Test_ObjNull(Expression expr)
        {
            Employee obj = new Employee { _id = 5, EmployeeName = "testing ssss", EmployeeData = "Bangalore" };

            if (obj == null)
                throw new ArgumentException("Expression body is not a constructor call", nameof(expr));
        }
     
        [TestMethod]
        public virtual async Task<bool> GetData()
        {
            TaskCompletionSource<bool> ts = new TaskCompletionSource<bool>();
          _true = emp.Class1.GetAllUserDetails();
            if (_true)
            {
               
                ts.SetResult(true);
            }
            else
            {
               
                ts.SetResult(false);
            }
            return await ts.Task;
        }

      

        [TestMethod]
        public void Test_GetData()
        {
           
            _true = emp.Class1.GetAllUserDetails();
            Assert.IsTrue(_true);
        }
        [TestMethod]
        public void Employee(string EmployeeName)
        {
           
            if (EmployeeName == "") throw new ArgumentNullException(nameof(EmployeeName));

        }
        [TestMethod]
        public void Test_fieldProperty()
        {
            Employee newSampleClass = new Employee { _id = 2, EmployeeName="Manjushree" };
            Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject pobject = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(newSampleClass);

            Assert.AreEqual<int?>(2, pobject.GetFieldOrProperty("_id") as int?);
            Assert.AreEqual<string>("Manjushree", pobject.GetFieldOrProperty("EmployeeName") as string);
        }
        public string combineArrayStringWithSpace(string[] stringArray)
        {
            string str = default(string);

            foreach (string item in stringArray)
            {
                str += item + " ";
            }

            return str.Trim();
        }
        [TestMethod]
        public void combineArrayStringWithSpaceTest()
        {
           
            string[] stringArray = null; 
            string expected = string.Empty; 
            string actual;
            actual = combineArrayStringWithSpace(stringArray);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
       
    }
}
