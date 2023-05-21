// Given two arrays a and b write a function comp(a, b) (orcompSame(a, b)) that checks whether the two arrays have the "same" elements, with the same multiplicities (the multiplicity of a member is the number of times it appears). "Same" means, here, that the elements in b are the elements in a squared, regardless of the order.

using System;
using System.Collections.Generic;

class AreTheySame
{
  public static bool comp(int[] a, int[] b)
  {
      if (a == null || b == null)
          return false;
      
      int n = a.Length;
      var list = new List<int>(b);
    
      for (var i = 0; i < n; i++)
      for (var j = 0; j < list.Count; j++)
      {
          if (Math.Sqrt(list[j]) == a[i])
          {
            list.RemoveAt(j);
          }
      }
      
      return list.Count == 0;
  }
}