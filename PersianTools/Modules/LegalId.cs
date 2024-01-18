using System.Linq;

namespace PersianTools.Modules
{
    public static class LegalId
    {
        public static bool Verify(string LegalId)
        {
            const int LegalLength = 11;
            if (LegalId.Length != LegalLength || string.IsNullOrWhiteSpace(LegalId)) return false;

            if (LegalId.Any(c => !char.IsDigit(c))) return false;

            const int ControllerIndex = 10;
            int controller = LegalId[ControllerIndex].ToInt();

            const int TensIndex = 9;
            const int DivideDigit = 11;
            int tensDigit = LegalId[TensIndex].ToInt();
            tensDigit += 2;

            int[] digitsCoefficient = { 29, 27, 23, 19, 17 };
            int sum = 0;
            for (int i = 0; i < ControllerIndex; i++)
            {
                sum += digitsCoefficient[i % 5] * (LegalId[i].ToInt() + tensDigit);
            }
            sum %= DivideDigit;
            if (sum == 10) sum = 0;
            return sum == controller;
        }
        private static int ToInt(this char c) => c - '0';

    }
}
