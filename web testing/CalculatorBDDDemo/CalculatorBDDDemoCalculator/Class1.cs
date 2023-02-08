namespace CalculatorBDDDemoCalculator;

public class Calculator
{
    public int A { get; set; }
    public int B { get; set; }
    public int Add()
    {
        return A + B;
    }

    public int Divide()
    {
        try { return A / B; }
        catch (DivideByZeroException e) {throw new DivideByZeroException("Cannot Divide By Zero"); }
    }

    public int Multiply()
    {
        return A * B;
    }

    public int Subtract()
    {
        return A - B;
    }
}