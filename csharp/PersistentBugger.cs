// Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, which is the number of times you must multiply the digits in num until you reach a single digit.

using System;
using System.Linq;

public class Persist 
{
	public static int Persistence(long n) 
	{
      var result = 0;
      
      while (n > 9)
      {
          result++;
          n = n.ToString().Select(x => x - '0').Aggregate(1, (res, val) => res * val);
      }
      
      return result;
	}
}