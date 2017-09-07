using System;
using System.Reflection;
using System.Runtime.InteropServices;
/* Rus: Привет, пользователь yg или иных форумов, мой (@alexuiop1337) проект в открытом доступе, все что мне надо, это чтобы ты оставил эту надпись  
 Eng: Hey, user of YG or any other forum, my (@alexuiop1337) project is open source, and all that i need is that you just keep this notice*/
// By Alexuiop1337

namespace Game_C_Sharp_Uv
{
    class Program
    {  
        public static int x = 0;
        public static int y = 0;
        public static int body = 0;
        public static int score = 0;
        public static ConsoleKey matrix_key;
        public static bool[] using_dir = new bool[4] { false, false, false, false};
        public static string[,] polygon = new string[10, 10];
        public static void RenderScene()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(polygon[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Your score is: " + score);
        }
        public static void Filler(string symbol)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    polygon[i,j] = symbol;
                }
            }
        }
        public static void Update_Matrix(int dir)
        {
            int[] delta_x = new int[4] { 0, -1, 0, 1 };
            int[] delta_y = new int[4] { 1, 0, -1, 0 };
            int _X = delta_x[dir] + x;
            int _Y = delta_y[dir] + y;
            if ((_X < 0 || _X > 9) || (_Y < 0 || _Y > 9))
            {
                return;
            }
            Console.Clear();
            if (polygon[_X, _Y] == "&")
            {
                polygon[x, y] = " ";
                polygon[_X, _Y] = "*";
                x = _X;
                y = _Y;
                new_ran();
            }
            else
            {
                polygon[x, y] = " ";
                polygon[_X, _Y] = "*";
                x = _X;
                y = _Y;
            }
            RenderScene();
            return;
        }
        public static void new_ran()
        {
            int ran_x;
            int ran_y;
            Random ran = new Random();
            while (true)
            {
                ran_x = ran.Next(0, 10);
                ran_y = ran.Next(0, 10);
                if (ran_x != x && ran_y != y)
                {
                    score++;
                    polygon[ran_x, ran_y] = "&";
                    break;
                }
            }
        }
        public static void StartGame()
        {
            Console.Clear();
            x = 0;
            y = 0;
            Filler(" ");
            polygon[0, 0] = "*";
            Random ran = new Random();
            int ran_x = ran.Next(1, 10);
            int ran_y = ran.Next(1, 10);
            polygon[ran_x, ran_y] = "&";
            RenderScene();
            while (true)
            {
                matrix_key = Console.ReadKey().Key;
                if (matrix_key == ConsoleKey.RightArrow)
                {
                    Update_Matrix(0);
                }
                else if (matrix_key == ConsoleKey.LeftArrow)
                {
                    Update_Matrix(2);;
                }
                else if (matrix_key == ConsoleKey.UpArrow)
                {
                    Update_Matrix(1);
                }
                else if (matrix_key == ConsoleKey.DownArrow)
                {
                    Update_Matrix(3);
                }
            }
        }
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            StartGame();
        }
    }
}
