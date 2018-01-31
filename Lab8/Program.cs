using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Batting Average Calculator";

            int NumberOfBatters = GetNumbers("Enter number of players: ");            
            
            int NumberOfAtBats = GetNumbers("Enter number of at-bats: ");
            
            Console.Clear();

            //PopulateSheet(NumberofBatters, NumberOfAtBats);

            float[,] StatSheet = new float[NumberOfBatters, NumberOfAtBats];
            
            //populate chart
            for (int Row = 0; Row < NumberOfBatters; Row++)
            {
                Console.WriteLine("Entering at-bats for player {0}", Row + 1);

                for (int Column = 0; Column < NumberOfAtBats; Column++)
                {
                    Console.Write("Result for at-bat {0}: ", Column + 1);
                    StatSheet[Row, Column] = float.Parse(Console.ReadLine());
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
        }
        public static int GetNumbers(string UserPrompt)
        {
            Console.WriteLine(UserPrompt);
            try
            {
                int Input = int.Parse(Console.ReadLine());
                while (Input <= 0)
                {
                    Console.Clear();
                    return GetNumbers(UserPrompt);
                }
                return Input;
            }
            catch (FormatException)
            {
                Console.Clear();
                return GetNumbers(UserPrompt);
            }           
        }

        //public static float PopulateSheet(int NumberOfBatters, int NumberOfAtBats)
        //{
        //    float[,] StatSheet = new float[NumberOfBatters, NumberOfAtBats];
            
        //}
    }
}
