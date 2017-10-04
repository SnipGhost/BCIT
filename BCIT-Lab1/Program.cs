using System;

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
                    Console.WriteLine("Иррациональные корни");
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
                    Console.WriteLine("X1 = " + x1 + "\n X2 = " + x2);
                }

            } while (AskContinue());
        }
    }
}