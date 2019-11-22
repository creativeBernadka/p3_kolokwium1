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

        static void Zad2(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Nie mozna dzielic przez 0 ani sprawdzac podzielnosci dla liczb ujemnych");
                return;
            }
            Console.WriteLine("Liczby podzielne przez " + n + " to:");
            int[] table = new int[200];
            for (int i = 1; i <= table.Length; i++)
            {
                table[i-1] = i;
                if (table[i - 1] % n == 0)
                {
                    Console.Write(table[i-1] + ", ");
                }
            }
            Console.WriteLine("");
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE 1 - ciag arytmetyczny");
            Console.WriteLine("Podaj numer wyrazu ciagu ktorego wartosc chcesz poznac:");
            string n = Console.ReadLine();
            double result1 = Zad1(Int32.Parse(n));
            Console.WriteLine(n + "-ty wyraz ciagu ma wartosc " + result1 + "\n");
            
            Console.WriteLine("ZADANIE 2 - podzielnosc");
            Console.WriteLine("Podaj dzielnik: ");
            string dzielnik = Console.ReadLine();
            Zad2(Int32.Parse(dzielnik));
        }
    }
}