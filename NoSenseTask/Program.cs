using System;
using System.Collections.Generic;

namespace NoSenseTask
{
    using CustomExtensions;
    using System.Linq;

    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers: ");
            var str = Console.ReadLine();
            var parts = str.Split(", ");

            List<int> numbers = new List<int>();

            foreach (var part in parts)
            {
                try
                {
                    numbers.Add(int.Parse(part));
                }
                catch
                {
                    throw new ArgumentException("String, which the user has entered, is invalid");
                }
            }

            int[] noNumbers = null;

            var sorted = numbers.ToList();
            sorted.Sort();

            var first = numbers.ThisDoesNotMakeAnySense(number => number == numbers[0], NewItem<int>);
            Console.WriteLine($"First: \n \t Collection: [{str}] \n \t Predicate: {numbers[0]} \n \t Result: {first}");

            var second = numbers.ThisDoesNotMakeAnySense(number => number == (sorted[0]-1), NewItem<int>);
            Console.WriteLine($"Second: \n \t Collection: [{str}] \n \t Predicate: {(sorted[0]-1)} \n \t Result: {second}");

            // This line below will throw an exception
            // var third = noNumbers.ThisDoesNotMakeAnySense(number => number == 3, NewItem<int>);
        }

        public static T NewItem<T>()
        {
            if(typeof(T).Name == nameof(Int32))
            {
                return (T)Convert.ChangeType(new Random().Next(), typeof(T));
            }

            return default;
        }
    }
}
