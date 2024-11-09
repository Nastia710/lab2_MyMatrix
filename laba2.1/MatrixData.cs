using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2._1
{
    public partial class MyMatrix
    {
        protected double[,] _matrix;

        // копіюючий з іншого примірника цього самого класу MyMatrix;
        public MyMatrix(MyMatrix otherMatrix)
        {
            double[,] matrix = new double[otherMatrix.Height, otherMatrix.Width];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = otherMatrix._matrix[i, j];
                }
            }

            _matrix = matrix;
        }

        // з двовимірного масиву типу double[,];
        public MyMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] newMatrix = new double[rows, cols];

            _matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }

            _matrix = matrix;
        }



        // з «зубчастого» масиву double-ів, якщо він фактично прямокутний;
        public MyMatrix(double[][] jaggedArray)
        {
            int rows = jaggedArray.Length;
            int cols = jaggedArray[0].Length;

            for (int i = 0; i < rows; i++)
            {
                if (jaggedArray[i].Length != cols)
                {
                    throw new ArgumentException("Зубчастий масив не прямокутний");
                }


            }

            _matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        //з масиву рядків, якщо фактично ці рядки містять записані через пробіли та/або
        //числа, а кількість цих чисел у різних рядках однакова.

        public MyMatrix(string[] input)
        {
            int height = input.Length;
            var firstRow = input[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int width = firstRow.Length;
            _matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                var rowElements = input[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (rowElements.Length != width)
                {
                    throw new ArgumentException("Кількість елементів у всіх рядках повинна бути однаковою.");
                }

                for (int j = 0; j < width; j++)
                {
                    _matrix[i, j] = double.Parse(rowElements[j]);
                }
            }
        }

        // з рядка, що містить як пробіли та/або табуляції
        public MyMatrix(string input)
        {
            var rows = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var firstRow = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int height = rows.Length;
            int width = firstRow.Length;
            _matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                var rowElements = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (rowElements.Length != width)
                {
                    throw new ArgumentException("Кількість елементів у рядках повинна бути однаковою.");
                }

                for (int j = 0; j < width; j++)
                {
                    _matrix[i, j] = double.Parse(rowElements[j]);
                }
            }
        }

        // Властивості Height та Width
        public int Height
        {
            get
            {
                return _matrix.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return _matrix.GetLength(1);
            }
        }

        // Java-style getter-и
        public int getHeight()
        {
            return _matrix.GetLength(0);
        }
        public int getWidth()
        {
            return _matrix.GetLength(1);
        }

        // Індексатори
        public double this[int index1, int index2]
        {
            get
            {
                if (index1 >= Height || index2 >= Width)
                {
                    throw new ArgumentException("Індекси не в межах масиву");
                }

                return _matrix[index1, index2];
            }
            set
            {
                if (index1 >= Height || index2 >= Width)
                {
                    throw new ArgumentException("Індекси не в межах масиву");
                }

                _matrix[index1, index2] = value;
            }
        }

        // Java-style getter та setter для окремого елемента

        public double getElement(int row, int col)
        {
            return _matrix[row, col];
        }
        public void setElement(int row, int col, double value)
        {
            _matrix[row, col] = value;
        }

        // зручне для сприйняття людиною прямокутне подання числової матриці
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(_matrix[i, j] + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
