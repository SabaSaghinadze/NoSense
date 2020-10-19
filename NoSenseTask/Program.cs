using System;
using System.Collections.Generic;

namespace NoSenseTask
{
    using CustomExtensions;

    public static class Program
    {
        public delegate T CustomDelegate<T>(T item);
        static void Main(string[] args)
        {
            var rightPredicate = 23;
            var wrongPredicate = 90;
            CustomDelegate<int> del = NewItem;

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

            var first = numbers.ThisDoesNotMakeAnySense(number => number == rightPredicate, del);
            Console.WriteLine($"First: \n \t Collection: [{str}] \n \t Predicate: {rightPredicate} \n \t Result: {first}");

            var second = numbers.ThisDoesNotMakeAnySense(number => number == wrongPredicate, del);
            Console.WriteLine($"Second: \n \t Collection: [{str}] \n \t Predicate: {wrongPredicate} \n \t Result: {second}");

            // This line below will throw an exception
            // var third = noNumbers.ThisDoesNotMakeAnySense(number => number == rightPredicate, del);

            
            CustomDelegate<string> delegateForString = NewItem;
            List<string> names = new List<string>()
            {
                "Xareba", "Gogia"
            };

            var fourth = names.ThisDoesNotMakeAnySense(name => name == "Mushni Zarandia", delegateForString);
            Console.WriteLine($"Fourth: \n \t Collection: [{string.Join(", ", names)}] \n \t Predicate: MushniZarandia \n \t Result: {fourth}");
        }

        public static T NewItem<T>(T item)
        {
            dynamic result = default;

            switch (typeof(T).Name)
            {
                case nameof(Int32):
                    result = new Random().Next();
                    break;
                case nameof(Double):
                    result = new Random().NextDouble();
                    break;
                case nameof(Boolean):
                    result = true;
                    break;
                case nameof(String):
                    result = "Eg sxva filmia";
                    break;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
