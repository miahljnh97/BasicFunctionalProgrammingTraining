using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicFunctionalProgrammingTraining
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = Enumerable.Range(1, 20);


            //ini adalah contoh implementasi imperative
            var oddNum = new List<int>();
            foreach (var k in numbers)
            {
                if (k % 2 == 0)
                {
                    oddNum.Add(k);
                }
            }
            Console.WriteLine("oddNum : ");
            Console.WriteLine(String.Join(",", oddNum));
            Console.WriteLine("\n");


            //ini adalah contoh implementasi declarative
            var oddNumber = numbers.Where(num => num % 2 == 0);
            Console.WriteLine("oddNumber : ");
            Console.WriteLine(String.Join(",", oddNumber));
            Console.WriteLine("\n");

            //ini adalah contoh implementasi FunctionalProgrammingParadigm
            Func<int, bool> oddNumbers = num => num % 2 == 0; // ini masih kondisi, belum merunning apapun
            var oddNumberss = numbers.Where(oddNumbers);
            Console.WriteLine("oddNumberss : ");
            Console.WriteLine(String.Join(",", oddNumberss)); //ini juga error
            Console.WriteLine("\n");

            //Bisa juga pakai cara ini
            // Itterate(numbers, Console.WriteLine);
            // dipake kalo Itterate masih di dalam class program

            //ini dipake kalo udah berbeda class
            Console.WriteLine("numbers.Itterate : ");
            numbers.Itterate(k => Console.Write($"{k}, "));
            Console.WriteLine("\n");

            //ini untuk class Money
            var moneys = new Money(1000.00m);
            Console.WriteLine("moneys : ");
            Console.WriteLine(moneys.Value);
            Console.WriteLine("\n");

            var addMoneys = Money.Add(moneys, 10.5m);
            Console.WriteLine("addMoneys : ");
            Console.WriteLine(addMoneys.Value);
            Console.WriteLine("\n");

            //Hitung Median
            var doubleList = new List<double> { 1.3, 2.4, 8 };
            var result = doubleList.Median();
            Console.WriteLine("doubleList : ");
            Console.WriteLine(result);
            Console.WriteLine("\n");

            //Hitung Median2
            var doubleList2 = new[] { "satu", "dua", "tiga" };
            var result2 = doubleList2.Median(k => k.Length);
            Console.WriteLine("doubleList2 : ");
            Console.WriteLine(result2);
            Console.WriteLine("\n");

        }

    }

    public static class IEnumberableExtension
    {
        public static void Itterate<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var k in values)
            {
                action(k);
            }
        }

        public static double Median(this IEnumerable<double> values)
        {
            if (values.Count() == 0)
            {
                throw new InvalidOperationException("Cannot compute median for empty");
            }

            var sortedList = values.Select(k => k).OrderBy(k => k);
            int itemIndex = (int)sortedList.Count() / 2;
            //return sortedList.Count() % 2 == 0 ? sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1): sortedList.ElementAt(itemIndex);
            if (sortedList.Count() % 2 == 0)
            {
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;
            }
            return sortedList.ElementAt(itemIndex);
        }

        public static double Median<T>(this IEnumerable<T> numbers, Func<T, double> selector)
        {
            return numbers.Select(k => selector(k)).Median();
        }
    }

    public class Money
    {
        public decimal Value { get; }
        public Money(decimal value) => Value = value;


        public static Money Add(Money money, decimal value) => new Money(money.Value + value);
    }
}