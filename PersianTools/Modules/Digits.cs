using System;
using System.Collections.Generic;
using System.Text;

namespace PersianTools.Modules
{
    public static class Digits
    {
        internal readonly static Dictionary<char, char> PERSIAN_ENG_DIGITS_MAP = new Dictionary<char, char>
        {
            {'۰', '0' }, {'۱', '1' }, {'۲', '2' }, {'۳', '3' }, {'۴', '4' }, {'٤', '4' },
            {'۵', '5' }, {'٥', '5' }, {'٦', '6' }, {'۶', '6' }, {'۷', '7' }, {'۸', '8' }, {'۹', '9' },
        };
        internal readonly static Dictionary<char, char> Eng_PERSIAN_DIGITS_MAP = new Dictionary<char, char>
        {
            { '0','۰' }, { '1','۱' }, { '2','۲' }, { '3','۳' }, { '4','۴' },
            { '5','۵' }, { '6','۶' }, { '7','۷' }, { '8','۸' }, { '9','۹' },
        };

        public static string PersianToEnglishDigits(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException($"'{nameof(str)}' cannot be null or whitespace", nameof(str));
            }
            var builder = new StringBuilder(str.Length);
            foreach (var @char in str)
            {
                var convertedChar = PERSIAN_ENG_DIGITS_MAP.ContainsKey(@char) ?
                    PERSIAN_ENG_DIGITS_MAP[@char] :
                    @char;
                builder.Append(convertedChar);
            }
            return builder.ToString();
        }

        public static string EnglishToPersianDigits(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException($"'{nameof(str)}' cannot be null or whitespace", nameof(str));
            }
            var builder = new StringBuilder(str.Length);
            foreach (var @char in str)
            {
                var convertedChar = Eng_PERSIAN_DIGITS_MAP.ContainsKey(@char) ?
                    Eng_PERSIAN_DIGITS_MAP[@char] :
                    @char;
                builder.Append(convertedChar);
            }
            return builder.ToString();
        }
    }
}
