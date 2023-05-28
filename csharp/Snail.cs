// Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

// array = [[1,2,3],
//          [4,5,6],
//          [7,8,9]]
// snail(array) #=> [1,2,3,6,9,8,7,4,5]
// For better understanding, please follow the numbers of the next array consecutively:

// array = [[1,2,3],
//          [8,9,4],
//          [7,6,5]]
// snail(array) #=> [1,2,3,4,5,6,7,8,9]

// NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

// NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].

using System.Collections.Generic;

public class SnailSolution
{
   public static int[] Snail(int[][] array)
   {
        int n = array[0].Length;
        if (n == 0) return new int[0];
     
        int l = n * n;
        List<int> result = new();
        int level = 0;
                
        while (result.Count < l)
        {

            for (var j = level; j < n - level; j++)
            {   
                result.Add(array[level][j]);
            }

            for (var i = level + 1; i < n - level; i++)
            {
                result.Add(array[i][n - level - 1]);
            }

            if (result.Count == l)
            {
                break;
            }

            for (var j = n - level - 2; j >= level; j--)
            {
                result.Add(array[n - level - 1][j]);
            }
            
            for (var i = n - level - 2; i >= 1 + level; i--)
            {
                result.Add((array[i][level]));
            }

            level++;
        }

        return result.ToArray();
   }
}