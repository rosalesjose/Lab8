using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab8
{
    public class Program
    {
        static bool RunApplication = true;
        public static void Main(string[] args)
        {
            Console.Title = "Batting Average Calculator";

            while (RunApplication)
            {
                int NumberOfBatters = GetNumbers("Enter number of players: ");

                int NumberOfAtBats = GetNumbers("Enter number of at-bats: ");

                Console.Clear();

                int[,] StatSheet = new int[NumberOfBatters, NumberOfAtBats];                

                //populate chart
                for (int Row = 0; Row < NumberOfBatters; Row++)
                {
                    Console.WriteLine("Entering at-bats for player {0}", Row + 1);

                    for (int Column = 0; Column < NumberOfAtBats; Column++)
                    {
                        Console.Write("Result for at-bat {0}: ", Column + 1);

                        StatSheet[Row, Column] = int.Parse(Console.ReadLine());         

                        Regex BatRegex = new Regex(@"^[0-4]+$");

                        while (!BatRegex.IsMatch(StatSheet[Row, Column].ToString()))
                        {
                            Console.WriteLine("Enter a number 0-4");
                            StatSheet[Row, Column] = int.Parse(Console.ReadLine());
                        }
                    }
                    Console.Clear();
                }

                //calculate batting average
                for (int Row = 0; Row < NumberOfBatters; Row++)
                {
                    float Count = 0;
                    for (int Column = 0; Column < NumberOfAtBats; Column++)
                    {
                        if (StatSheet[Row, Column] > 0)
                        {
                            Count = Count + 1;
                        }
                    }
                    float BatAverage = Count / NumberOfAtBats;
                    Console.WriteLine("Batting Average for player {0} is: {1}", Row + 1, BatAverage);
                }

                //calculate slugging percent
                for (int Row = 0; Row < NumberOfBatters; Row++)
                {
                    float Sum = 0;
                    for (int Column = 0; Column < NumberOfAtBats; Column++)
                    {
                        Sum = Sum + StatSheet[Row, Column];
                    }
                    float SlugPercent = Sum / NumberOfAtBats;
                    Console.WriteLine("Slugging percent for player {0} is {1}", Row + 1, SlugPercent);
                }

                Console.WriteLine("\nEnter the 'Y' key to enter another batter. \nOr enter in any other key to quit.");
                bool MakeDecision = true;
                while (MakeDecision)
                {
                    try
                    {
                        bool UserDecision = Decision(char.Parse(Console.ReadLine()));
                        MakeDecision = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter the 'Y' key if you want to run the program again.\nEnter 'N' if you want to quit");                        
                    }
                }
            }
        }

        public static int GetNumbers(string UserPrompt)
        {
            Console.WriteLine(UserPrompt);
            int Input = 0;
            while (!int.TryParse(Console.ReadLine(), out Input))
            {
                GetNumbers(UserPrompt);
            }
            if (Input <= 0)
            {
                GetNumbers(UserPrompt);
            }
            return Input;
        }

        public static bool Decision(char UserDecision)
        {
            Console.WriteLine("\nEnter 'Y' or 'N");
            Console.ReadKey();
            if (UserDecision == 'y' || UserDecision == 'Y')
            {
                Console.Clear();
                return RunApplication = true;
            }
            else if (UserDecision == 'n' || UserDecision == 'N')
            {
                return RunApplication = false;
            }
            else
            {
                return Decision(UserDecision);
            }
        }
    }
}
