using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersianTools.Modules
{
    public static class SortText
    {
        public static string[] Sort(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return new[] { "" };
            return Sort(text.Split(' '));
        }
        public static string[] Sort(params string[] texts)
        => (texts ?? new[] { "" }).OrderBy(c => c).ToArray();
    }
}
