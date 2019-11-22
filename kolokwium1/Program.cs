using System;

namespace kolokwium1
{
    class Program
    {

        static double Zad1(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return 1.5 * Zad1(n - 1) - 1;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE 1 - ciag arytmetyczny");
            Console.WriteLine("Podaj numer wyrazu ciagu ktorego wartosc chcesz poznac:");
            string n = Console.ReadLine();
            double result1 = Zad1(Int32.Parse(n));
            Console.WriteLine(n + "-ty wyraz ciagu ma wartosc " + result1);
        }
    }
}