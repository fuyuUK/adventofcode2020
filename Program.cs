using System;

namespace AoCDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentCol = 0;
            int treeAmount = 0;

            string[] map = System.IO.File.ReadAllLines(@"C:\Users\harry\Desktop\AdventOfCodeText\Day3.txt");
            for (int i = 0; i < map.Length; i+=2)
            {
                char[] currentMapLine = map[i].ToCharArray();
                Console.WriteLine("Map: {0}", map[i]);
                Console.WriteLine(currentMapLine[currentCol]);
                if (currentMapLine[currentCol].Equals('#'))
                {
                    treeAmount++;
                }
                currentCol+=1;
                if(currentCol==(currentMapLine.Length))
                {
                    currentCol = 0;
                }
                else if (currentCol == (currentMapLine.Length) + 1)
                {
                    currentCol = 1;
                }
                else if (currentCol == (currentMapLine.Length) + 2)
                {
                    currentCol = 2;
                }
                else if (currentCol == (currentMapLine.Length) + 3)
                {
                    currentCol = 3;
                }
                else if (currentCol == (currentMapLine.Length) + 4)
                {
                    currentCol = 4;
                }
                else if (currentCol == (currentMapLine.Length) + 5)
                {
                    currentCol = 5;
                }
                else if (currentCol == (currentMapLine.Length) + 6)
                {
                    currentCol = 6;
                }

                Console.WriteLine("Col: {0}",currentCol);
            }

            Console.WriteLine(treeAmount);
        }
    }
}
