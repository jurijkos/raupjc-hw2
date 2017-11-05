using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
using Task4;
using Task5;
namespace MojNormalanTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("jurij");
            //ITodoRepository repository = new TodoRepository();
            //repository.Add(null);
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Running");
            repository.Add(todoItem);
            int[] integers = new[] { 1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5 };
            HomeworkLinqQueries.Linq1(integers);
            Console.WriteLine("Task 5");
            Klasa.Part1();
            Klasa.Part2();
            Klasa.Part3();
            Klasa.Part4();
            Klasa.Part5();
            Klasa.Part6();
            Console.Read();
        }
    }
}
