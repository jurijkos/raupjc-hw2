using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
namespace UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        //adding one element
        public void Task2TestMethod1()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Running");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //trying to add null on the list
        public void Task2TestMethod2()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }
        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        //testing when two same elements are added
        public void Task2Method3()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Running");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }
        [TestMethod]
        public void GetMethod()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Running");
            repository.Add(todoItem);
        
            var item = repository.Get(todoItem.Id);
            Assert.AreEqual(item, todoItem);
        }
        [TestMethod]
        public void RemoveMethod()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Running");
            repository.Add(todoItem);
        
            repository.Remove(todoItem.Id);
            Assert.AreEqual(repository.GetAll().Count(), 0);
        
        }
        [TestMethod]
        public void RemoveMethodTodoNotInList()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Running");
            repository.Add(todoItem);
        
            var todoItem2 = new TodoItem("Gym");
            Assert.AreEqual(false, repository.Remove(todoItem2.Id));
        
        }
        [TestMethod]
        public void UpdateMethodAndMarkAsCompletedMethod()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Running");
            repository.Add(todoItem);
            repository.MarkAsCompleted(todoItem.Id);
            repository.Update(todoItem);
            Assert.AreEqual(true, repository.Get(todoItem.Id).IsCompleted);
        }
        [TestMethod]
        public void GetCompletedAndGetActiveMethodTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem1 = new TodoItem("arh2");
            var todoItem2 = new TodoItem("tinf");
            var todoItem3 = new TodoItem("opp");
            var todoItem4 = new TodoItem("projekt");
            var todoItem5 = new TodoItem("kommre");
            var todoItem6 = new TodoItem("okolis");
            repository.Add(todoItem1);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem4);
            repository.Add(todoItem5);
            repository.Add(todoItem6);
            
            repository.MarkAsCompleted(todoItem1.Id);
            repository.MarkAsCompleted(todoItem6.Id);
            Assert.AreEqual(4, repository.GetActive().Count);
            Assert.AreEqual(2, repository.GetCompleted().Count);
           
        
        }

    }
}
