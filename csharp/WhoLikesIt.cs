// You probably know the "like" system from Facebook and other pages. People can "like" blog posts, pictures or other items. We want to create the text that should be displayed next to such an item.

// Implement the function which takes an array containing the names of people that like an item. It must return the display text as shown in the examples:

// []                                -->  "no one likes this"
// ["Peter"]                         -->  "Peter likes this"
// ["Jacob", "Alex"]                 -->  "Jacob and Alex like this"
// ["Max", "John", "Mark"]           -->  "Max, John and Mark like this"
// ["Alex", "Jacob", "Mark", "Max"]  -->  "Alex, Jacob and 2 others like this"

// Note: For 4 or more names, the number in "and 2 others" simply increases.

using System;
using System.Text;

public static class Kata
{
  public static string Likes(string[] name)
  {
    //throw new NotImplementedException();
    
    var sb = new StringBuilder("no one likes this");
     
    if (name.Length > 1)
        sb.Remove(11, 1);
    
    int others = name.Length - 2;
    
    switch(name.Length)
    {
        case 1:
          sb.Replace("no one", name[0]);
          break;
        case 2:
          sb.Replace("no one", name[0] + " and " + name[1]);
          break;
        case 3:
          sb.Replace("no one", name[0] + ", " + name[1] + " and " + name[2]);
          break;
        case > 3:
          sb.Replace("no one", name[0] + ", " + name[1] + " and " + others + " others");
          break;
    }
    
    return sb.ToString();
  }
}