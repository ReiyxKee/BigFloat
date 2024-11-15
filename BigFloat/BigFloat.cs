using System;
using System.Numerics;

public partial class BigFloat
{
    private BigInteger mantissa;
    private int scale;
    private const int MaxPrecision = 1000000;
    public static readonly BigFloat Zero = new BigFloat(0);

    public BigFloat(BigInteger mantissa, int scale)
    {
        this.mantissa = mantissa;
        this.scale = scale;
        Normalize();
    }

    private void Normalize()
    {
        if (scale > MaxPrecision)
        {
            int diff = scale - MaxPrecision;
            mantissa /= BigInteger.Pow(10, diff);
            scale = MaxPrecision;
        }
    }

    public static BigFloat operator +(BigFloat a, BigFloat b)
    {
        AlignScales(ref a, ref b);
        return new BigFloat(a.mantissa + b.mantissa, a.scale);
    }

    public static BigFloat operator -(BigFloat a, BigFloat b)
    {
        AlignScales(ref a, ref b);
        return new BigFloat(a.mantissa - b.mantissa, a.scale);
    }

    public static BigFloat operator *(BigFloat a, BigFloat b)
    {
        BigInteger newMantissa = a.mantissa * b.mantissa;
        int newScale = a.scale + b.scale;
        return new BigFloat(newMantissa, newScale);
    }

    public static BigFloat operator /(BigFloat a, BigFloat b)
    {
        BigInteger newMantissa = (a.mantissa * BigInteger.Pow(10, MaxPrecision)) / b.mantissa;
        int newScale = a.scale - b.scale + MaxPrecision;
        return new BigFloat(newMantissa, newScale);
    }

    public static bool operator <=(BigFloat a, BigFloat b)
    {
        AlignScales(ref a, ref b);
        return a.mantissa <= b.mantissa;
    }

    public static bool operator >=(BigFloat a, BigFloat b)
    {
        AlignScales(ref a, ref b);
        return a.mantissa >= b.mantissa;
    }

    public static bool operator <(BigFloat a, BigFloat b)
    {
        AlignScales(ref a, ref b);
        return a.mantissa < b.mantissa;
    }

    public static bool operator >(BigFloat a, BigFloat b)
    {
        AlignScales(ref a, ref b);
        return a.mantissa > b.mantissa;
    }

    private static void AlignScales(ref BigFloat a, ref BigFloat b)
    {
        if (a.scale > b.scale)
        {
            b.mantissa *= BigInteger.Pow(10, a.scale - b.scale);
            b.scale = a.scale;
        }
        else if (b.scale > a.scale)
        {
            a.mantissa *= BigInteger.Pow(10, b.scale - a.scale);
            a.scale = b.scale;
        }
    }

    public override string ToString()
    {
        string mantissaStr = mantissa.ToString();
        if (scale == 0) return mantissaStr;

        int integerLength = mantissaStr.Length - scale;
        if (integerLength > 0)
            return mantissaStr.Insert(integerLength, ".");

        return "0." + new string('0', -integerLength) + mantissaStr;
    }
}
