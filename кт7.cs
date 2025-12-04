using System;

public struct Point
{
    public double X;
    public double Y;

    public double DistanceTo(Point other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

public struct Rectangle
{
    public double Width;
    public double Height;

    public double Area()
    {
        return Width * Height;
    }

    public double Perimeter()
    {
        return 2 * (Width + Height);
    }
}

public struct Book
{
    public string Title;
    public string Author;
    public int Year;

    public void Print()
    {
        Console.WriteLine($"{Title} — {Author} ({Year} г.)");
    }
}

public struct ComplexNumber
{
    public double Real;
    public double Imag;

    public ComplexNumber Add(ComplexNumber other)
    {
        ComplexNumber result = new ComplexNumber();
        result.Real = Real + other.Real;
        result.Imag = Imag + other.Imag;
        return result;
    }

    public void Print()
    {
        Console.WriteLine($"{Real} + {Imag}i");
    }
}

public struct Color
{
    public int R;
    public int G;
    public int B;

    public string ToHex()
    {
        return $"#{R:X2}{G:X2}{B:X2}";
    }
}

public struct SimpleDate
{
    public int Day;
    public int Month;
    public int Year;

    public bool IsLeapYear()
    {
        return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
    }
}

public struct Vector2D
{
    public double X;
    public double Y;

    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}

public struct Money
{
    public int Rubles;
    public int Kopecks;

    public Money Add(Money other)
    {
        Money result = new Money();
        result.Rubles = Rubles + other.Rubles;
        result.Kopecks = Kopecks + other.Kopecks;

        if (result.Kopecks >= 100)
        {
            result.Rubles += result.Kopecks / 100;
            result.Kopecks %= 100;
        }

        return result;
    }

    public void Print()
    {
        Console.WriteLine($"{Rubles} руб. {Kopecks:00} коп.");
    }
}

public struct Triangle
{
    public Point A;
    public Point B;
    public Point C;

    private double SideLength(Point p1, Point p2)
    {
        return p1.DistanceTo(p2);
    }

    public double Area()
    {
        double side1 = SideLength(A, B);
        double side2 = SideLength(B, C);
        double side3 = SideLength(C, A);
        double p = (side1 + side2 + side3) / 2;
        return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
    }
}

public struct Point3D
{
    public double X;
    public double Y;
    public double Z;

    public double DistanceTo(Point3D other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        double dz = Z - other.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}

class Program
{
    static void Main()
    {
        

        
        Console.WriteLine("1. Точка на плоскости:");
        Point p1 = new Point { X = 3143, Y = 443 };
        Point p2 = new Point { X = 0, Y = 0 };
        Console.WriteLine($"Расстояние между точками: {p1.DistanceTo(p2):F2}\n");

        
        Console.WriteLine("2. Прямоугольник:");
        Rectangle rect = new Rectangle { Width = 54443, Height = 3435 };
        Console.WriteLine($"Площадь: {rect.Area()}, Периметр: {rect.Perimeter()}\n");

        
        Console.WriteLine("3. Книга:");
        Book book = new Book
        {
            Title = "Мастер и Маргарита",
            Author = "Михаил Булгаков",
            Year = 1966
        };
        book.Print();
        Console.WriteLine();

       
        Console.WriteLine("4. Комплексные числа:");
        ComplexNumber c1 = new ComplexNumber { Real = 234, Imag = 3567 };
        ComplexNumber c2 = new ComplexNumber { Real = 113, Imag = 23245 };
        ComplexNumber sum = c1.Add(c2);
        Console.Write("Сумма: ");
        sum.Print();
        Console.WriteLine();

       
        Console.WriteLine("5. Цвет RGB:");
        Color color = new Color { R = 255, G = 126, B = 0 };
        Console.WriteLine($"HEX код: {color.ToHex()}\n");

        
        Console.WriteLine("6. Дата:");
        SimpleDate date = new SimpleDate { Day = 24, Month = 11, Year = 2025 };
        Console.WriteLine($"2024 високосный? {date.IsLeapYear()}\n");

       
        Console.WriteLine("7. Вектор 2D:");
        Vector2D vector = new Vector2D { X = 33, Y = 44 };
        Console.WriteLine($"Длина вектора: {vector.Length():F2}\n");

        
        Console.WriteLine("8. Деньги:");
        Money money1 = new Money { Rubles = 100234, Kopecks = 56660 };
        Money money2 = new Money { Rubles = 504324, Kopecks = 76665 };
        Money total = money1.Add(money2);
        Console.Write("Сумма: ");
        total.Print();
        Console.WriteLine();

       
        Console.WriteLine("9. Треугольник:");
        Triangle triangle = new Triangle
        {
            A = new Point { X = 4424, Y = 0 },
            B = new Point { X = 432, Y = 0 },
            C = new Point { X = 0, Y = 3 }
        };
        Console.WriteLine($"Площадь треугольника: {triangle.Area():F2}");

       
        Console.WriteLine("10. 3D точка:");
        Point3D point3d1 = new Point3D { X = 143, Y = 211, Z = 311 };
        Point3D point3d2 = new Point3D { X = 412, Y = 622, Z = 8332 };
        Console.WriteLine($"Расстояние: {point3d1.DistanceTo(point3d2):F2}");

        Console.WriteLine("Выход");
        Console.ReadKey();
    }
}