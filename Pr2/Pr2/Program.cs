//1
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Введіть п'ять цілих числа:");
//        int num1 = int.Parse(Console.ReadLine());
//        int num2 = int.Parse(Console.ReadLine());
//        int num3 = int.Parse(Console.ReadLine());
//        int num4 = int.Parse(Console.ReadLine());
//        int num5 = int.Parse(Console.ReadLine());
//        int groupNumber = 5;
//        int lastDigit = groupNumber % 10;
//        if (IsInRange(num1, lastDigit))
//        {
//            Console.WriteLine(num1);
//        }
//        if (IsInRange(num2, lastDigit))
//        {
//            Console.WriteLine(num2);
//        }
//        if (IsInRange(num3, lastDigit))
//        {
//            Console.WriteLine(num3);
//        }
//        if (IsInRange(num4, lastDigit))
//        {
//            Console.WriteLine(num4);
//        }
//        if (IsInRange(num5, lastDigit))
//        {
//            Console.WriteLine(num5);
//        }
//    }
//    static bool IsInRange(int number, int lastDigit)
//    {
//        return number >= 1 && number <= 10 + lastDigit;
//    }
//}


//2
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Введіть довжини трьох сторін трикутника:");


//        double side1, side2, side3;
//        while (true)
//        {
//            Console.Write("Сторона 1: ");
//            if (!double.TryParse(Console.ReadLine(), out side1) || side1 <= 0)
//            {
//                Console.WriteLine("Некоректне значення. Будь ласка, введіть додатнє число.");
//                continue;
//            }
//            Console.Write("Сторона 2: ");
//            if (!double.TryParse(Console.ReadLine(), out side2) || side2 <= 0)
//            {
//                Console.WriteLine("Некоректне значення. Будь ласка, введіть додатнє число.");
//                continue;
//            }
//            Console.Write("Сторона 3: ");
//            if (!double.TryParse(Console.ReadLine(), out side3) || side3 <= 0)
//            {
//                Console.WriteLine("Некоректне значення. Будь ласка, введіть додатнє число.");
//                continue;
//            }

//            if (IsTriangle(side1, side2, side3))
//            {
//                break;
//            }
//            else
//            {
//                Console.WriteLine("Такий трикутник не існує. Сума будь-яких двох сторін має бути більше третьої.");
//            }
//        }

//        double perimeter = side1 + side2 + side3;
//        double halfPerimeter = perimeter / 2;
//        double area = Math.Sqrt(halfPerimeter * (halfPerimeter - side1) * (halfPerimeter - side2) * (halfPerimeter - side3));

//        string triangleType;
//        if (side1 == side2 && side2 == side3)
//        {
//            triangleType = "рівносторонній";
//        }
//        else if (side1 == side2 || side1 == side3 || side2 == side3)
//        {
//            triangleType = "рівнобедрений";
//        }
//        else
//        {
//            triangleType = "різносторонній";
//        }
//        Console.WriteLine($"Периметр трикутника: {perimeter}");
//        Console.WriteLine($"Площа трикутника: {area}");
//        Console.WriteLine($"Трикутник є {triangleType}.");
//    }

//    static bool IsTriangle(double a, double b, double c)
//    {
//        return a + b > c && a + c > b && b + c > a;
//    }
//}

//3
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Введіть значення для масиву:");
//        int groupNumber = 5; 
//        int lastDigit = groupNumber % 10;
//        int[] array = new int[10 + lastDigit];
//        for (int i = 0; i < array.Length; i++)
//        {
//            Console.Write($"Елемент {i}: ");
//            array[i] = int.Parse(Console.ReadLine());
//        }

//        int min = array[0];
//        int max = array[0];
//        for (int i = 1; i < array.Length; i++)
//        {
//            if (array[i] < min)
//            {
//                min = array[i];
//            }
//            if (array[i] > max)
//            {
//                max = array[i];
//            }
//        }
//        Console.WriteLine("\nМасив:");
//        for (int i = 0; i < array.Length; i++)
//        {
//            Console.Write(array[i] + " ");
//        }
//        Console.WriteLine($"\nМінімальне значення: {min}");
//        Console.WriteLine($"Максимальне значення: {max}");
//    }
//}

//4
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть значення для масиву:");
        int groupNumber = 5;
        int lastDigit = groupNumber % 10;
        int[] X = new int[10 + lastDigit];
        for (int i = 0; i < X.Length; i++)
        {
            Console.Write($"Елемент {i}: ");
            X[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Введіть число M: ");
        int M = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = 0; i < X.Length; i++)
        {
            if (Math.Abs(X[i]) > M)
            {
                count++;
            }
        }

        int[] Y = new int[count];
        int index = 0;
        for (int i = 0; i < X.Length; i++)
        {
            if (Math.Abs(X[i]) > M)
            {
                Y[index] = X[i];
                index++;
            }
        }
        Console.WriteLine($"\nЧисло M: {M}");
        Console.WriteLine("\nМасив X:");
        foreach (int x in X)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine("\n\nМасив Y:");
        foreach (int y in Y)
        {
            Console.Write(y + " ");
        }
    }
}