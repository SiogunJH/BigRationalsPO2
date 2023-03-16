using System.Numerics;

namespace BigRationalLib
{
    public readonly partial struct BigRational
    {
        // VARIABLES
        public BigInteger Numerator { get; init; }
        public BigInteger Denominator { get; init; }

        public static readonly BigRational Zero = new (0,1);

        // CONSTRUCTORS
        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            // Assign variables
            Numerator = numerator;
            Denominator = denominator;

            // Negative sign in numerator
            if (
                    (Numerator < 0 && Denominator < 0) || // -/-
                    (Numerator >= 0 && Denominator < 0) // +/- => -/+
                )
            {
                Numerator *= -1;
                Denominator *= -1;
            }

            // Shorten
            if (Numerator==0) Denominator = 1;
            
            var GCD = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            if (GCD != 1 && GCD != -1)
            {
                Numerator /= GCD;
                Denominator/= GCD;
            }
            
        }
        public BigRational() : this(BigInteger.Zero, BigInteger.One) { }

        // OVERRIDES

        public override string ToString() => string.Format("{0}/{1}", Numerator, Denominator);

        // EQUALITY

        // COMPARISONS

        // ARITHMETICS

        // CONVERSIONS

        public BigRational Parse(string text)
        {
            int n = int.Parse(text.Split('/')[0]);
            int d = int.Parse(text.Split('/')[1]);
            return new BigRational(n, d);
        }

    }
}