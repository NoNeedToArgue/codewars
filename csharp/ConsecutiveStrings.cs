// You are given an array(list) strarr of strings and an integer k. Your task is to return the first longest string consisting of k consecutive strings taken in the array.

public class LongestConsecutives 
{
    
    public static string LongestConsec(string[] strarr, int k) 
    {
        
      int n = strarr.Length;
      if (n == 0 || k > n || k <= 0)
          return "";
        
      var result = "";
      var tmp = "";
      

      for (var i = 0; i < n - k + 1; i++)
      {
          tmp = strarr[i];
          for (var j = i + 1; j < i + k; j++)
          {
              tmp +=strarr[j];
          }
          if (tmp.Length > result.Length)
          {
            result = tmp;
          }
      }
      
      return result;
    }
}