using System;

namespace TicTacToeTomek
{
    class Program
    {
        static ILogic logic = new Logic();
        static string answer;
        static bool correctChoice = false;

        static void Main(string[] args)
        {
            while (!correctChoice)
            {
                Console.WriteLine("Do you wish to play or read from a file.");
                Console.WriteLine("Enter 1 and press ENTER for reading from a file : C:/Users/Public/TestFolder/A-small-practice.in");
                Console.WriteLine("Enter 2 and Press ENTER for playing the game");
                answer = Console.ReadLine().ToString();
                if (answer == "1" || answer == "2")
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

                logic.readFromTestFile("C:/Users/Public/TestFolder/A-Large-practice.in");
                Console.ReadKey();

            }
            else if (answer == "2")
            {
                bool playAgain = true;

                while (playAgain)
                {

                    logic.playGame();
                    Console.WriteLine("Do you wish to play again? enter 2 to play again and 1 to quit");
                    answer = Console.ReadLine().ToString();
                    if (answer == "1")
                    {
                        playAgain = false;
                    }
                }
            }
        }
    }
}