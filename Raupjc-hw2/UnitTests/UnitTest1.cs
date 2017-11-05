using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Task1;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Task1TestMethod1()
        {
            var topStudents = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Luka", jmbag: "3274272"),
                new Student("Ana", jmbag: "9382832")
            };
            var ivan = new Student("Ivan", jmbag: "001234567");
            Assert.IsTrue(topStudents.Contains(ivan));
        }
        [TestMethod]
        public void Task1TestMethod2()
        {
            var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Ivan", jmbag: "001234567")
            };
            var distinctStudentsCount = list.Distinct().Count();
            Assert.AreEqual(1, distinctStudentsCount);
        }
        [TestMethod]
        public void Task1TestMethod3()
        {
            var topStudents = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Luka", jmbag: "3274272"),
                new Student("Ana", jmbag: "9382832")
            };
            var ivan = new Student("Ivan", jmbag: "001234567");
            Assert.IsTrue(topStudents.Any(s => s == ivan));
        }
    }
}
