// Define a function that takes an integer argument and returns a logical value true or false depending on if the integer is a prime.

// Per Wikipedia, a prime number ( or a prime ) is a natural number greater than 1 that has no positive divisors other than 1 and itself.

// Requirements
// You can assume you will be given an integer input.
// You can not assume that the integer will be only positive. You may be given negative numbers as well ( or 0 ).
// NOTE on performance: There are no fancy optimizations required, but still the most trivial solutions might time out. Numbers go up to 2^31 ( or similar, depending on language ). Looping all the way up to n, or n/2, will be too slow.

using System;

public static class Kata
{
  public static bool IsPrime(int n)
  {
      if (n == 2)
          return true;
      if (n < 2 || n % 2 == 0)
          return false;
    
      double k = Math.Sqrt(Convert.ToDouble(n));
    
      for (var i = 3; i <= k; i++)
      {
          if (n % i == 0)
              return false;
          i++;
      }
    
      return true;
  }
}