//using System;

//class Book
//{
//    private Title title;
//    private Author author;
//    private Content content;

//    public Book(string title, string author, string content)
//    {
//        this.title = new Title(title);
//        this.author = new Author(author);
//        this.content = new Content(content);
//    }

//    public void Show()
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        this.title.Show();
//        Console.ForegroundColor = ConsoleColor.Blue;
//        this.author.Show();
//        Console.ForegroundColor = ConsoleColor.Red;
//        this.content.Show();
//        Console.ResetColor();
//    }
//}

//class Title
//{
//    private string title;

//    public Title(string title)
//    {
//        this.title = title;
//    }

//    public void Show()
//    {
//        Console.WriteLine($"Title: {title}");
//    }
//}

//class Author
//{
//    private string author;

//    public Author(string author)
//    {
//        this.author = author;
//    }

//    public void Show()
//    {
//        Console.WriteLine($"Author: {author}");
//    }
//}

//class Content
//{
//    private string content;

//    public Content(string content)
//    {
//        this.content = content;
//    }

//    public void Show()
//    {
//        Console.WriteLine($"Content: {content}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Book book = new Book("The Great Gatsby", "F. Scott Fitzgerald", "In my younger and more vulnerable years my father gave me some advice that I've been turning over in my mind ever since.");
//        book.Show();
//    }
//}

using System;

class Point
{
    private int x;
    private int y;
    private string name;

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public string Name
    {
        get { return name; }
    }

    public Point(int x, int y, string name)
    {
        this.x = x;
        this.y = y;
        this.name = name;
    }
}

class Figure
{
    private Point[] points;

    public Figure(Point a, Point b, Point c)
    {
        points = new Point[] { a, b, c };
    }

    public Figure(Point a, Point b, Point c, Point d)
    {
        points = new Point[] { a, b, c, d };
    }

    public Figure(Point a, Point b, Point c, Point d, Point e)
    {
        points = new Point[] { a, b, c, d, e };
    }

    public double LengthSide(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
    }

    public void PerimeterCalculator()
    {
        double perimeter = 0;
        for (int i = 0; i < points.Length - 1; i++)
        {
            perimeter += LengthSide(points[i], points[i + 1]);
        }
        perimeter += LengthSide(points[points.Length - 1], points[0]);

        Console.WriteLine($"Perimeter of {points.Length}-sided figure: {perimeter}");
    }
}

class Program
{
    static void Main()
    {
        Point A = new Point(0, 0, "A");
        Point B = new Point(0, 1, "B");
        Point C = new Point(1, 1, "C");

        Figure figure = new Figure(A, B, C);
        figure.PerimeterCalculator();
    }
}