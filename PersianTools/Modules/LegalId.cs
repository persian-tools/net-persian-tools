using System.Linq;

namespace PersianTools.Modules
{
    public static class LegalId
    {
        public static bool Verify(string legalId)
        {
            const int legalLength = 11;
            if (legalId.Length > legalLength || legalId.Length == 0) return false;
            // check string has no illegal char
            if (legalId.Any(c => !int.TryParse(c.ToString(), out int res))) return false;

            int controller = legalId[legalId.Length - 1].ToInt();
            int m = legalId[legalId.Length - 2].ToInt() + 2;
            int[] z = { 29, 27, 23, 19, 17 };
            int sum = 0;
            for (int i = 0; i < legalId.Length - 1; i++)
            {
                sum += z[i % 5] * (legalId[i].ToInt() + m);
            }
            sum %= 11;
            if (sum == 10) sum = 0;
            return sum == controller;
        }
        private static int ToInt(this char c)
            => int.Parse(c.ToString());
    }
}
