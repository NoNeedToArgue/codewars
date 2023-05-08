// Write a method that takes an array of consecutive (increasing) letters as input and that returns the missing letter in the array.

// You will always get an valid array. And it will be always exactly one letter be missing. The length of the array will always be at least 2.
// The array will always contain letters in only one case.

using System.Linq;

public class Kata
{
  public static char FindMissingLetter(char[] array)
  {
    return (char)Enumerable.Range(array[0], array.Length).Where(x => x != array[x - array[0]]).First();
  }
}