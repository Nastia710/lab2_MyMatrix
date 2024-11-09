using laba2._1;
namespace TestMatrix
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CorrectDoubleArrayConstructor()
        {
            double[,] mtr =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            MyMatrix matrix = new MyMatrix(mtr);

            Assert.AreEqual(3, matrix.Height);
            Assert.AreEqual(3, matrix.Width);
        }

        public void CorrectJaggedArrayConstructor()
        {
            double[][] jaggedArray =
            {
                new double[] { 1, 2, 3 },
                new double[] { 4, 5, 6 }
            };

            MyMatrix matrix = new MyMatrix(jaggedArray);

            Assert.AreEqual(2, matrix.Height);
            Assert.AreEqual(3, matrix.Width);
        }

        [Test]
        public void CorrectStringArrayConstructor()
        {
            string[] mtr =
            {
                "1 2 3",
                "4 5 6",
                "7 8 9"
            };

            MyMatrix matrix = new MyMatrix(mtr);

            Assert.AreEqual(3, matrix.Height);
            Assert.AreEqual(3, matrix.Width);
        }

        [Test]
        public void CorrectStringConstructor()
        {
            string str = "1 2 3\n4 5 6\n7 8 9";

            MyMatrix matrix = new MyMatrix(str);

            Assert.AreEqual(3, matrix.Height);
            Assert.AreEqual(3, matrix.Width);
        }

        [Test]
        public void Indexer_SetAndGet()
        {
            double[,] mtr =
            {
                { 1, 2 },
                { 3, 4 }
            };

            MyMatrix matrix = new MyMatrix(mtr);
            matrix[0, 1] = 10;

            Assert.AreEqual(10, matrix[0, 1]);
        }

        [Test]
        public void SumOfMatrix()
        {
            MyMatrix mtr1 = new MyMatrix("1  \t5    4 \t2 \n3 8  \t4     2");
            MyMatrix mtr2 = new MyMatrix("6 5    7 0 \n10    9  \t3 1");

            double[,] res = new double[mtr1.Height, mtr1.Width];

            for (int i = 0; i < mtr1.Height; i++)
            {
                for (int j = 0; j < mtr1.Width; j++)
                {
                    res[i, j] = mtr1[i, j] + mtr2[i, j];
                }
            }

            MyMatrix expectedMatrix = new MyMatrix(res);
            MyMatrix mtrRes = mtr1 + mtr2;

            Assert.AreEqual(expectedMatrix.ToString(), mtrRes.ToString());
        }

        [Test]
        public void MultipliedMatrix()
        {
            MyMatrix mtr1 = new MyMatrix(new double[,] { { 1, 2, 3 }, { 0, 6, 8 } });
            MyMatrix mtr2 = new MyMatrix(new double[,] { { 4, 8, 0 }, { 2, 6, 7 }, { 9, 4, 3 } });

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

            MyMatrix expectedMatrix = new MyMatrix(res);
            MyMatrix mtrRes = mtr1 * mtr2;

            Assert.AreEqual(expectedMatrix.ToString(), mtrRes.ToString());
        }

        [Test]
        public void TransposeMe()
        {
            MyMatrix mtr1 = new MyMatrix("1  \t5    4 \t2 \n3 8  \t4     2");

            double[,] transposedMatrix = mtr1.GetTransposedArray();
            MyMatrix expectedMatrix = new MyMatrix(transposedMatrix);
            mtr1.TransposeMe();

            Assert.AreEqual(expectedMatrix.ToString(), mtr1.ToString());
        }
    }
}