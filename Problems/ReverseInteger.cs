using ProblemSolving.Abstractions;
using ProblemSolving.Framework;

namespace ProblemSolving.Problems;

/// <summary>
/// Given a signed 32-bit integer x, return x with its digits reversed.
/// If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1],
/// then return 0.
/// <see cref="https://leetcode.com/problems/reverse-integer/description/"/>
/// </summary>

[ProblemId(7)]
public class ReverseInteger : IProblem
{
    private int _input;
    private int _output;

    public ReverseInteger(int intput)
    {
        _input = intput;
    }
    
    public void Execute()
    {
        bool isNegative = _input < 0;
        string maxIntString = isNegative ? int.MinValue.ToString().Substring(1) : int.MaxValue.ToString();
        string inputIntString = isNegative ? _input.ToString().Substring(1) : Math.Abs(_input).ToString();
        int inputIntLength = inputIntString.Length;
        if (inputIntLength < maxIntString.Length)
        {
            for (int i = 0; i < inputIntLength; i++)
            {
                int value = inputIntString[inputIntLength - i - 1] - '0';
                _output = _output * 10 + (isNegative ? -1 * value : value);
            }
        }
        else
        {
            bool flag = false;
            for (int i = 0; i < inputIntLength; i++)
            {
                if (inputIntString[inputIntLength - i - 1] <= maxIntString[i] || flag)
                {
                    int value = inputIntString[inputIntLength - i - 1] - '0';
                    _output = _output * 10 + (isNegative ? -1 * value : value);
                    if (inputIntString[inputIntLength - i - 1] < maxIntString[i])
                    {
                        flag = true;
                    }
                }
                else
                {
                    _output = 0;
                    break;
                }
            }
        }
    }

    public void DisplayResult()
    {
        Console.WriteLine($"The reversed integer is {_output}");
    }
    
}
