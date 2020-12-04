using System;

namespace AoCDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = System.IO.File.ReadAllLines(@"C:\Users\harry\Desktop\AdventOfCodeText\Day1.txt");
            for(int i = 0;i< numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        if (int.Parse(numbers[i]) + int.Parse(numbers[j]) + int.Parse(numbers[k]) == 2020)
                        {
                            Console.WriteLine(int.Parse(numbers[i]) * int.Parse(numbers[j]) * int.Parse(numbers[k]));
                        }
                    }
                }
            }

        }
    }
}
