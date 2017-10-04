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
            Console.WriteLine("1) Прямоугольник;");
            Console.WriteLine("2) Квадрат;");
            Console.WriteLine("3) Окружность;");
            Console.WriteLine("e) Выход;");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            bool work = true;
            IPrint obj;
            double a1, b1;
            while (work)
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
                        obj = new Quadrate(a1);
                        obj.Print();
                        break;

                    case STATE.Circle:
                        a1 = InputVal("Введите радиус окружности \n");
                        obj = new Circle(a1);
                        obj.Print(); // Равносильно: Console.WriteLine(obj)    
                        break;

                    default:
                        work = false;
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения ...");
                Console.ReadKey();
                Console.Clear();
            }
        }


    }

    interface IPrint
    {
        void Print();
    }

    abstract class GeometricFigure
    {
        public GeometricFigure() { }
        public virtual double Square()
        {
            return 0;
        }
        public abstract override string ToString();
    }

    class Rectangle : GeometricFigure, IPrint
    {
        public Rectangle(double height1, double width1)
        {
            _height = height1;
            _width = width1;
        }

        private double _height = 0;
        public double height
        {
            get { return _height; }
            set { _height = value; }
        }

        private double _width = 0;
        public double width
        {
            get { return _width; }
            set { _width = value; }
        }

        public override double Square()
        {
            return _width * _height;
        }

        public override string ToString()
        {
            return "Rectangle: " + width.ToString() + "x" + height.ToString() + ", S = " + Square().ToString();
        }

        public void Print()
        {
            Console.WriteLine(this);
        }
    }

    class Quadrate : Rectangle
    {
        public Quadrate(double height1) : base(height1, height1) { }

        public override double Square()
        {
            return height * height;
        }

        public override string ToString()
        {
            return "Square: " + height.ToString() + "x" + height.ToString() + ", S = " + Square().ToString();
        }

    }

    class Circle : GeometricFigure, IPrint
    {
        public Circle(double radius)
        {
            _radius = radius;
        }

        private double _radius = 0;

        public double radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override double Square()
        {
            return Math.PI * _radius * _radius;
        }

        public override string ToString()
        {
            return "Circle: " + radius.ToString() + ", S = " + Square().ToString();
        }

        public void Print()
        {
            Console.WriteLine(this);
            //Console.WriteLine(this.ToString());
            //Console.WriteLine(ToString());
        }
    }
}