// Complete the solution so that the function will break up camel casing, using a space between words.

using System.Text;

public class Kata
{
  public static string BreakCamelCase(string str)
  {
      var result = new StringBuilder();

      foreach (char c in str)
      {
          if (c - 'A' < 26)
          {
              result.Append(' ');
          }

          result.Append(c);
      }

      return result.ToString();
  }
}