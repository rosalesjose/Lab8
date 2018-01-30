﻿using System;
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
            Console.Write("Enter number of players: ");
            int NumberofBatters = int.Parse(Console.ReadLine());
            
            Console.Write("Enter number of at-bats: ");
            int NumberOfAtBats = int.Parse(Console.ReadLine());
            Console.Clear();
            
            float[,] studentgradesheet = new float[NumberofBatters, NumberOfAtBats];
            //Enter at-bats result
            for (int Row = 0; Row < NumberofBatters; Row++)
            {
                Console.WriteLine("Entering at-bats for player {0}", Row + 1);

                for (int Column = 0; Column < NumberOfAtBats; Column++)
                {
                    Console.Write("Result for at-bat {0}: ", Column + 1);
                    studentgradesheet[Row, Column] = float.Parse(Console.ReadLine());
                }
                Console.Clear();
            }

            //Calculate batting average
            for (int Row = 0; Row < NumberofBatters; Row++)
            {
                float Sum = 0;
                for (int Column = 0; Column < NumberOfAtBats; Column++)
                {
                    Sum = Sum + studentgradesheet[Row, Column];
                }
                Console.WriteLine("Letter grade for player {0} is {1}", Row + 1, CalculateLetterGrade(Sum));
            }

            //Calculate slugging percent
            for (int Row = 0; Row < NumberofBatters; Row++)
            {
                float Sum = 0;
                for (int Column = 0; Column < NumberOfAtBats; Column++)
                {
                    Sum = Sum + studentgradesheet[Row, Column];
                }
                float SlugPercent = Sum / NumberOfAtBats;
                Console.WriteLine("Slugging percent for player {0} is {1}", Row + 1, SlugPercent);
            }
        }

        static char CalculateLetterGrade(float Sum)
        {
            if (Sum >= 90)
                return 'A';
            else if (Sum >= 79)
                return 'B';
            else if (Sum >= 60)
                return 'C';
            else
                return 'F';
        }
    }
}
