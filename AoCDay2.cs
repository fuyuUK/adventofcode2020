using System;

namespace AoCDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = System.IO.File.ReadAllLines(@"C:\Users\harry\Desktop\AdventOfCodeText\Day2.txt");
            char[] holdPass = new char[passwords.Length];
            char[] wordHoldArray;
            int minLet = 0;
            int maxLet = 0;

            int tempNum;
            int counter;

            string wordHold;
            int temporaryValuehold;

            int validPass = 0;

            for(int i=0;i<passwords.Length;i++)
            {
                counter = -1;
                holdPass = passwords[i].ToCharArray();
                if (char.IsWhiteSpace(holdPass[3]))
                {
                    maxLet = (int)Char.GetNumericValue(holdPass[2]);
                    tempNum = 4;
                }
                else if(holdPass[2].Equals('-'))
                {
                    //Console.WriteLine("Test");
                    char[] tempWords = { holdPass[3], holdPass[4] };
                    maxLet = int.Parse(string.Concat(tempWords));
                    tempNum = 6;
                }
                else
                {
                    char[] tempWords = { holdPass[2], holdPass[3] };
                    maxLet = int.Parse(string.Concat(tempWords));
                    tempNum = 5;
                }

                if (holdPass[1].Equals('-'))
                {
                    minLet = (int)Char.GetNumericValue(holdPass[0]);
                }
                else
                {
                    char[] tempWords2 = { holdPass[0], holdPass[1] };
                    if(int.TryParse(string.Concat(tempWords2), out temporaryValuehold))
                    {
                        minLet = temporaryValuehold;
                    }

                    tempNum = 6;
                }

                wordHold = passwords[i].Split(": ")[1];
                wordHoldArray = new Char[wordHold.Length];
                wordHoldArray = wordHold.ToCharArray();

                Console.WriteLine(wordHold);
                if (wordHoldArray[minLet-1].Equals(holdPass[tempNum]))
                {
                    if(wordHoldArray[maxLet-1].Equals(holdPass[tempNum]))
                    {

                    }
                    else
                    {
                        validPass++;
                        Console.WriteLine("valid");
                    }
                        
                }
                if (wordHoldArray[maxLet-1].Equals(holdPass[tempNum]))
                {
                    if (wordHoldArray[minLet - 1].Equals(holdPass[tempNum]))
                    {

                    }
                    else
                    {
                        validPass++;
                        Console.WriteLine("valid");
                    }
                }
                //Console.WriteLine("Counter {0}",counter);
                /*if(counter>=minLet && counter<=maxLet)
                {
                    validPass++;
                }*/
            }

            Console.WriteLine(validPass);
        }
    }
}
