using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static string[,] gameArray = new string[,] { { "1","2","3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        static bool gameOver;
        static string whoIsWinner = null;
        static void Main(string[] args)
        {
            while (gameOver == false)
            {
                setField();
                Console.WriteLine("Player 1: Choose your field!");
                string player1Choice = Console.ReadLine();
                int c1 = int.Parse(player1Choice);
                ChangeRowAndColume(c1,"O");
                

                Console.WriteLine("Player 2: Choose your field!");
                string player2Choice = Console.ReadLine();
                int c2 = int.Parse(player2Choice);
                ChangeRowAndColume(c2,"X");

                Console.Clear();

                if (Checker(gameArray) == true)
                {
                    Console.WriteLine("The game has been over.");
                    if (whoIsWinner == "O")
                    {
                        Console.WriteLine("Player 1 wins the game!");
                    }
                    else if (whoIsWinner == "X")
                    {
                        Console.WriteLine("Player 2 wins the game!");
                    }
                    gameOver = true;
                };
            }
        }

        static void setField()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  | {1}   |  {2} ", gameArray[0, 0], gameArray[0, 1], gameArray[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", gameArray[1, 0], gameArray[1, 1], gameArray[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", gameArray[2, 0], gameArray[2, 1], gameArray[2, 2]);
            Console.WriteLine("     |     |     ");
        }

        public static bool Checker(string[,] board)
        {
            // here we perform horizontal and vertical checks
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    whoIsWinner = board[i, 0];
                    return true;
                }
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    whoIsWinner = board[0, i];
                    return true;
                }
            }
            // here diagonal checks 
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                whoIsWinner = board[0, 0];
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                whoIsWinner = board[0,2];
                return true;
            }
            return false;
        }

        public static object ChangeRowAndColume(int choice, string turn)
        {
            int columeIndex;
            int rowIndex;
            if (choice <= 3)
            {
                columeIndex = choice - 1;
                rowIndex = 0;
                gameArray[rowIndex, columeIndex] = turn;
            }
            else if (choice > 3 && choice < 9)
            {
                columeIndex = choice % 3 - 1;
                double row = Math.Floor((double)choice / 3);
                rowIndex = (int)row;
                gameArray[rowIndex, columeIndex] = turn;
            }else if(choice == 9)
            {
                columeIndex = 2;
                rowIndex = 2;
                gameArray[rowIndex, columeIndex] = turn;
            }
            return gameArray;
        }
    }
}

