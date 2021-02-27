using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PersianTools.Modules
{
    public static class WordsToNumber
    {
        private static readonly Dictionary<string, long> WORDS_NUMBER_MAP = new Dictionary<string, long>()
        {
            { "صفر", 0}, { "یک", 1 }, { "دو", 2 }, { "سه", 3 }, { "چهار", 4 }, { "پنج",5},{"شش",6},{"شیش",6},
            {"هفت",7},{"هشت",8},{"نه",9},{"ده",10},{"یازده",11},{"دوازده",12},
            {"سیزده",13},{"چهارده",14},{"پانزده",15},{"شانزده",16},{"هفده",17},
            {"هجده",18},{"نوزده",19},{"بیست",20},{"سی",30},{"چهل",40},
            {"پنجاه",50},{"شصت",60},{"هفتاد",70},{"هشتاد",80},{"نود",90},
            {"صد",100},{"دویست",200},{"سیصد",300},{"چهارصد",400},{"پانصد",500},{"ششصد",600},
            {"شیشصد",600},{"هفتصد",700},{"هشتصد",800},{"نهصد",900},
            {"هزار",1_000},{"میلیون",1_000_000},
            {"میلیارد",1_000_000_000},{"بیلیون",1_000_000_000_000},{"بیلیارد",1_000_000_000_000_000},
            {"تریلیون",1_000_000_000_000_000_000}
        };

        public static long Convert(string numberString)
        {
            if (string.IsNullOrWhiteSpace(numberString))
            {
                throw new System.ArgumentException($"'{nameof(numberString)}' cannot be null or whitespace", nameof(numberString));
            }

            string input = numberString.Replace(" و ", " ");
            var numbers = Regex.Matches(input, @"\w+")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .Where(v => WORDS_NUMBER_MAP.ContainsKey(v))
                    .Select(v => WORDS_NUMBER_MAP[v])
                    .ToArray();
            long acc = 0, total = 0L;
            foreach (var n in numbers)
            {
                if (n >= 1000)
                {
                    total += acc * n;
                    acc = 0;
                }
                else
                {
                    acc += n;
                }
            }
            return (total + acc) * (numberString.StartsWith("منفی") ? -1 : 1);
        }
    }
}
