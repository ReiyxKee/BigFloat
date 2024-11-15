using System;
using System.Numerics;

public partial class BigFloat
{
    public static implicit operator float(BigFloat bigFloat)
    {
        decimal decimalValue = bigFloat.ToDecimal();
        return (float)decimalValue;
    }
}
