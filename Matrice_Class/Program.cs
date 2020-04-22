using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrice_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            int nr_lin, nr_col;

            Console.Write("Numarul de linii ale primei matrici: ");
            nr_lin = int.Parse(Console.ReadLine());

            Console.Write("Numarul de coloane ale primei matrici: ");
            nr_col = int.Parse(Console.ReadLine());

            Console.WriteLine("Elementele primei matrici: ");

            int[,] a = new int[nr_lin + 5, nr_col + 5];

            for (int i = 1; i <= nr_lin; i++)
                for (int j = 1; j <= nr_col; j++)
                    a[i, j] = int.Parse(Console.ReadLine());

            Matrice A = new Matrice(a, nr_lin, nr_col);

            Console.Write("Numarul de linii ale celei de-a doua matrici: ");
            nr_lin = int.Parse(Console.ReadLine());

            Console.Write("Numarul de coloane ale celei de-a doua matrici: ");
            nr_col = int.Parse(Console.ReadLine());

            Console.WriteLine("Elementele celei de-a doua matrici: ");

            int[,] b = new int[nr_lin + 5, nr_col + 5];

            for (int i = 1; i <= nr_lin; i++)
                for (int j = 1; j <= nr_col; j++)
                    b[i, j] = int.Parse(Console.ReadLine());

            Matrice B = new Matrice(b, nr_lin, nr_col);

            Console.WriteLine("-------- A --------");
            A.Afisarea_Matricei();

            Console.WriteLine("-------- B --------");
            B.Afisarea_Matricei();

            Matrice C = A;
     
            C = A.Adunare(B);

            Console.WriteLine("------ A + B ------");
            C.Afisarea_Matricei();

            C = A.Scadere(B);

            Console.WriteLine("------ A - B ------");
            C.Afisarea_Matricei();

            C = A.Inmultire(B);

            Console.WriteLine("------ A * B ------");
            C.Afisarea_Matricei();

            Console.Write("Puterea la care se va ridica matricea: ");
            int p = int.Parse(Console.ReadLine());

            C = A.Ridicare_La_Putere(p);

            Console.WriteLine("------ A ^ {0} ------", p);
            C.Afisarea_Matricei();

            Console.ReadKey();
        }
    }

    internal class Matrice
    {
        private int[,] data;
        private int n;
        private int m;

        public Matrice(int nr_lin, int nr_col)
        {
            n = nr_lin;
            m = nr_col;

            int[,] d = new int[n + 5, m + 5];

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    d[i, j] = 0;

            data = d;
        }

        public Matrice(int[,] mat, int nr_lin, int nr_col)
        {
            data = mat;
            n = nr_lin;
            m = nr_col;
        }

        public Matrice Adunare(Matrice a)
        {
            if (n != a.n || m != a.m)
            {
                throw new ArgumentException("Matricile nu sunt de aceeasi dimensiune");
                return this;
            }

            Matrice result = new Matrice(n, m);

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    result.data[i,j]= data[i, j] + a.data[i, j];

            return result;
        }

        public Matrice Scadere(Matrice a)
        {
            if (n != a.n || m != a.m)
            {
                throw new ArgumentException("Matricile nu sunt de aceeasi dimensiune");
                return this;
            }

            Matrice result = new Matrice(n, m);

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    result.data[i, j] = data[i, j] - a.data[i, j];

            return result;
        }

        public Matrice Inmultire(Matrice a)
        {
            if (m != a.n)
            {
                throw new ArgumentException("Matricile nu pot fi inmultite");
                return this;
            }

            Matrice result = new Matrice(n, a.m);

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= a.m; j++)
                {
                    result.data[i, j] = 0;

                    for (int k = 1; k <= m; k++)
                        result.data[i, j] += data[i, k] * a.data[k, j];
                }

            return result;
        }

        public Matrice Ridicare_La_Putere(int p)
        {
            if (n != m || p < 1)
            {
                throw new ArgumentException("Matricea nu poate fi ridicata la putere");
                return this;
            }

            Matrice result = this;

            for (int i = 1; i < p; i++)
                result = result.Inmultire(this);

            return result;
        }

        public void Afisarea_Matricei()
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                    Console.Write(data[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
