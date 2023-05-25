// You will be given a number and you will need to return it as a string in Expanded Form. For example:

// Kata.ExpandedForm(12); # Should return "10 + 2"
// Kata.ExpandedForm(42); # Should return "40 + 2"
// Kata.ExpandedForm(70304); # Should return "70000 + 300 + 4"
// NOTE: All numbers will be whole numbers greater than 0.

using System;
using System.Text;

public static class Kata 
{
    public static string ExpandedForm(long num) 
    {
        string s = num.ToString();
        int n = s.Length;
        StringBuilder result = new();

        for (var i = 0; i < n; i++)
        {
            if (s[i] != '0')
                result.Append((Char.GetNumericValue(s[i]) * Math.Pow(10, n - i - 1)).ToString() + " + ");
        }

        result.Length -= 3;
        return result.ToString(); 
    }
}