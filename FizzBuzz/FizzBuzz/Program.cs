using System;
using System.Text;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter comma separated collection :");
            string valueCollection = Console.ReadLine();
            StringBuilder retResult = new StringBuilder();
            foreach(var val in valueCollection.Split(','))
            {
                int item;
                if(int.TryParse(val, out item))
                {
                   string output = string.Empty;
                    if (item % 3 == 0) output = "Fizz";
                    if (item % 5 == 0) output += "Buzz";
                    if (string.IsNullOrWhiteSpace(output)) { retResult.AppendLine($"Divided {item} By 3"); retResult.AppendLine($"Divided {item} By 5"); }
                    else retResult.AppendLine(output); 
                }
                else
                {
                    retResult.AppendLine("Invalid Item");
                }
            }
            Console.WriteLine(retResult.ToString());
            Console.ReadLine();
        }
    }
}
