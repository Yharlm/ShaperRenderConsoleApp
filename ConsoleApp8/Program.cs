using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

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
        class Connection
        {
            public point a;
            public point b;
            public Connection(point a, point b)
            {
                this.a = a;
                this.b = b;
            }
        }
        class Shape
        {
            public List<Connection> connections = new List<Connection>();
            public List<point> points = new List<point>();
            public void AddPoint(string name, int x, int y)
            {
                points.Add(new point(name, x, y));
            }
            public void AddConnection(point a, point b)
            {
                Connection connection = new Connection(a, b);
                connections.Add(connection);
            }
            public void SquarePoint()
            {
                this.AddPoint("A", 10, 10);
                this.AddPoint("B", 20, 10);
                this.AddPoint("C", 20, 20);
                this.AddPoint("D", 10, 20);
                AddConnection(points[0], points[1]);
                AddConnection(points[1], points[2]);
                AddConnection(points[2], points[3]);
                AddConnection(points[3], points[0]);
            }

            public void Cube()
            {
                this.AddPoint("A", 10, 10);
                this.AddPoint("B", 20, 10);
                this.AddPoint("C", 20, 20);
                this.AddPoint("D", 10, 20);

                this.AddPoint("A1", 10, 10);
                this.AddPoint("B1", 20, 10);
                this.AddPoint("C1", 20, 20);
                this.AddPoint("D1", 10, 20);
                AddConnection(points[0], points[1]);
                AddConnection(points[1], points[2]);
                AddConnection(points[2], points[3]);
                AddConnection(points[3], points[0]);
                //back side connections
                AddConnection(points[4], points[5]);
                AddConnection(points[5], points[6]);
                AddConnection(points[6], points[7]);
                AddConnection(points[7], points[4]);
                // side connections
                AddConnection(points[0], points[4]);
                AddConnection(points[1], points[5]);
                AddConnection(points[2], points[6]);
                AddConnection(points[3], points[7]);
            }
        }
        
        
        static void Main(string[] args)
        {
            int size = 50;
            int[,] grid = new int[size, size];
            List<Shape> shapes = new List<Shape>();
            
            string input = "";
            int index = 0;
            int shape_index = 0;

            string mode = "point";
            List<int> Selected = new List<int>();
            while (true)
            {
                

                foreach(var shape1 in shapes)
                {
                    foreach (var connection in shape1.connections)
                    {
                        DrawLine(connection.a, connection.b, grid);
                    }
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
                if (shapes.Count-1 == 0)
                {
                    shape = shapes[shape_index];
                    Console.ForegroundColor = ConsoleColor.Green;
                WriteAt("[]", shape.points[index].pos.x * 2, shape.points[index].pos.y);
                Console.ResetColor();
                }
                WriteAt($"Mode{mode}, index:{index}", 1, 1);
                input = Console.ReadKey().Key.ToString();
                
                if(input == "Spacebar")
                {
                    
                    Selected.Add(index);
                }
                if (input == "Z")
                {
                    Selected.Clear();
                    
                }
                if (input == "S")
                {
                    if(mode == "point")
                    {
                        shapes[shape_index].points[index].pos.y++;
                    }
                    else if(mode == "select")
                    {
                        foreach(int i in Selected)
                        {
                            shapes[shape_index].points[i].pos.y++;
                        }
                    }
                    else if (mode == "shape")
                    {
                        foreach(point point in shapes[shape_index].points)
                        {
                            point.pos.y++;
                        }
                    }
                    
                }
                if (input == "W")
                {
                    if (mode == "point")
                    {
                        shapes[shape_index].points[index].pos.y--;
                    }
                    if (mode == "select")
                    {
                        foreach (int i in Selected)
                        {
                            shapes[shape_index].points[i].pos.y--;
                        }
                    }
                    else if (mode == "shape")
                    {
                        foreach (point point in shapes[shape_index].points)
                        {
                            point.pos.y--;
                        }
                    }
                }
                if (input == "A")
                {
                    if (mode == "point")
                    {
                        shapes[shape_index].points[index].pos.x--;
                    }
                    if (mode == "select")
                    {
                        foreach (int i in Selected)
                        {
                            shapes[shape_index].points[i].pos.x--;
                        }
                    }
                    else if (mode == "shape")
                    {
                        foreach (point point in shapes[shape_index].points)
                        {
                            point.pos.x--;
                        }
                    }
                }
                if (input == "D")
                {
                    if (mode == "point")
                    {
                        shapes[shape_index].points[index].pos.x++;
                    }
                    if (mode == "select")
                    {
                        foreach (int i in Selected)
                        {
                            shapes[shape_index].points[i].pos.x++;
                        }
                    }
                    else if (mode == "shape")
                    {
                        foreach (point point in shapes[shape_index].points)
                        {
                            point.pos.x++;
                        }
                    }
                }
                if (input == "D1")
                {
                    index++;
                    if (shapes[shape_index].points.Count <= index)
                    {
                        index = 0;
                    }
                }
                if (input == "D2")
                {
                    shape_index++;
                    if (shapes.Count <= shape_index)
                    {
                        shape_index = 0;
                    }
                }
                if (input == "E")
                {
                    Shape t = new Shape();
                    t.Cube();

                    shapes.Add(t);
                }
                if (input == "Q")
                {
                    if (mode == "point")
                    {
                        mode = "shape";
                    }
                    else if(mode == "shape")
                    {
                        mode = "select";
                    }
                    else
                    {
                        mode = "point";
                    }
                }
                if (input == "Backspace")
                {
                    if(mode == "point")
                    {
                        shapes[shape_index].points.RemoveAt(index);
                        index--;
                        if (index < 0)
                        {
                            index = 0;
                        }
                    }
                    else
                    {
                        shapes.RemoveAt(shape_index);
                        shape_index--;
                        if (shape_index < 0)
                        {
                            shape_index = 0;
                        }
                    }
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

        
    }
}
