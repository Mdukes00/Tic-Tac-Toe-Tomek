using System;

namespace TicTacToeTomek
{
    class Program
    {
        static Logic logic = new Logic();
        static string answer;
        static bool correctChoice = false;

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\A-small-practice.in");
           
            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            Console.ReadKey();

            while (!correctChoice)
            {
                Console.WriteLine("Do you wish to play or read from a file.");
                Console.WriteLine("Enter 1 and press ENTER for reading from a file : C:/Users/Public/TestFolder/A-small-practice.in");
                Console.WriteLine("Enter 2 and Press ENTER for playing the game");
                answer = Console.ReadLine().ToString();
                if(answer == "1" || answer == "2")
                {
                    correctChoice = true;
                }
                else
                {
                    Console.WriteLine("please choose correct option");
                }
            }

            if (answer == "1")
            {
              
                

            }
            else if (answer == "2")
            {
                string[,] board = logic.GetBoard();
            }


        }
    }
}