using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PersianTools.Modules
{
    public static class NationalId
    {
        private static readonly Regex NATIONAL_ID_PATTERN = new Regex("^\\d{10}$");
        private static readonly char[] LAST_DIGIT = new[]
        {
            '0', '1', '9', '8', '7', '6', '5', '4', '3', '2', '1'
        };

        public static bool IsValid(string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId))
            {
                throw new ArgumentException($"'{nameof(nationalId)}' cannot be null or whitespace", nameof(nationalId));
            }
            if (!NATIONAL_ID_PATTERN.IsMatch(nationalId))
            {
                throw new FormatException(nameof(nationalId));
            }
            var r = nationalId
                .Take(9)
                .Select((digit, index) => (digit - '0') * (10 - index))
                .Sum() % 11;
            return nationalId.Last() == LAST_DIGIT[r];
        }
    }
}
