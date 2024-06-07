// dotnet run --property:DefineConstants="RUN_POINT2"
using System;

class Point
{
    protected int x, y;
    protected readonly int color;

    public Point()
    {
        this.x = 0;
        this.y = 0;
        this.color = 0;
    }

    public Point(int x, int y, int color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public void PrintCoordinates()
    {
        Console.WriteLine($"Coordinates: ({this.x}, {this.y})");
    }

    public double CalculateDistanceToOrigin()
    {
        return Math.Sqrt(this.x * this.x + this.y * this.y);
    }

    public void Move(int x1, int y1)
    {
        this.x += x1;
        this.y += y1;
    }

    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    public int Color
    {
        get { return this.color; }
    }

    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return this.x;
                case 1: return this.y;
                case 2: return this.color;
                default: throw new IndexOutOfRangeException("Invalid index. Index must be 0, 1, or 2.");
            }
        }
        set
        {
            switch (index)
            {
                case 0: this.x = value; break;
                case 1: this.y = value; break;
                case 2: throw new InvalidOperationException("Cannot set the color using an index.");
                default: throw new IndexOutOfRangeException("Invalid index. Index must be 0 or 1.");
            }
        }
    }

    public static Point operator ++(Point p)
    {
        p.x++;
        p.y++;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.x--;
        p.y--;
        return p;
    }

    public static bool operator true(Point p)
    {
        return p.x != 0 || p.y != 0;
    }

    public static bool operator false(Point p)
    {
        return p.x == 0 && p.y == 0;
    }

    public static Point operator +(Point p, int scalar)
    {
        return new Point(p.x + scalar, p.y + scalar, p.color);
    }

    public static explicit operator string(Point p)
    {
        return $"({p.x}, {p.y}), Color: {p.color}";
    }

    public static explicit operator Point(string s)
    {
        string[] parts = s.Trim('(', ')').Split(new string[] { "), Color: " }, StringSplitOptions.None);

        if (parts.Length != 2)
        {
            throw new FormatException("Invalid format. Format should be (x, y), Color: color.");
        }

        string[] coordinates = parts[0].Split(',');
        if (coordinates.Length != 2)
        {
            throw new FormatException("Invalid format. Coordinates should be in the format x, y.");
        }

        int x = int.Parse(coordinates[0].Trim());
        int y = int.Parse(coordinates[1].Trim());
        int color = int.Parse(parts[1].Trim());

        return new Point(x, y, color);
    }
}

class ProgramPoint
{
#if RUN_POINT2
    static void Main(string[] args)
    {
        Point[] points = new Point[3];
        points[0] = new Point(3, 4, 1);
        points[1] = new Point(-2, 6, 2);
        points[2] = new Point(1, -5, 3);

        double totalDistance = 0;
        foreach (Point p in points)
        {
            totalDistance += p.CalculateDistanceToOrigin();
        }
        double averageDistance = totalDistance / points.Length;

        Console.WriteLine($"Average distance to origin: {averageDistance}");
        Console.WriteLine();

        for (int i = 0; i < points.Length; i++)
        {
            Point p = points[i];
            p.PrintCoordinates();
            Console.WriteLine($"Distance to origin: {p.CalculateDistanceToOrigin()}");

            if (p.CalculateDistanceToOrigin() > averageDistance)
            {
                p.Move(1, 1);
                Console.WriteLine("Point moved to (x+1, y+1)");
            }

            p++;
            Console.WriteLine($"After incrementing: ({p.X}, {p.Y})");

            p--;
            Console.WriteLine($"After decrementing: ({p.X}, {p.Y})");

            if (p)
            {
                Console.WriteLine("Point is non-zero (true).");
            }
            else
            {
                Console.WriteLine("Point is zero (false).");
            }

            Point pPlus10 = p + 10;
            Console.WriteLine($"Point + 10: ({pPlus10.X}, {pPlus10.Y})");

            string pointString = (string)p;
            Console.WriteLine($"Point as string: {pointString}");

            Point newPoint = (Point)pointString;
            Console.WriteLine($"String parsed back to Point: ({newPoint.X}, {newPoint.Y}), Color: {newPoint.Color}");

            Console.WriteLine();
        }

        Point originPoint = new Point(0, 0, 0);
        if (originPoint)
        {
            Console.WriteLine("Origin point is non-zero.");
        }
        else
        {
            Console.WriteLine("Origin point is zero.");
        }
    }
#endif
}
