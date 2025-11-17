using ProblemSolving.Abstractions;
using ProblemSolving.Framework;

namespace ProblemSolving.Problems;

/// <summary>
/// Two Sum
/// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
/// <see href="https://leetcode.com/problems/two-sum/description/">Click here for problem details</see>.
/// </summary>

[ProblemId(1)]
public class TwoSum : IProblem
{

    private readonly int[] _numArray;
    private readonly int _target;
    private readonly Dictionary<int, int> _mapping = new Dictionary<int, int>();
    private (int, int) _output = new();

    public TwoSum(int[] numArray, int target)
    {
        _numArray = numArray;
        _target = target;
    }

    public void Execute()
    {
        int index = 0;
        foreach (var item in _numArray)
        {
            int diff = _target - item;
            if(_mapping.TryGetValue(item, out var value))
            {
                _output = (value, index);
                return;
            }
            else
            {
                _mapping.Add(diff, index);
            }
            index += 1;
        }
    }

    public void DisplayResult()
    {
        Console.WriteLine($"The output of the TwoSum problem is {_output.Item1},{_output.Item2}");
    }

}
