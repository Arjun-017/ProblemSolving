using ProblemSolving.Abstractions;
using ProblemSolving.Framework;

namespace ProblemSolving.Problems;

/// <summary>
/// Given an integer x, return true if x is a palindrome, and false otherwise.
/// <see cref="https://leetcode.com/problems/palindrome-number/"/>
/// </summary>

[ProblemId(9)]
public class PalindromeNumber : IProblem
{
    private int _input;
    private bool _isPalindrome;
    
    public PalindromeNumber(int input)
    {
        _input = input;
    }
    public void Execute()
    {
        if (_input < 0)
        {
            return;
        }
        int copy = _input;
        int reverse = 0;
        while (_input > 0)
        {
            int r = _input % 10;
            reverse = reverse * 10 + r;
            _input = _input / 10;
        }
        _isPalindrome = copy == reverse;
    }

    public void DisplayResult()
    {
        string text = _isPalindrome ? "palindrome" : "not palindrome";
        Console.WriteLine($"The number is {text}");
    }
}
