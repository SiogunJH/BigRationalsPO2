using BigRationalLib;

namespace BigRationalTests
{
    [TestClass]
    public class UnitTest
    {
        [DataTestMethod]
        [DataRow(1, 2)]
        public void Test_Constructor_2Args_OK(int a, int b)
        {
            BigRational u = new BigRational(a, b);
            Assert.AreEqual(a, u.Numerator);
            Assert.AreEqual(b, u.Denominator);
        }

        [DataTestMethod]
        [DataRow(1, -22, -1, 22)]
        [DataRow(-1, -22, 1, 22)]
        [DataRow(-1, 22, -1, 22)]
        [DataRow(1, 22, 1, 22)]
        public void Test_Constructor_2Args_SignNormalization(int a, int b, int x, int y)
        {
            BigRational u = new BigRational(a, b);
            Assert.AreEqual(x, u.Numerator);
            Assert.AreEqual(y, u.Denominator);
        }

        [DataTestMethod]
        [DataRow(2, 4, 1, 2)]
        [DataRow(7, 4, 7, 4)]
        [DataRow(0, 5, 0, 1)]

        public void Test_Constructor_2Args_Reduction(int a, int b, int x, int y)
        {
            BigRational u = new BigRational(a, b);
            Assert.AreEqual(x, u.Numerator);
            Assert.AreEqual(y, u.Denominator);
        }

        [TestMethod]
        public void Test_Concept_of_Zero()
        {
            Assert.AreEqual(0, BigRational.Zero.Numerator);
            Assert.AreEqual(1, BigRational.Zero.Denominator);
        }

        [DataTestMethod]
        [DataRow(0, 1, 0, 1)]
        [DataRow(0, 5, 0, 1)]
        [DataRow(0, -5, 0, 1)]
        [DataRow(-0, -5, 0, 1)]
        public void Test_Concept_of_Zero_Reductin(int a, int b, int x, int y)
        {
            BigRational u = new BigRational(a, b);
            Assert.AreEqual(x, u.Numerator);
            Assert.AreEqual(y, u.Denominator);
        }

        [DataTestMethod]
        [DataRow(0, 1, "0/1")]
        [DataRow(-7, 1, "-7/1")]
        [DataRow(8, -2, "-4/1")]
        public void Test_ToString(int a, int b, string c)
        {
            BigRational u = new BigRational(a, b);
            Assert.AreEqual(c, u.ToString());
        }

        [DataTestMethod]
        [DataRow("0/1", 0, 1)]
        [DataRow("-18/-4", 9, 2)]
        [DataRow("4/-5", -4, 5)]
        public void Test_Parse(string a, int b, int c )
        {
            BigRational u = new BigRational().Parse(a);
            Assert.AreEqual(b, u.Numerator);
            Assert.AreEqual(c, u.Denominator);
        }
    }
}