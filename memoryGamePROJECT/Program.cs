using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memoryGamePROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            int len;
            int counter = 0;
            do
            {
                Console.WriteLine("choose the board size - 2,4,6:\t");
                len = int.Parse(Console.ReadLine());
                if (len % 2 == 0 && len > 1 && len < 7)
                {
                    counter++;
                }

            } while (counter != 1);

            MainGame(len);
            Console.ReadLine();




        }


        public static void MainGame(int len)
        {
            int Score = 0;
            int pairs = 0;
            int First_Score = 0;
            int Second_Score = 0;
            int active_player = 1;
            string [,] arr =  game_arr(len);
            string[] CharArry = new string[18] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r" };
            for(int i = 0; i < (len * len)/2; i++)
            {
                index_(CharArry[i], arr);
            }
            Console.WriteLine("it's the " + active_player + "player turn");
            string[,] Board_Arr = new string[len, len];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Board_Arr[i, j] = "x";
                    Console.Write("[" + Board_Arr[i, j] + "] \t");
                }
                Console.WriteLine("\n");
            }


            while ((First_Score + Second_Score) != (len * len)/2 )
            {
                
                int LineCard1;
                int ColunCard1;
                int LineCard2;
                int ColunCard2;
                Console.WriteLine("enter number for the first card first the line and then the colume");
                LineCard1 = int.Parse(Console.ReadLine());
                ColunCard1 = int.Parse(Console.ReadLine());
                if (Board_Arr[LineCard1, ColunCard1] == "0")
                {
                    do
                    {
                        Console.WriteLine("This card is already been chosen, enter line and colume again");
                        LineCard1 = int.Parse(Console.ReadLine());
                        ColunCard1 = int.Parse(Console.ReadLine());
                    }
                    while (Board_Arr[LineCard1, ColunCard1] == "0");
                }
                Board_Arr[LineCard1, ColunCard1] = arr[LineCard1, ColunCard1];
                
                Console.WriteLine("enter number for the second card first the line and then the colume");
                LineCard2 = int.Parse(Console.ReadLine());
                ColunCard2 = int.Parse(Console.ReadLine());
                if(Board_Arr[LineCard2, ColunCard2] == "0")
                {
                    do
                    {
                        Console.WriteLine("This card is already been chosen, enter line and colume again");
                        LineCard2 = int.Parse(Console.ReadLine());
                        ColunCard2 = int.Parse(Console.ReadLine());
                    }
                    while (Board_Arr[LineCard2, ColunCard2] == "0");
                }
                Board_Arr[LineCard2, ColunCard2] = arr[LineCard2, ColunCard2];
                Board(Board_Arr);
                if(Board_Arr[LineCard1, ColunCard1] == Board_Arr[LineCard2, ColunCard2])
                {
                    Board_Arr[LineCard1, ColunCard1] = "0";
                    Board_Arr[LineCard2, ColunCard2] = "0";
                    if (active_player == 1)
                    {
                        First_Score++;
                        Console.WriteLine("first player score is: ",First_Score);
                    }
                    else
                    {
                        Second_Score++;
                        Console.WriteLine("second player score is: ", Second_Score);
                    }
                    Board(Board_Arr);
                    
                }
                else
                {

                    Board_Arr[LineCard1, ColunCard1] = "x";
                    Board_Arr[LineCard2, ColunCard2] = "x";
                    if (active_player == 1)
                    {
                        active_player = 2;
                    }
                    else
                    {
                        active_player = 1;
                    }
                    Console.WriteLine("it's the " + active_player + "player turn");
                    Board(Board_Arr);
                }
            }

            

        }

        public static void Board(string[,] charecter)
        {
            
            for (int i = 0; i < charecter.GetLength(0); i++)
            {
                for (int j = 0; j < charecter.GetLength(1); j++)
                {
                    Console.Write("[" + charecter[i, j] + "] \t");
                }
                Console.WriteLine("\n");
            }
        }

        public static string [,] game_arr(int len)
        {
            string[,] arr = new string[len, len];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    arr[i, j] = "1";
                }
            }
            return arr;
        }

        public static void index_(string arr1,string[,] arr2)
        {
            int a, b;
            Random rnd = new Random();
            int count = 0;
            while(count != 2)
            {
                
                a = rnd.Next(0, arr2.GetLength(0));
                b = rnd.Next(0, arr2.GetLength(0));

                if (arr2[a, b] == "1")
                {
                    arr2[a, b] = arr1;
                    count++;
                }
            }
        }


        public static void Turns_And_Score()
        {
            Console.WriteLine("enter tow numbers the first card first the line and then the colume");
            int LineCard1 = int.Parse(Console.ReadLine());
            int ColunCard1 = int.Parse(Console.ReadLine());


        }
    }
}
