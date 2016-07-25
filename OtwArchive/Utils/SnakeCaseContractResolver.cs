using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OtwArchive.Utils
{
  public class SnakeCaseContractResolver : DefaultContractResolver
  {
    private readonly string _separator = "_";

    protected override string ResolvePropertyName(string propertyName)
    {
        var parts = new List<string>();
        var currentWord = new StringBuilder();
 
        foreach (var c in propertyName)
        {
            if (char.IsUpper(c) && currentWord.Length > 0)
            {
                parts.Add(currentWord.ToString());
                currentWord.Clear();
            }
            currentWord.Append(char.ToLower(c));
        }
 
        if (currentWord.Length > 0)
        {
            parts.Add(currentWord.ToString());
        }
 
        return string.Join(_separator, parts.ToArray());
    }
  }
}