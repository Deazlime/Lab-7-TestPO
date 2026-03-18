using NUnit.Framework;
using lab;

namespace FuncTests
{
    [TestFixture]
    public class FuncTests
    {
        [Test]
        public void TestSin()
        {
            Assert.That(Func.Sin(0),Is.EqualTo(0).Within(0.01));
            Assert.That(Func.Sin(Math.PI / 2),Is.EqualTo(1).Within(0.01));
            Assert.That(Func.Sin(-Math.PI / 2),Is.EqualTo(-1).Within(0.01));
            Assert.That(Func.Sin(Math.PI),Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void TestCos()
        {
            Assert.That(Func.Cos(0),Is.EqualTo(1).Within(0.01));
            Assert.That(Func.Cos(Math.PI / 2),Is.EqualTo(0).Within(0.01));
            Assert.That(Func.Cos(Math.PI),Is.EqualTo(-1).Within(0.01));
            Assert.That(Func.Cos(-Math.PI / 2),Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void TestLn()
        {
            Assert.That(Func.Ln(1),Is.EqualTo(0).Within(0.01));
            Assert.That(Func.Ln(2),Is.EqualTo(0.693).Within(0.01));
            Assert.That(Func.Ln(3),Is.EqualTo(1.1).Within(0.01));
            Assert.Throws<ArgumentOutOfRangeException>(()=>Func.Ln(0));
            Assert.Throws<ArgumentOutOfRangeException>(()=>Func.Ln(-1));
        }
    }

    [TestFixture]
    public class IntegrationTests
    {
        [TestCase(1.0, 0.45)]
        [TestCase(-1.0, -0.45)]
        public void CosSinTest(double input, double expected)
        {
            double sinX = Func.Sin(input);
            double cosX = Func.Cos(input);
            double res = sinX * cosX;
            Assert.That(res, Is.EqualTo(expected).Within(0.01));
        }

        [TestCase(10.0, -1.25)]
        [TestCase(5.0, -1.54)]
        public void SinLn(double input, double expected)
        {
            double sinX = Func.Sin(input);
            double ln = Func.Ln(input);
            double res = sinX * ln;
            Assert.That(res, Is.EqualTo(expected).Within(0.01));
        }

        [TestCase(10.0, -1.93)]
        [TestCase(5.0, 0.45)]
        public void CosLn(double input, double expected)
        {
            double cosX = Func.Cos(input);
            double ln = Func.Ln(input);
            double res = cosX * ln;
            Assert.That(res,Is.EqualTo(expected).Within(0.01));
        }

        [Test]
        public void TestPoloj()
        {
            double input=2.0;
            double lnX=Func.Ln(input);
            double res=Func.F(input);
            double sinX=Func.Sin(input);
            double expected=Math.Sqrt(sinX * sinX + Func.Cos(lnX * lnX));
            Assert.That(res,Is.EqualTo(Math.Round(expected, 2)).Within(0.01));
        }

        [Test]
        public void TestOtric()
        {
            double input=-1.0;
            double sinX=Func.Sin(input);
            double cosX=Func.Cos(input);
            double res=Func.F(input);
            double expected=sinX*sinX+cosX*cosX+Func.Ln(Math.Abs(sinX));
            Assert.That(res,Is.EqualTo(expected).Within(0.01));
        }
    }
}
