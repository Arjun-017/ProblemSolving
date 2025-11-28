using ProblemSolving.Abstractions;
using ProblemSolving.Framework;

namespace ProblemSolving.Problems;

/// <summary>
/// Roman numerals are formed by appending the conversions of decimal place values from highest to lowest.
/// <see cref="https://leetcode.com/problems/integer-to-roman/description/"/>
/// </summary>

[ProblemId(12)]
public class IntegertoRoman : IProblem
{
    private int _input;
    private string _output;
    
    public IntegertoRoman(int input)
    {
        _input = input;
    }
    
    public void Execute()
    {
        _output = ConvertToRoman(_input);
    }

    public void DisplayResult()
    {
        Console.WriteLine($"The roman numeral is {_output}");
    }

    private string ConvertToRoman(int num)
    {
        int number = num;
        string output = "";
        (number,output) = ConvertDigitToSymbol(number, output, 1000, "M");
        (number,output) = ConvertDigitToSymbol(number, output, 900, "CM");
        (number,output) = ConvertDigitToSymbol(number, output, 500, "D");
        (number,output) = ConvertDigitToSymbol(number, output, 400, "CD");
        (number,output) = ConvertDigitToSymbol(number, output, 100, "C");
        (number,output) = ConvertDigitToSymbol(number, output, 90, "XC");
        (number,output) = ConvertDigitToSymbol(number, output, 50, "L");
        (number,output) = ConvertDigitToSymbol(number, output, 40, "XL");
        (number,output) = ConvertDigitToSymbol(number, output, 10, "X");
        (number,output) = ConvertDigitToSymbol(number, output, 9, "IX");
        (number,output) = ConvertDigitToSymbol(number, output, 5, "V");
        (number,output) = ConvertDigitToSymbol(number, output, 4, "IV");
        (number,output) = ConvertDigitToSymbol(number, output, 1, "I");
        return output;
    }

    private (int, string) ConvertDigitToSymbol(int number, string output, int factor, string symbol)
    {
        int r = number / factor;
        if (r > 0)
        {
            string prefix = "";
            for (int i = 1; i <= r; i++)
            {
                prefix += symbol;
            }
            output += prefix;
            number = number - (r * factor);
        }

        return (number, output);
    }
}
