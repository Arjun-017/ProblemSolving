using ProblemSolving.Abstractions;
using ProblemSolving.Framework;

namespace ProblemSolving.Problems;

/// <summary>
/// You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
/// Find two lines that together with the x-axis form a container, such that the container contains the most water.
/// Return the maximum amount of water a container can store.
/// <see cref="https://leetcode.com/problems/container-with-most-water/description/"/>
/// </summary>

[ProblemId(11)]
public class ContainerWithMostWater : IProblem
{

    private int[] _heightArray;
    private int _output = 0;

    public ContainerWithMostWater(int[] heightArray)
    {
        _heightArray = heightArray;
    }

    public void DisplayResult()
    {
        Console.WriteLine($"The maximum area is {_output}");
    }

    public void Execute()
    {
        int p1 = 0;
        int p2 = _heightArray.Length - 1;
        int maxArea = 0;
        
        while(p1 <= p2)
        {
            int area = 0;
            if (_heightArray[p1] > _heightArray[p2])
            {
                area = (p2 - p1) * _heightArray[p2];
                p2 -= 1;
            }
            else
            {
                area = (p2 - p1) * _heightArray[p1];
                p1 += 1;
            }
            maxArea = maxArea < area ? area : maxArea;
        }

        _output = maxArea;
    }
}
