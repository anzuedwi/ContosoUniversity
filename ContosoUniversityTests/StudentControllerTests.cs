using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using ContosoUniversity.Controllers;
using ContosoUniversity.Models;

namespace ContosoUniversityTests
{
    [TestClass]
    public class StudentControllerTests
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new StudentController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestStudentDetailViewData()
        {
            var controller = new StudentController();
            var result = controller.Details(7) as ViewResult;

            var student = (Student) result.ViewData.Model;

            Student newStudent = new Student();
            newStudent.FirstName = "Edwin";

            Assert.AreEqual(2, student.Enrollments.Count());
            Assert.AreEqual("Laura", student.FirstName);
            Assert.AreEqual("Norman", student.LastName);

            var enrollments = student.Enrollments;
            Assert.AreEqual(1, enrollments.Count);
            Assert.AreEqual(Grade.A, enrollments.Select(enrolled => enrolled.Grade).Single());

            //Adding Sample Test for ContosoUniversity
        }
        [TestMethod]
    }
}
