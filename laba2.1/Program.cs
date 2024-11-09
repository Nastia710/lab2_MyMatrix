using System.Numerics;

namespace laba2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix1 =
            {
                {1, 2, 3, 4},
                {8, 9, 0, 7},
                {2, 7, 5, 6}
            };

            MyMatrix mtr1 = new MyMatrix(matrix1);
            MyMatrix mtr2 = new MyMatrix(mtr1);

            Console.WriteLine("Матриця №1:");
            Console.WriteLine(mtr1);
            Console.WriteLine();
            Console.WriteLine("Матриця №2:");
            Console.WriteLine(mtr2);




            double[][] matrix3 = new double[2][];
            matrix3[0] = new double[] { 1, 2, 3 };
            matrix3[1] = new double[] { 5, 6, 7 };
            /*matrix3[2] = new double[] { 9, 10, 11, 12 };*/

            MyMatrix mtr3 = new MyMatrix(matrix3);
            Console.WriteLine("Матриця №3:");
            Console.WriteLine(mtr3);




            string[] matrix4 = new string[3];
            matrix4[0] = "9 \t8 7 3";
            matrix4[1] = "6 5 4 2";
            matrix4[2] = "3     2 \t1 4";

            MyMatrix mtr4 = new MyMatrix(matrix4);
            Console.WriteLine("Матриця №4:");
            Console.WriteLine(mtr4);



            string matrix5 = "1 2 3\n4 5 6\n7 8 9";
            MyMatrix mtr5 = new MyMatrix(matrix5);
            Console.WriteLine("Матриця №5:");
            Console.WriteLine(mtr5);

            Console.WriteLine("Сума матриць 1 та 2:");
            MyMatrix sumMatrix = mtr1 + mtr2;
            Console.WriteLine(sumMatrix);

            Console.WriteLine("Множення матриць 3 та 4:");
            MyMatrix multipliedMatrix = mtr3 * mtr4;
            Console.WriteLine(multipliedMatrix);

            Console.WriteLine("Транспонуємо матрицю №1:");

            /*double[,] transposedMatrix = mtr1.GetTransponedArray();
            Console.WriteLine(transposedMatrix);*/

            MyMatrix mtr1_1 = new MyMatrix(matrix1);
            Console.WriteLine(mtr1_1);
            mtr1.TransposeMe();
            Console.WriteLine(mtr1);
            mtr1[mtr1.Height - 1, 0] = -100;
            Console.WriteLine(mtr1);
        }
    }
}