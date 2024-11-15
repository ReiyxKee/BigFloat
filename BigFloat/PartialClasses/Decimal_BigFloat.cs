using System;
using System.Numerics;

public partial class BigFloat
{
    public static implicit operator decimal(BigFloat bigFloat)
    {
        return bigFloat.ToDecimal();
    }

    public decimal ToDecimal()
    {
        decimal result = (decimal)mantissa;

        if (scale > 0)
        {
            result /= (decimal)BigInteger.Pow(10, scale);
        }

        return result;
    }
}
