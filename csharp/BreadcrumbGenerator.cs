// As breadcrumb menùs are quite popular today, I won't digress much on explaining them, leaving the wiki link to do all the dirty work in my place.

// What might not be so trivial is instead to get a decent breadcrumb from your current url. For this kata, your purpose is to create a function that takes a url, strips the first part (labelling it always HOME) and then builds it making each element but the last a <a> element linking to the relevant path; last has to be a <span> element getting the active class.

// All elements need to be turned to uppercase and separated by a separator, given as the second parameter of the function; the last element can terminate in some common extension like .html, .htm, .php or .asp; if the name of the last element is index.something, you treat it as if it wasn't there, sending users automatically to the upper level folder.

// A few examples can be more helpful than thousands of words of explanation, so here you have them:

// Kata.GenerateBC("mysite.com/pictures/holidays.html", " : ") == '<a href="/">HOME</a> : <a href="/pictures/">PICTURES</a> : <span class="active">HOLIDAYS</span>';
// Kata.GenerateBC("www.codewars.com/users/GiacomoSorbi", " / ") == '<a href="/">HOME</a> / <a href="/users/">USERS</a> / <span class="active">GIACOMOSORBI</span>';
// Kata.GenerateBC("www.microsoft.com/docs/index.htm", " * ") == '<a href="/">HOME</a> * <span class="active">DOCS</span>';
// Seems easy enough?

// Well, probably not so much, but we have one last extra rule: if one element (other than the root/home) is longer than 30 characters, you have to shorten it, acronymizing it (i.e.: taking just the initials of every word); url will be always given in the format this-is-an-element-of-the-url and you should ignore words in this array while acronymizing: ["the","of","in","from","by","with","and", "or", "for", "to", "at", "a"]; a url composed of more words separated by - and equal or less than 30 characters long needs to be just uppercased with hyphens replaced by spaces.

// Ignore anchors (www.url.com#lameAnchorExample) and parameters (www.url.com?codewars=rocks&pippi=rocksToo) when present.

// Examples:

// You will always be provided valid url to webpages in common formats, so you probably shouldn't bother validating them.

using System;
using System.Text;
using System.Linq;

public class Kata {

  public static string GenerateBC(string url, string separator)
  {
      
    var sb = new StringBuilder();
    string[] tempsubs = url.Split('#', '?');
    string[] subs = tempsubs[0].Split('/');
    string pathsub = String.Empty;

    if (subs[subs.Count() - 1].Contains("index") || subs[subs.Count() - 1].Length == 0)
    {
        subs = subs.SkipLast(1).ToArray();
    }

    foreach (string sub in subs)
    {
        if (sb.Length == 0 && !sub.Contains('.'))
            continue;

        if (Array.IndexOf(subs, sub) == subs.Count() - 1)
        {
            string[] dot = sub.Split('.');
            sb.Append("<span class=\"active\">" + (sb.Length == 0 ? "HOME" :
                dot[0].Length > 30 ? Acron(dot[0]) : dot[0])
                .Replace('-', ' ').ToUpper() + "</span>");
        }
        else if (sb.Length == 0)
        {
            sb.Append("<a href=\"/\">HOME</a>" + separator);
        }
        else
        {
           pathsub += sub + "/";
           sb.Append("<a href=\"/" + pathsub + "\">" + (sub.Length > 30 ? Acron(sub) : sub.Replace('-', ' ').ToUpper()) + "</a>" + separator);
        }
    }

    return sb.ToString();
  }
  
  static string Acron(string s)
  {
    string[] shorts = { "the", "of", "in", "from", "by", "with", "and", "or", "for", "to", "at", "a" };
    string[] lstr = s.Split('-');

    var lsb = new StringBuilder();

    foreach (string l in lstr)
    {
        if (shorts.Contains(l)) continue;
        lsb.Append(l[0].ToString().ToUpper());
    }

    return lsb.ToString();
  }
}