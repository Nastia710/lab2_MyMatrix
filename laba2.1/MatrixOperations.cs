using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2._1
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix mtr1, MyMatrix mtr2)
        {
            if (mtr1.Height != mtr2.Height && mtr1.Width != mtr2.Width)
            {
                throw new ArgumentException("Матриці повинні бути однакового розміру.");
            }

            double[,] res = new double[mtr1.Height, mtr1.Width];

            for (int i = 0; i < mtr1.Height; i++)
            {
                for (int j = 0; j < mtr1.Width; j++)
                {
                    res[i, j] = mtr1[i, j] + mtr2[i, j];
                }
            }

            return new MyMatrix(res);
        }

        public static MyMatrix operator *(MyMatrix mtr1, MyMatrix mtr2)
        {
            if (mtr1.Width != mtr2.Height)
            {
                throw new ArgumentException("Неможливо перемножити матриці");
            }

            double[,] res = new double[mtr1.Height, mtr2.Width];

            for (int i = 0; i < mtr1.Height; i++)
            {
                for (int j = 0; j < mtr2.Width; j++)
                {
                    for (int k = 0; k < mtr2.Height; k++)
                    {
                        res[i, j] += mtr1[i, k] * mtr2[k, j];
                    }
                }
            }

            return new MyMatrix(res);
        }

        // повертає новостворений масив, у якому вміст елементів
        // транспонований відносно тієї матриці, для якої він викликався
        public double[,] GetTransposedArray()
        {

            var rows = _matrix.GetLength(0);
            var columns = _matrix.GetLength(1);

            var result = new double[columns, rows];

            for (var i = 0; i < columns; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    result[i, j] = _matrix[j, i];
                }
            }
            return result;
        }

        // створює новий примірник MyMatrix, у якому вміст матриці транспонований відносно тієї,
        // для якої він викликався; технічну роботу зі власне транспонування не повторювати, а
        // використати результат GetTransponedArray()
        public MyMatrix GetTransposedCopy()
        {
            return new MyMatrix(GetTransposedArray());
        }

        // замінював матрицю, для якої викликається, на транспоновану(теж використати
        // GetTransponedArray(), але щоб у результаті змінився сам this-примірник MyMatrix).
        public void TransposeMe()
        {
            _matrix = GetTransposedArray();
        }
    }
}
