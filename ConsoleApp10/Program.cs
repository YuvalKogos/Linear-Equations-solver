using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter equations number: ");
            int numberEq = Convert.ToInt32(Console.ReadLine());

            double[,] matrix = new double[numberEq + 1, numberEq];

            for (int i = 0; i < numberEq; i++)
            {
                Console.WriteLine("Equation number " + (i+1) + " : ");

                for (int j = 0; j < numberEq; j++)
                {
                    Console.WriteLine("Enter varieble number " + (j+1) + ": ");
                    matrix[j, i] = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine("Enter the sum of the equation:");
                matrix[numberEq, i] = Convert.ToDouble(Console.ReadLine());
            }
            print(matrix);
            Console.WriteLine();
            Console.ReadLine();
            turnToRowEchelonForm(matrix);
            print(matrix);
            Console.WriteLine();
;
            for (int i = 1; i < numberEq+1; i++)
            {
                Console.WriteLine("Varielbe " + i + " : " + matrix[numberEq, i-1]);
                
            }
            Console.ReadLine();

        }

        public static void print(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)+1; j++)
                {
                    Console.Write(matrix[j, i] + " , ");
                }
                Console.WriteLine();
            }
        }
        public static void turnToRowEchelonForm(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {

                if (matrix[i, i] != 0)
                    divRow(i, matrix[i, i], matrix);
                else
                    subRowByRow(i,matrix[i,i] / matrix[i,i-1],i-1,matrix);
                

                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (!(j == i))
                    {
                        subRowByRow(j, matrix[i, j] / matrix[i, i], i, matrix);
                    }



                }

            }
        }

        public static void subRow(int row1, double n, double[,] matrix)
        {



            for (int i = 0; i < 4; i++)
            {
                matrix[i, row1] -= n;
            }
        }

        public static void divRow(int row, double n, double[,] matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                matrix[i, row] = matrix[i, row] / n;
            }
        }

        public static void subRowByRow(int row1, double by, int row2, double[,] matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                matrix[i, row1] -= by * matrix[i, row2];
            }
        }
    }
}
