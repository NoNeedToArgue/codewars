// You will be given an array of numbers. You have to sort the odd numbers in ascending order while leaving the even numbers at their original positions.

using System.Linq;

public class Kata
{
  public static int[] SortArray(int[] array)
  {
    int n = array.Length;
    int[] tmp = array.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();
    
    int j = 0;
    for (var i = 0; i < n; i++)
    {
        if (array[i] % 2 != 0)
        {
            array[i] = tmp[j++];
        }
    }

    return array;
  }
}