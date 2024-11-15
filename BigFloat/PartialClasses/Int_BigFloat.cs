using System;
using System.Numerics;

public partial class BigFloat
{
    public BigFloat(int mantissa)
    {
        this.mantissa = mantissa;
        this.scale = 0;
        Normalize();
    }

    public static implicit operator int(BigFloat bigFloat)
    {
        return (int)bigFloat.ToDecimal(); // Truncate if needed
    }

    public static implicit operator BigFloat(int value)
    {
        return new BigFloat(new BigInteger(value), 0);
    }
}
