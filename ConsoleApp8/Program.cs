using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    internal class Program
    {
        static void WriteAt(string text, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(text);
            }
            catch { }

        }
        class Cordinates
        {
            public int x;
            public int y;
        }

        class point
        {
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
            public List<point> points = new List<point>();
            public void AddPoint(string name, int x, int y)
            {
                points.Add(new point(name, x, y));
            }
            public void SquarePoint()
            {
                this.AddPoint("A", 10, 10);
                this.AddPoint("B", 20, 10);
                this.AddPoint("C", 20, 20);
                this.AddPoint("D", 10, 20);
            }
        }

        static void Main(string[] args)
        {
            int size = 50;
            int[,] grid = new int[size, size];
            List<Shape> shapes = new List<Shape>();
            Shape Sqaure = new Shape();
            Sqaure.AddPoint("A", 10, 10);
            Sqaure.AddPoint("B", 20, 10);
            Sqaure.AddPoint("C", 20, 20);
            Sqaure.AddPoint("D", 10, 20);

            string input = "";
            int index = 1;
            int shape_index = 0;
            while (true)
            {
                

                foreach(var shape1 in shapes)
                {
                    for (int i = 1; i < shape1.points.Count; i++)
                    {
                        DrawLine(shape1.points[i], shape1.points[i - 1], grid);
                    }
                    DrawLine(shape1.points[0], shape1.points[shape1.points.Count - 1], grid);
                }
                



               
                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = 0; j < size - 1; j++)
                    {
                        if (grid[i, j] == 0)
                        {
                            WriteAt("  ", j * 2, i);
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            WriteAt("[]", j * 2, i);
                            Console.ResetColor();
                        }
                        

                    }

                }
                Shape shape = new Shape();
                if (shapes.Count > 0)
                {
                    shape = shapes[shape_index];
                    Console.ForegroundColor = ConsoleColor.Green;
                WriteAt("[]", shape.points[index].pos.x * 2, shape.points[index].pos.y);
                Console.ResetColor();
                }
                
                input = Console.ReadKey().Key.ToString();


                if (input == "S")
                {
                    shape.points[index].pos.y++;
                }
                if (input == "W")
                {
                    shape.points[index].pos.y--;
                }
                if (input == "A")
                {
                    shape.points[index].pos.x--;
                }
                if (input == "D")
                {
                    shape.points[index].pos.x++;
                }
                if (input == "D1")
                {
                    index++;
                    if (shape.points.Count == index)
                    {
                        index = 0;
                    }
                }
                if (input == "D2")
                {
                    shape_index++;
                    if (shape.points.Count == shape_index)
                    {
                        shape_index = 0;
                    }
                }
                if (input == "E")
                {
                    Shape t = new Shape();
                    t.AddPoint("A", 10, 10);
                    t.AddPoint("B", 20, 10);
                    t.AddPoint("C", 20, 20);
                    t.AddPoint("D", 10, 20);

                    shapes.Add(t);
                }
                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = 0; j < size - 1; j++)
                    {
                        grid[i, j] = 0;
                    }
                }

            }

        }

        static void DrawLine(point a, point b, int[,] grid)
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
