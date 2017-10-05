using System;
using System.Diagnostics;

using static System.Console;

namespace foken_equasion
{
    class Program
    {
        static long dirEq(int n, out Stopwatch t)
        {
            t = new Stopwatch();
            t.Start();

            long result = (long)(Math.Pow(-1, n) * -8 + Math.Pow(-2, n)* 17.0 / 3 + 2 * n  +7.0 / 3);

            t.Stop();
            return result;
        }

        static long ittEq(int n, out Stopwatch t)
        {
            t = new Stopwatch();
            t.Start();
            long x0 = 0, x1 = 1;

            switch (n)
            {
                case 0:
                    return x0;
                case 1:
                    return x1;
            }

            long x2 = 0;
            for (int i = 2; i <= n; i++)
            {
                x2 = 12 * i - 3 * x1 - 2 * x0;
                x0 = x1;
                x1 = x2;
            }
            t.Stop();

            return x2;
        }

        static long recEq(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return 12 * n - 3 * recEq(n - 1) - 2 * recEq(n - 2);
            }
        }

        static long recEq(int n, out Stopwatch t)
        {
            t = new Stopwatch();
            t.Start();
            long result = recEq(n);
            t.Stop();
            return result;
        }

        static void Main(string[] args)
        {
            Stopwatch t;
            string n;
            int num;
            do
            {
                WriteLine("Введите номер вычисляемого элемента");
                while (!int.TryParse(n = ReadLine(), out num))
                    WriteLine("Число!");
                if (n.Contains("-"))
                    break;
                Clear();
                WriteLine(n);

                WriteLine("Формула");
                WriteLine("{0}. {2}t = {1}ms", dirEq(num, out t), t.ElapsedMilliseconds, t.ElapsedTicks);
                t = null;
                GC.Collect();
                WriteLine("Иттерация");
                WriteLine("{0}. {2}t = {1}ms", ittEq(num, out t), t.ElapsedMilliseconds, t.ElapsedTicks);
                t = null;
                GC.Collect();
                WriteLine("Рекурсия");
                WriteLine("{0}. {2}t = {1}ms", recEq(num, out t), t.ElapsedMilliseconds, t.ElapsedTicks);
                t = null;
                GC.Collect();
                WriteLine();
            }
            while (true);
        }
    }
}