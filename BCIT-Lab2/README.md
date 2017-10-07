#### Московский государственный технический университет имени Н.Э. Баумана  

## Лабораторная работа по дисциплине БКИТ №2  

<p align="right">
Выполнил: <a href="https://vk.com/snipghost">Михаил Кучеренко "SnipGhost", ИУ5-34</a>, 08.10.2017
</p>
<p><br></p>

### I. Описание задания  

Разработать программу, реализующую работу с классами.  
1.	Программа должна быть разработана в виде консольного приложения на языке C#.  
2.	Абстрактный класс «Геометрическая фигура» содержит виртуальный метод для вычисления площади фигуры.  
3.	Класс «Прямоугольник» наследуется от «Геометрическая фигура». Ширина и высота объявляются как свойства (property). Класс должен содержать конструктор по параметрам «ширина» и «высота».  
4.	Класс «Квадрат» наследуется от «Прямоугольник». Класс должен содержать конструктор по длине стороны.  
5.	Класс «Круг» наследуется от «Геометрическая фигура». Радиус объявляется как свойство (property). Класс должен содержать конструктор по параметру «радиус».  
6.	Для классов «Прямоугольник», «Квадрат», «Круг» переопределить виртуальный метод Object.ToString(), который возвращает в виде строки основные параметры фигуры и ее площадь.  
7.	Разработать интерфейс IPrint. Интерфейс содержит метод Print(), который не принимает параметров и возвращает void. Для классов «Прямоугольник», «Квадрат», «Круг» реализовать наследование от интерфейса IPrint. Переопределяемый метод Print() выводит на консоль информацию, возвращаемую переопределенным методом ToString().  
<p><br></p>

### II. Код программы  

```cs

﻿using System;

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
```

[Исходный код](Program.cs)
<p><br></p>

### III. Примеры работы  
<p><br></p>

```
Площадь чего вы бы хотели посчитать?
1. Прямоугольник;
2. Квадрат;
3. Окружность;
e. Выход;
1
Введите высоту прямоугольника 
10
Введите ширину прямоугольника 
20
Rectangle: 20x10, S = 200
Нажмите enter для продолжения ...
Площадь чего вы бы хотели посчитать?
1. Прямоугольник;
2. Квадрат;
3. Окружность;
e. Выход;
e
Нажмите enter для продолжения ...
```
<p><br></p>

```
Площадь чего вы бы хотели посчитать?
1. Прямоугольник;
2. Квадрат;
3. Окружность;
e. Выход;
2
Введите высоту квадрата 
16
Square: 16x16, S = 256
Нажмите enter для продолжения ...
Площадь чего вы бы хотели посчитать?
1. Прямоугольник;
2. Квадрат;
3. Окружность;
e. Выход;
e
Нажмите enter для продолжения ...
```
<p><br></p>

```
Площадь чего вы бы хотели посчитать?
1. Прямоугольник;
2. Квадрат;
3. Окружность;
e. Выход;
3
Введите радиус окружности 
10
Circle: 10, S = 314,159265358979
Нажмите enter для продолжения ...
Площадь чего вы бы хотели посчитать?
1. Прямоугольник;
2. Квадрат;
3. Окружность;
e. Выход;
e
Нажмите enter для продолжения ...
```
<p><br></p>

