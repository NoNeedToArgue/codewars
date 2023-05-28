// Create two functions to encode and then decode a string using the Rail Fence Cipher. This cipher is used to encode a string by placing each character successively in a diagonal along a set of "rails". First start off moving diagonally and down. When you reach the bottom, reverse direction and move diagonally and up until you reach the top rail. Continue until you reach the end of the string. Each "rail" is then read left to right to derive the encoded string.

// For example, the string "WEAREDISCOVEREDFLEEATONCE" could be represented in a three rail system as follows:

// W       E       C       R       L       T       E
//   E   R   D   S   O   E   E   F   E   A   O   C  
//     A       I       V       D       E       N    
// The encoded string would be:

// WECRLTEERDSOEEFEAOCAIVDEN
// Write a function/method that takes 2 arguments, a string and the number of rails, and returns the ENCODED string.

// Write a second function/method that takes 2 arguments, an encoded string and the number of rails, and returns the DECODED string.

// For both encoding and decoding, assume number of rails >= 2 and that passing an empty string will return an empty string.

// Note that the example above excludes the punctuation and spaces just for simplicity. There are, however, tests that include punctuation. Don't filter out punctuation as they are a part of the string.

using System;
using System.Text;

public class RailFenceCipher
{
    public static string Encode(string s, int n)
    {
        int[,] rails = Model(s.Length, n);

        var sb = new StringBuilder();

        for (var i = 0; i < rails.GetLength(0); i++)
        {
            for (var j = 0; j < rails.GetLength(1); j++)
            {
                if (rails[i, j] != 0)
                {
                    sb.Append(s[rails[i, j] - 1]);
                }
            }
        }

        return sb.ToString();
    }

    public static string Decode(string s, int n)
    {
        int[,] rails = Model(s.Length, n);
        var chars = new char[s.Length];
        var count = 0;

        for (var i = 0; i < rails.GetLength(0); i++)
        {
            for (var j = 0; j < rails.GetLength(1); j++)
            {
                if (rails[i, j] != 0)
                {
                    chars[rails[i, j] - 1] = s[count++];
                }
            }
        }

        return new string(chars);
    }

    private static int[,] Model(int l, int n)
    {
        var i = 0;
        var direction = 0;
        var j = 0;
        var rails = new int[n, l];

        while (j < l)
        {
            rails[direction == 0 ? i++ : i--, j++] = j;
            if (i == n - 1) direction = 1;
            if (i == 0) direction = 0;
        }

        return rails;
    }
}