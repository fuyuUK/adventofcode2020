using System;

namespace AoCDay5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] boardingPasses = System.IO.File.ReadAllLines(@"C:\Users\harry\Desktop\AdventOfCodeText\Day5.txt");
            char[] singlePass;
            int[] fillSeat = new int[1024];
            for (int z = 0; z < fillSeat.Length; z++)
            {
                fillSeat[z] = 0;
            }
            int upperBound = 127;
            int lowerBound = 0;
            int middleBound = 0;
            int maxBoard = 0;
            int pointer = 0;
            int tempHold = 0;

            int row = 0;
            int column = 0;
            // Console.WriteLine(upperBound);
            for (int i = 0; i < boardingPasses.Length; i++)
            {
                row = 0;
                column = 0;
                pointer = 0;
                upperBound = 127;
                lowerBound = 0;
                singlePass = boardingPasses[i].ToCharArray();
                while (pointer<7)
                {
                    middleBound = (upperBound + lowerBound) / 2;
                    if (singlePass[pointer].Equals('F'))
                    {
                        upperBound = middleBound;
                        row = upperBound;
                    }
                    else if (singlePass[pointer].Equals('B'))
                    {
                        lowerBound = middleBound+1;
                        row = lowerBound;
                    }
                    pointer++;
                    // Console.WriteLine(row);
                }
                upperBound = 7;
                lowerBound = 0;
                while (pointer<10)
                {
                    middleBound = (upperBound + lowerBound) / 2;
                    if (singlePass[pointer].Equals('L'))
                    {
                        upperBound = middleBound;
                        column = upperBound;
                    }
                    else if (singlePass[pointer].Equals('R'))
                    {
                        lowerBound = middleBound+1;
                        column = lowerBound;
                    }
                    pointer++;
                    
                }
                tempHold = (row * 8) + column;
                fillSeat[tempHold] = tempHold;
            }
            for (int s = 0; s < fillSeat.Length; s++)
            {
                if (s>1 && s<1023)
                {
                    if(fillSeat[s]==0)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }
    }
}
