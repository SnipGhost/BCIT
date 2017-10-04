using System;

namespace Lab2
{
    class Program
    {

        static double InputVal(string prompt)
        {
            double a = 0;
            do
                Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out a));
            return a;
        }

        public static class STATE
        {
            public const String Rectangle = "1";
            public const String Sqare = "2";
            public const String Circle = "3";
        }

        static string Menu()
        {
            Console.WriteLine("Площадь чего вы бы хотели посчитать?");
            Console.WriteLine("1. Прямоугольник;");
            Console.WriteLine("2. Квадрат;");
            Console.WriteLine("3. Окружность;");
            Console.WriteLine("e. Выход;");
            return Console.ReadLine();
        }

        static void ClearScreen()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения ...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            IPrint obj;
            bool exitFlag = false;
            double a1, b1;
            do
            {
                switch (Menu())
                {
                    case STATE.Rectangle:
                        a1 = InputVal("Введите высоту прямоугольника \n");
                        b1 = InputVal("Введите ширину прямоугольника \n");
                        obj = new Rectangle(a1, b1);
                        obj.Print();
                        break;

                    case STATE.Sqare:
                        a1 = InputVal("Введите высоту квадрата \n");
                        obj = new Square(a1);
                        obj.Print();
                        break;

                    case STATE.Circle:
                        a1 = InputVal("Введите радиус окружности \n");
                        obj = new Circle(a1);
                        obj.Print();
                        break;

                    default:
                        exitFlag = true;
                        break;
                }
                ClearScreen();

            } while (!exitFlag);
        }


    }

    interface IPrint
    {
        void Print();
    }

    abstract class GeometricFigure
    {
        public abstract double Area();
        public abstract override string ToString();
    }

    class Rectangle : GeometricFigure, IPrint
    {
        public double h = 0, w = 0;
        public Rectangle(double height, double width)
        {
            h = height;
            w = width;
        }

        public override double Area()
        {
            return w * h;
        }

        public override string ToString()
        {
            return "Rectangle: " + w.ToString() + "x" + h.ToString() + ", S = " + Area().ToString();
        }

        public void Print() => Console.WriteLine(this);
    }

    class Square : Rectangle
    {
        public Square(double length) : base(length, length) {}

        public override string ToString()
        {
            return "Square: " + h.ToString() + "x" + h.ToString() + ", S = " + Area().ToString();
        }

    }

    class Circle : GeometricFigure, IPrint
    {
        public double r = 0;
        public Circle(double radius)
        {
            r = radius;
        }

        public override double Area()
        {
            return Math.PI * r * r;
        }

        public override string ToString()
        {
            return "Circle: " + r.ToString() + ", S = " + Area().ToString();
        }

        public void Print() => Console.WriteLine(this);
    }
}