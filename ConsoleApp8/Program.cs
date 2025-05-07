using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    internal class Program
    {
        class Cordinates
        {
            public int x;
            public int y;
        }

        class point {
            public string name;
            public Cordinates pos;
            public point(string name, int x, int y)
            {
                this.name = name;
                pos = new Cordinates();
                pos.x = x;
                pos.y = y;
            }
        }

        class Shape
        {
            List<point> points = new List<point>();

        }
        
        static void Main(string[] args)
        {
            int size = 50;
            int[,] grid = new int[size, size];

            Shape shape = new Shape();


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = 0;
                }
            }
            DrawLine(A, B, grid);
            



            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("[]");
                        Console.ResetColor();
                    }

                }
                Console.WriteLine();
            }


        }

        static void DrawLine(point a,point b, int[,] grid)
        {
            Cordinates A = a.pos;
            Cordinates B = b.pos;

            int dx = B.x - A.x;
            int dy = B.y - A.y;
            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xIncrement = (float)dx / steps;
            float yIncrement = (float)dy / steps;
            float x = A.x;
            float y = A.y;
            for (int i = 0; i <= steps; i++)
            {
                grid[(int)Math.Round(y), (int)Math.Round(x)] = 1;
                x += xIncrement;
                y += yIncrement;
            }
        }
    }
}
