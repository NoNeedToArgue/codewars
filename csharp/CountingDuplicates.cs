// Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.

using System;
using System.Collections.Generic;

public class Kata
{
  public static int DuplicateCount(string str)
  {    
    str = str.ToLower();
    
    var dict = new Dictionary<char, int>();
    
    int counter = 0;
    
    foreach (char s in str)
    {
        if (dict.ContainsKey(s))
        {
            if (dict[s] == 0)
            {
                dict[s] = 1;
                counter++;
            }
        }
        else
        {
            dict.Add(s, 0);
        }
    }
    
    return counter;
  }
}