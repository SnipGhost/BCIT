#### Московский государственный технический университет имени Н.Э. Баумана  

## Лабораторная работа по дисциплине БКИТ №1  

<p align="right">
Выполнил: <a href="https://vk.com/snipghost">Михаил Кучеренко "SnipGhost", ИУ5-34</a>, 08.10.2017
</p>
<p><br></p>

### I. Описание задания  

Разработать программу для решения квадратного уравнения.  
1.	Программа должна быть разработана в виде консольного приложения на языке C#.  
2.	Программа осуществляет ввод с клавиатуры коэффициентов А, В, С, вычисляет дискриминант и корни уравнения (в зависимости от дискриминанта).  
3.	Если коэффициент А, В, С введен некорректно, то необходимо проигнорировать некорректное значение и ввести коэффициент повторно.  
  
Квадратное уравнение вида A*x^2+B*x+C=0 имеет всегда два корня. В зависимости от дискриминанта они могут быть 2 различных действительных (D>0), 2 действительных одинаковых (D=0) или комплексные (D<0).
Все 3 варианта реализованы.  
<p><br></p>

### II. Код программы  

```cs

﻿using System;

namespace Lab1
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
                Console.WriteLine(a.ToString());
            #endif
            return a;
        }

        /**
         * Ожидает ввода ответа на вопрос о продолжнеии работы
         * @return bool Продолжать или нет (True/False)
         */
        static bool AskContinue()
        {
            Console.Write("\nВыйти? (y/n) [n]: ");
            string s = Console.ReadLine();
            #if AUTOTEST
                Console.WriteLine(s);
            #endif
            return !(s == "y");
        }

        static void Main(string[] args)
        {
            double a, b, c;
            do
            {
                Console.Clear();

                a = InputVal("Введи A: ");
                b = InputVal("Введи B: ");
                c = InputVal("Введи C: ");

                double d = (b * b) - 4 * a * c;

                if (d < 0)
                {
                    Console.WriteLine("Комплексные корни");
                }
                else if (d == 0)
                {
                    double x = (-b + Math.Sqrt(d)) / (2 * a);
                    Console.WriteLine("X = " + x);
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                    Console.WriteLine("X1 = " + x1 + "\nX2 = " + x2);
                }

            } while (AskContinue());
        }
    }
}

```

[Исходный код](Program.cs)
<p><br></p>

### III. Примеры работы  
<p><br></p>

```
Введи A: 1
Введи B: -2
Введи C: 1
X = 1

Выйти? (y/n) [n]: y
```
<p><br></p>

```
Введи A: 1
Введи B: 7
Введи C: 10
X1 = -2
X2 = -5

Выйти? (y/n) [n]: y
```
<p><br></p>

```
Введи A: 2
Введи B: 4
Введи C: 3
Комплексные корни

Выйти? (y/n) [n]: y
```
<p><br></p>

```
Введи A: 1
Введи B: 5
Введи C: 2
X1 = -0,43844718719117
X2 = -4,56155281280883

Выйти? (y/n) [n]: y
```
<p><br></p>

