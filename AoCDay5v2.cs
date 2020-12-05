using System;
using System.IO;

namespace AoCDay5v2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] boardingPasses = File.ReadAllLines(@"C:\Users\harry\Desktop\AdventOfCodeText\Day5.txt");
            int[] seatFinder = new int[1024];
            int max = 0;
            int rowNum = 0;

            for (int i = 0; i < boardingPasses.Length; i++)
            {
                boardingPasses[i] = boardingPasses[i].Replace('F', '0').Replace('B', '1').Replace('R', '1').Replace('L', '0');
                rowNum = Convert.ToInt32(boardingPasses[i].Substring(0, 7), 2);
                rowNum = rowNum * 8 + Convert.ToInt32(boardingPasses[i].Substring(7, 3), 2);;
                if (rowNum>max)
                {
                    max = rowNum;
                }
                seatFinder[rowNum] = rowNum;
            }
            Console.WriteLine(max);
            for (int i = 1; i < seatFinder.Length-1; i++)
            {
                if ((seatFinder[i] == 0) && (seatFinder[i+1] != 0) && (seatFinder[i-1] != 0))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
