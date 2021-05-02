using System;
using System.Text;

namespace PersianTools.Modules
{
    public static class NumberToWords
    {
        private static readonly string[] UNITS_MAP = new[] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه", "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
        private static readonly string[] TENS_MAP = new[] { "صفر", "ده", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
        private static readonly string[] HUNDREDS_MAP = new[] { "صفر", "صد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
        private static readonly Scale[] SCALES = new[]
        {
            new Scale("هزار"),
            new Scale("میلیون"),
            new Scale("میلیارد"),
            new Scale("بیلیون"),
            new Scale("بیلیارد"),
            new Scale("تریلیون"),
        };

        public static string Convert(long number)
        {
            if (number == 0)
            {
                return "صفر";
            }
            if (number < 0)
            {
                return "منفی " + Convert(Math.Abs(number));
            }

            var words = new StringBuilder();

            number = ConvertScales(number, words);
            number = ConvertHundreds(number, words);
            ConvertRest(number, words);

            return words.ToString();
        }

        private static void ConvertRest(long number, StringBuilder words)
        {
            if (number <= 0)
            {
                return;
            }
            if (words.Length > 0)
            {
                words.Append(" و ");
            }

            var lowerThanTwenty = number < 20;
            words.Append(lowerThanTwenty ? UNITS_MAP[number] : TENS_MAP[number / 10]);
            if ((number % 10) > 0 && !lowerThanTwenty)
            {
                words.Append(" و ").Append(UNITS_MAP[number % 10]);
            }
        }

        private static long ConvertHundreds(long number, StringBuilder words)
        {
            if ((number / 100) == 0)
            {
                return number;
            }
            if (words.Length > 0)
            {
                words.Append(" و ");
            }

            words.Append(HUNDREDS_MAP[number / 100]);
            number %= 100;

            return number;
        }

        private static long ConvertScales(long number, StringBuilder words)
        {
            for (int i = SCALES.Length - 1; i >= 0; i--)
            {
                var scale = SCALES[i];
                var start = (long)Math.Pow(10, (i + 1) * 3);
                if ((number / start) > 0)
                {
                    if (words.Length > 0)
                    {
                        words.Append(" و ");
                    }

                    words.Append(Convert(number / start) + $" {scale.Name}");
                    number %= start;
                }
            }

            return number;
        }

        private class Scale
        {
            public Scale(string name)
            {
                Name = name;
            }
            public string Name { get; private set; }
        }
    }
}
