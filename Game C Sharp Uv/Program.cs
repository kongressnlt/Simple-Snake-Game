using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Game_C_Sharp_Uv
{
    class Program
    {
        
        public static int x = 0;
        public static int y = 0;
        public static int score = 0;
        public static bool right_ = true;
        public static bool ate = false;
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
        public static void ClearScene()
        {
            Console.Clear();
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
        public static void Right()
        {
            /*if (y == 8 && x == 9)
                return; */
            if (y == 9)
                return;
            if (polygon[x, y + 1] == "*")
            {
                polygon[x, y] = " ";
                ate = true;
                y++;
                polygon[x, y] = "-";
            }
            else
            {
                polygon[x, y] = " ";
                y++;
                polygon[x, y] = "-";
            }
        }
        public static void Left()
        {
            if (x == 0 && y == 0)
                return;
             if (y == 0)
                return;
             if(polygon[x, y-1] == "*")
            {
                polygon[x, y] = " ";
                ate = true;
                y--;
                polygon[x, y] = "-";
            }
            else
            {
                polygon[x, y] = " ";
                y--;
                polygon[x, y] = "-";
            }
        }
        public static void Up()
        {
            if (x == 0)
            {
                return;
            }
            if (polygon[x - 1, y] == "*")
            {
                polygon[x, y] = " ";
                ate = true;
                x--;
                polygon[x, y] = "|";
             }
            else
            {
                polygon[x, y] = " ";
                x--;
                polygon[x, y] = "|";
            }
        }
        public static void Down()
        {
            if (x == 9)
                return;
           /* if (x + 1 == 9 && y == 9)
                return; */
            if (polygon[x+1, y] == "*")
            {
                polygon[x, y] = " ";
                ate = true;
                x++;
                polygon[x, y] = "|"; 
            }
            else
            {
                polygon[x, y] = " ";
                x++;
                polygon[x, y] = "|";
            }
        } 
        public static void StartGame()
        {
            
            ClearScene();
            x = 0; y = 0;
            Filler(" ");
            polygon[0, 0] = "-";
            Random ran = new Random();
            int ran_x = ran.Next(1, 10);
            int ran_y = ran.Next(1, 10);
            polygon[ran_x, ran_y] = "*";
            RenderScene();
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.RightArrow)
                {
                    ClearScene();
                    Right();
                    RenderScene();
                    
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    ClearScene();
                    Left();
                    RenderScene();
                }
                else if(key == ConsoleKey.UpArrow)
                {
                    ClearScene();
                    Up();
                    RenderScene();
                }
                else if(key == ConsoleKey.DownArrow)
                {
                    ClearScene();
                    Down();
                    RenderScene();
                }
                if (ate)
                {
                    score++;
                    ran_x = ran.Next(0, 10);
                    ran_y = ran.Next(0, 10);
                    if (ran_x == x && ran_y == y)
                    {
                        ran_x = ran.Next(0, 10);
                        ran_y = ran.Next(0, 10);
                    }
                    ate = false;
                    polygon[ran_x, ran_y] = "*";
                }
            }
        }
        static void Main(string[] args)
        {
            StartGame();
            var key1 = Console.ReadKey().Key;
            if (key1 == ConsoleKey.R)
            {
                StartGame();
            }
            else
            {
                return;
            }
        }
    }
}