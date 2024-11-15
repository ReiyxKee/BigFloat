BigFloat - High Precision Arbitrary-Scale Floating-Point Implementation
====================================================================

`BigFloat` is a custom implementation of a floating-point number system that uses `BigInteger` to represent the mantissa and a separate scale to handle decimal precision. 

This class allows for handling very large or very small floating-point numbers with high precision, beyond the capabilities of native floating-point types like `float`, `double`, or `decimal`.

Feel free to fork and expand for your own usage.

## WARNING
- This is entirely made out of **experimental fun thoughts** and **study purpose**. Use it with **extreme cautious** if it is for production.

## Features
- **Implicit Conversions**: Interaction with built-in types. So far only `int`, `float`, `decimal`, and `string`.
- **Arithmetic Operations**: Supports basic arithmetic operations (`+`, `-`, `*`, `/`) and comparisons (`>`, `<`, `>=`, `<=`).

## Getting Started

### Installation

Simply include the `BigFloat.cs` file in your project, and the `BigFloat` class will be available for use.

### Basic Usage

You can create a `BigFloat` instance and perform arithmetic or conversions like this:

```csharp
using System;

class Program
{
    static void Main()
    {
        // Create BigFloat from decimal
        BigFloat bigFloat1 = new BigFloat(123.456m);
        
        // Create BigFloat from int
        BigFloat bigFloat2 = new BigFloat(789);
        
        // Perform arithmetic operations
        BigFloat result = bigFloat1 + bigFloat2;
        
        // Convert BigFloat to other types
        decimal decimalValue = bigFloat1;  // Implicit conversion to decimal
        float floatValue = bigFloat1;      // Implicit conversion to float
        int intValue = bigFloat2;          // Implicit conversion to int
        
        // Output result
        Console.WriteLine("BigFloat result: " + result);
        Console.WriteLine("Decimal conversion: " + decimalValue);
        Console.WriteLine("Float conversion: " + floatValue);
        Console.WriteLine("Int conversion: " + intValue);
    }
}
