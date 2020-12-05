using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoCDay4
{
    class Program
    {
        static void Main(string[] args)
        {
            int anotherCount = 0;
            int count = 0;
            int validPorts = 0;
            int passportPointer = 0;
            string line;
            string newPass = "";

            int colonCount = 0;

            List<string> passports = File.ReadLines(@"C:\Users\harry\Desktop\AdventOfCodeText\Day4.txt").ToList();
            string[] passportArray = new string[passports.Count];
            string[] splitPass = new string[8];

            char[] splitChars = { ' ' };
            string[] hairColorCode = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            string colonREGEX = ":";
            Regex crgx = new Regex(colonREGEX);
            Regex rgx = new Regex(@"0|1|2|3|4|5|6|7|8|9|a|b|c|d|e|f");

            StreamReader file = new StreamReader(@"C:\Users\harry\Desktop\AdventOfCodeText\Day4.txt");
            while((line = file.ReadLine()) != null)
            {
                if(line.Equals(String.Empty))
                {
                    anotherCount++;
                }
                else
                {
                    if (passportArray[anotherCount] == null)
                    {
                        passportArray[anotherCount] = line;
                    }
                    else
                    {
                        passportArray[anotherCount] = passportArray[anotherCount] + " " + line;
                    }
                }
            }

            while (passportArray[passportPointer] != null)
            {
                colonCount = 0;
                if (count >= 7)
                {
                    validPorts++;
                    Console.WriteLine("Valid");
                }
                count = 0;
                newPass = passportArray[passportPointer];
                foreach (Match n in crgx.Matches(newPass))
                {
                    colonCount++;
                }
                Console.WriteLine(newPass);
                for (int k = 0; k < colonCount; k++)
                {
                    splitPass[k] = newPass.Split(' ')[0];
                    Console.WriteLine(newPass);
                    switch (splitPass[k])
                    {
                        case var x when splitPass[k].Contains("byr"):
                            splitPass[k] = splitPass[k].Split(":")[1];
                            if (int.Parse(splitPass[k]) >= 1920 && int.Parse(splitPass[k]) <= 2002)
                            {
                                count++;
                            }
                            break;
                        case var x when splitPass[k].Contains("iyr"):
                            splitPass[k] = splitPass[k].Split(":")[1];
                            if (int.Parse(splitPass[k]) >= 2010 && int.Parse(splitPass[k]) <= 2020)
                            {
                                count++;
                            }
                            break;
                        case var x when splitPass[k].Contains("eyr"):
                            splitPass[k] = splitPass[k].Split(":")[1];
                            if (int.Parse(splitPass[k]) >= 2020 && int.Parse(splitPass[k]) <= 2030)
                            {
                                count++;
                            }
                            break;
                        case var x when splitPass[k].Contains("hgt"):
                            splitPass[k] = splitPass[k].Split(":")[1];
                            if (splitPass[k].Contains("cm"))
                            {
                                splitPass[k] = splitPass[k].Split("c")[0];
                                if (int.Parse(splitPass[k]) >= 150 && int.Parse(splitPass[k]) <= 193)
                                {
                                    count++;
                                }
                            }
                            else if(splitPass[k].Contains("in"))
                            {
                                splitPass[k] = splitPass[k].Split("i")[0];
                                if (int.Parse(splitPass[k]) >= 59 && int.Parse(splitPass[k]) <= 76)
                                {
                                    count++;
                                }
                            }
                            break;
                        case var x when splitPass[k].Contains("hcl"):
                            int validyes = 0;
                            splitPass[k] = splitPass[k].Split(":")[1];
                            char[] tempAr = splitPass[k].ToCharArray();
                            if (tempAr[0].Equals('#'))
                            {
                                for (int z = 1; z < 7; z++)
                                {
                                    // Console.WriteLine(rgx.Matches(tempAr[z].ToString()));
                                    foreach (Match m in rgx.Matches(tempAr[z].ToString()))
                                    {
                                        validyes++;
                                    }
                                }
                            }
                            if(validyes==6)
                            {
                                count++;
                            }
                            break;
                        case var x when splitPass[k].Contains("ecl"):
                            splitPass[k] = splitPass[k].Split(":")[1];
                            if (splitPass[k].Equals("amb") ||
                                splitPass[k].Equals("blu") ||
                                splitPass[k].Equals("brn") ||
                                splitPass[k].Equals("gry") ||
                                splitPass[k].Equals("grn") ||
                                splitPass[k].Equals("hzl") ||
                                splitPass[k].Equals("oth")) 
                            {
                                count++;
                            }
                            break;
                        case var x when splitPass[k].Contains("pid"):
                            splitPass[k] = splitPass[k].Split(":")[1];
                            // Console.WriteLine(splitPass[k].Length);
                            if (splitPass[k].Length==9)
                            {
                                count++;
                            }
                            //Console.WriteLine(count);
                            break;
                        default:
                            break;
                    }
                    // Console.WriteLine(validPorts);
                    try
                    {
                        newPass = newPass.Split(' ', 2)[1];
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        // Console.WriteLine(e);
                    }
                    Console.WriteLine(count);
                }
                passportPointer++;
            }
            Console.WriteLine(validPorts);
        }
    }
}
