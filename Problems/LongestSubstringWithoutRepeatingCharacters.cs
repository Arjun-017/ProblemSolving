using ProblemSolving.Abstractions;
using ProblemSolving.Framework;

namespace ProblemSolving.Problems;

/// <summary>
/// Given a string s, find the length of the longest substring without duplicate characters.
/// <see cref="https://leetcode.com/problems/longest-substring-without-repeating-characters/description/"/>
/// </summary>

[ProblemId(3)]
public class LongestSubstringWithoutRepeatingCharacters : IProblem
{
    private string _inputString;
    private HashSet<char> _longestSubstringHashSet = new();
    private int _maximumSubSetLength = 0;
    
    public LongestSubstringWithoutRepeatingCharacters(string inputString)
    {
        _inputString = inputString;
    }

    public void Execute()
    {
        int p1 = 0;
        int p2 = 0;
        while (p2 < _inputString.Length)
        {
            char c = _inputString[p2];
            if (_longestSubstringHashSet.TryGetValue(c, out _))
            {
                _longestSubstringHashSet.Remove(_inputString[p1]);
                p1 += 1;
            }
            else
            {
                _longestSubstringHashSet.Add(c);
                int length = p2 - p1 + 1;
                _maximumSubSetLength = _maximumSubSetLength > length ?
                        _maximumSubSetLength : length;
                p2 += 1;
            }
        }
    }

    public void DisplayResult()
    {
        Console.WriteLine($"Longest substring without repeating characters: - {_maximumSubSetLength}");
    }
}
