using ProblemSolving.Abstractions;
using ProblemSolving.DataStructures;
using ProblemSolving.Framework;

namespace ProblemSolving.Problems;

/// <summary>
/// You are given two non-empty linked lists representing two non-negative integers.
/// The digits are stored in reverse order, and each of their nodes contains a single digit.
/// Add the two numbers and return the sum as a linked list.
/// <see cref="https://leetcode.com/problems/add-two-numbers/description/"/>
/// </summary>
[ProblemId(2)]
public class AddTwoNumbers : IProblem
{
    private ListNode l1;
    private ListNode l2;
    private ListNode output;
    
    public AddTwoNumbers(int[] arr1, int[] arr2)
    {
        l1 = new ListNode();
        l2 = new ListNode();
        ListNode current = l1;
        PopulateListNodes(arr1, current);
        current = l2;
        PopulateListNodes(arr2, current);
    }
    
    public void Execute()
    {
        output = new ListNode();
        var current = output;
        int result, remainder = 0;
        bool flagL1 = false;
        bool flagL2 = false;
        while (true)
        {
            result = l1.val + l2.val + remainder;
            int sum = result % 10;
            remainder = result / 10;
            current.val = sum;
            l1 = l1.next;
            l2 = l2.next;
            flagL1 = l1 == null;
            flagL2 = l2 == null;
            if (flagL1 || flagL2)
            {
                break;
            }
            var node = new ListNode();
            current.next = node;
            current = current.next;
        }

        if (flagL1 && flagL2)
        {
            if (remainder > 0)
            {
                var node = new ListNode();
                node.val = remainder;
                current.next = node;
            }

            return;
        }
        else if (flagL1)
        {
            ProcessRemainingNodes(l2, current, result, remainder);
        }
        else
        {
            ProcessRemainingNodes(l1, current, result, remainder);
        }
        
    }
    
    public void DisplayResult()
    {
        while (output != null)
        {
            Console.Write(output.val + " ");
            output = output.next;
        }
    }

    private void ProcessRemainingNodes(ListNode l, ListNode current, int result, int remainder)
    {
        while (true)
        {
            result = l.val + remainder;
            int sum = result % 10;
            remainder = result / 10;
            var newNode = new ListNode();
            newNode.val = sum;
            current.next = newNode;
            current = current.next;
            if (l.next == null)
            {
                if (remainder > 0)
                {
                    var remainderNode = new ListNode();
                    remainderNode.val = remainder;
                    current.next = remainderNode;
                }
                break;
            }
            l = l.next;
        }

        return;
    }

    private void PopulateListNodes(int[] arr, ListNode current)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            current.val = arr[i];
            if (i != arr.Length - 1)
            {
                var next = new ListNode();
                current.next = next;
                current = current.next;
            }
        }
    }
}
