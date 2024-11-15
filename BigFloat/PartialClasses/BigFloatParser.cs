using System;
using System.Numerics;

public partial class BigFloat
{
    public static BigFloat Parse(decimal value)
    {
        return new BigFloat(new BigInteger(value * (decimal)BigInteger.Pow(10, MaxPrecision)), MaxPrecision);
    }

    public static BigFloat Parse(float value)
    {
        return Parse((decimal)value);
    }

    public static BigFloat Parse(int value)
    {
        return new BigFloat(new BigInteger(value), 0);
    }

    public static BigFloat Parse(string value)
    {
        // Handle parsing string with decimal or integer format
        if (string.IsNullOrWhiteSpace(value))
            throw new FormatException("Input string is null or empty.");

        string[] parts = value.Split('.');
        BigInteger integerPart = BigInteger.Parse(parts[0]);
        int scale = 0;

        if (parts.Length > 1)
        {
            // Convert decimal part to BigInteger and adjust scale accordingly
            string decimalPart = parts[1];
            BigInteger decimalValue = BigInteger.Parse(decimalPart);
            integerPart = integerPart * BigInteger.Pow(10, decimalPart.Length) + decimalValue;
            scale = decimalPart.Length;
        }

        return new BigFloat(integerPart, scale);
    }
}