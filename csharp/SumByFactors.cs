// Given an array of positive or negative integers

//  I= [i1,..,in]

// you have to produce a sorted array P of the form

// [ [p, sum of all ij of I for which p is a prime factor (p positive) of ij] ...]

// P will be sorted by increasing order of the prime numbers. The final result has to be given as a string in Java, C#, C, C++ and as an array of arrays in other languages.

using System.Text;
using System.Collections.Generic;
using System;

public class SumOfDivided {
	
	public static string sumOfDivided(int[] lst) {
      
      var dict = new SortedDictionary<int, int>();

      foreach (int num in lst)
      {
          HashSet<int> primes = GetPrimes(Math.Abs(num));

          foreach (int prime in primes)
          {
              if (dict.ContainsKey(prime))
              {
                  dict[prime] += num;
              }
              else
              {
                  dict.Add(prime, num);
              }
          }
      }

      var sb = new StringBuilder();

      foreach (int key in dict.Keys)
      {
          sb.Append($"({key} {dict[key]})");
      }

      return sb.ToString();

      static HashSet<int> GetPrimes(int num)
      {
          var primes = new HashSet<int>();

          for (var i = 2; i * i <= num; i++)
          {
              while (num % i == 0)
              {
                  primes.Add(i);
                  num /= i;
              }
         }

          if (num != 1)
          {
              primes.Add(num);
          }

          return primes;
      }
  }
}