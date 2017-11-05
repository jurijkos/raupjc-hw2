using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            string[] strings = intArray.OrderBy(i => i).GroupBy(i => i).Select(i => $"broj {i.Key} ponavlja se {i.Count()} puta").ToArray();
            foreach(string s in strings)
            {
                Console.WriteLine(s);
            }
            return strings;
        }
        
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(university => university.Students.All(student => student.Gender == Gender.Male)).ToArray();
        }
        
        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray.Where(univeristy => univeristy.Students.Length < universityArray.Average(uni => uni.Students.Length)).ToArray();
        }
        
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(university => university.Students).Distinct().ToArray();
        }
        
        public static Student[] Linq2_4(University[] universityArray)
        {
             
            return universityArray.Where(university => university.Students.All(student => student.Gender == Gender.Male) || university.Students.All(student => student.Gender == Gender.Female)).SelectMany(uni => uni.Students).Distinct().ToArray();
        }
        
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(university => university.Students).GroupBy(student => student).Where(t => t.Count() > 1).Select(t => t.Key).ToArray();
        }


    }
}
