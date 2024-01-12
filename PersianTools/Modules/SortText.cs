using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersianTools.Modules
{
    public static class SortText
    {
        public static string[] Sort(string text)
        => Sort(text.Split(' '));
        public static string[] Sort(params string[] texts)
        => texts.OrderBy(c => c).ToArray();
    }
}
