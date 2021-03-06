﻿/** \file Program.cs
    @file       Program.cs
    @brief      Файл исходных кодов проекта
    @copyright  BMSTU
    @author     Кучеренко М.А.
    @date       Sun Oct 8 17:02:55 2017
    @version    1.0.0
\par Содержит классы:
    @ref Lab2.Program
    @ref Lab2.GeometricFigure
    @ref Lab2.Rectangle
    @ref Lab2.Square
    @ref Lab2.Circle
\par Содержит интерфейсы:
    @ref Lab2.IPrint
*/

using System;

namespace Lab2
{
    class Program
    {

        /**
         * Ввести значение типа double
         * @param string prompt
         *  Приглашение ввода для пользователя
         */
        static double InputVal(string prompt)
        {
            double a = 0;
            do
                Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out a));
            #if AUTOTEST
                Console.WriteLine(a);
            #endif
            return a;
        }

        /**
         * Класс с константами выбора пользователя
         */
        public static class STATE
        {
            public const String Rectangle = "1";
            public const String Sqare = "2";
            public const String Circle = "3";
        }

        /**
         * Меню пользователя
         */
        static string Menu()
        {
            Console.WriteLine("Площадь чего вы бы хотели посчитать?");
            Console.WriteLine("1. Прямоугольник;");
            Console.WriteLine("2. Квадрат;");
            Console.WriteLine("3. Окружность;");
            Console.WriteLine("e. Выход;");
            string s = Console.ReadLine();
            #if AUTOTEST
                Console.WriteLine(s);
            #endif
            return s;
        }

        /**
         * Очистка консоли с ожиданием ввода
         */
        static void ClearScreen()
        {
            Console.WriteLine("Нажмите enter для продолжения ...");
            Console.ReadLine();
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

    /**
     * Интерфейс, для печати на экран
     */
    interface IPrint
    {
        void Print();
    }

    /**
     * Абстрактный класс фигуры
     */
    abstract class GeometricFigure
    {
        public abstract double Area();
        public abstract override string ToString();
    }

    /**
     * Класс прямоугольника
     */
    class Rectangle : GeometricFigure, IPrint
    {

        private double h = 0; ///< Высота
        private double w = 0; ///< Ширина

        public double H { get => h; set => h = value; }
        public double W { get => w; set => w = value; }

        /**
         * Конструктор класса
         * @param double height 
         *  Задает высоту фигуры
         * @param double width 
         *  Задает ширину фигуры
         */
        public Rectangle(double height, double width)
        {
            H = height;
            W = width;
        }

        /**
         * Вычисляет площадь фигуры 
         */
        public override double Area()
        {
            return W * H;
        }

        /**
         * Приведение к строке
         * @return string Основная информация об объекте
         */
        public override string ToString()
        {
            return "Rectangle: " + W.ToString() + "x" + H.ToString() + ", S = " + Area().ToString();
        }

        /**
         * Напечатать основную информацию об объекте в консоль
         */
        public void Print() => Console.WriteLine(this);
    }

    /**
     * Класс квадрата
     */
    class Square : Rectangle
    {
        /**
         * Конструктор класса
         * @param double length 
         *  Задает длину стороны квадрата
         */
        public Square(double length) : base(length, length) {}

        /**
         * Приведение к строке
         * @return string Основная информация об объекте
         */
        public override string ToString()
        {
            return "Square: " + H.ToString() + "x" + H.ToString() + ", S = " + Area().ToString();
        }

    }

    /**
     * Класс круга
     */
    class Circle : GeometricFigure, IPrint
    {
        private double r = 0; ///< Радиус

        public double R { get => r; set => r = value; }

        /**
         * Конструктор класса
         * @param double radus 
         *  Задает фигиру
         */
        public Circle(double radius)
        {
            R = radius;
        }

        /**
         * Вычисляет площадь фигуры 
         */
        public override double Area()
        {
            return Math.PI * R * R;
        }

        /**
         * Приведение к строке
         * @return string Основная информация об объекте
         */
        public override string ToString()
        {
            return "Circle: " + R.ToString() + ", S = " + Area().ToString();
        }

        /**
         * Напечатать основную информацию об объекте в консоль
         */
        public void Print() => Console.WriteLine(this);
    }
}