using System;
using System.Drawing;

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

        static void Zad3(int m, int n, int k, int l)
        {
            int[,] table1 = new int[m,n];
            int[,] table2 = new int[k, l];

            Console.WriteLine("Pierwsza tabela: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    table1[i, j] = (i + 1) * (j + 1);
                    Console.Write(table1[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\nDruga tabela: ");
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    table2[i, j] = (k - i) * (l - j);
                    Console.Write(table2[i, j] + " ");
                }
                Console.WriteLine("");
            }

            int firstMin = m < k ? m : k;
            int firstDim = m < k ? k : m;
            int secondMin = n < l ? n : l;
            int secondDim = n < l ? l : n;
            int[,] table3 = new int[firstDim,secondDim];
            Console.WriteLine("\nTabela wynikowa: ");
            for (int i = 0; i < firstDim; i++)
            {
                for (int j = 0; j < secondDim; j++)
                {
                    if (i < firstMin && j < secondMin)
                    {
                        table3[i, j] = table1[i, j] + table2[i, j];
                    }
                    else
                    {
                        table3[i, j] = 0;
                    }
                    Console.Write(table3[i, j] + " ");
                }
                Console.WriteLine("");
            }

        }

        static int[,] GenerateTable(int m, int n)
        {
            int[,] table1 = new int[m,n];
            Console.WriteLine("Uzyta tabela:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    table1[i, j] = (m - i) * (j + 1);
                    Console.Write(table1[i, j] + " ");
                }
                Console.WriteLine("");
            }

            return table1;
        }

        static int Zad4(int[,] table, int m, int n)
        {
            int minimum = table[0, 0];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (table[i, j] < minimum)
                    {
                        minimum = table[i, j];
                    }
                }
            }

            return minimum;
        }

        class EBook
        {
            readonly string Autor;
            readonly string Tytul;
            readonly DateTime DataWydania;

            private DateTime _DataOstatniegoZakupu;
            public DateTime DataOstatniegoZakupu
            {
                get { return _DataOstatniegoZakupu; }
                set
                {
                    if (value < _DataOstatniegoZakupu)
                    {
                        Console.WriteLine("Nie mozna dodac wartosci mniejszej niz poprzednia (Data Ostatniego Zakupu)");
                    }

                    else
                    {
                        _DataOstatniegoZakupu = value;
                    }
                }
            }

            private double _CenaStandardowa;
            public double CenaStandardowa
            {
                get { return _CenaStandardowa;}
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Cena nie moze byc ujemna");
                        _CenaStandardowa = 0;
                    }
                    else
                    {
                        _CenaStandardowa = value;
                    }
                }
            }

            private int _Obnizka;

            public int Obnizka
            {
                get => _Obnizka;
                set
                {
                    if (value > 100 || value < 0)
                    {
                        Console.WriteLine("Bledna wartosc (Obnizka)");
                        _Obnizka = 0;
                    }
                    else
                    {
                        _Obnizka = value;
                    }
                }
            }

            private double _AktualnaCena;

            public double AktualnaCena
            {
                get => _AktualnaCena;
                set
                {
                    _AktualnaCena = _CenaStandardowa * (100 - _Obnizka)/100;
                }
            }

            public EBook(string autor, string tytul, DateTime dataWydania,
                DateTime dataOstatniegoZakupu, double cenaStandardowa, int obnizka)
            {
                Autor = autor;
                Tytul = tytul;
                DataWydania = dataWydania;
                DataOstatniegoZakupu = dataOstatniegoZakupu;
                CenaStandardowa = cenaStandardowa;
                Obnizka = obnizka;
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE 1 - ciag arytmetyczny");
            Console.WriteLine("Podaj numer wyrazu ciagu ktorego wartosc chcesz poznac:");
            string number = Console.ReadLine();
            double result1 = Zad1(Int32.Parse(number));
            Console.WriteLine(number + "-ty wyraz ciagu ma wartosc " + result1 + "\n");
            
            Console.WriteLine("ZADANIE 2 - podzielnosc");
            Console.WriteLine("Podaj dzielnik: ");
            string dzielnik = Console.ReadLine();
            Zad2(Int32.Parse(dzielnik));
            
            Console.WriteLine("\nZADANIE 3 - dodawanie tablic");
            Console.WriteLine("Podaj pierwszy wymiar pierwszej tabeli: ");
            string m = Console.ReadLine();
            Console.WriteLine("Podaj drugi wymiar pierwszej tabeli: ");
            string n = Console.ReadLine();
            Console.WriteLine("Podaj pierwszy wymiar drugiej tabeli: ");
            string k = Console.ReadLine();
            Console.WriteLine("Podaj drugi wymiar drugiej tabeli: ");
            string l = Console.ReadLine();
            
            Zad3(Int32.Parse(m), Int32.Parse(n), Int32.Parse(k), Int32.Parse(l));
            
            Console.WriteLine("\nZADANIE 4 - minimum tablicy");
            Console.WriteLine("Podaj pierwszy wymiar tabeli: ");
            string a = Console.ReadLine();
            Console.WriteLine("Podaj drugi wymiar tabeli: ");
            string b = Console.ReadLine();
            int min = Zad4(GenerateTable(Int32.Parse(a), Int32.Parse(b)), Int32.Parse(a), Int32.Parse(b));
            Console.WriteLine("Minimalna wartosc powyzszej tabeli to: " + min);
            
            
            Console.WriteLine("\nZADANIE 5 - klasy");
            EBook eBook = new EBook("Autor", "tytul", 
                DateTime.Now, DateTime.Today, 34.5, 0);
        }
    }
}