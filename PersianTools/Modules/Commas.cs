namespace PersianTools.Modules
{
    public static class Commas
    {
        public static string Add(uint number)
        {
            return number.ToString("#,##0");
        }

        public static string Add(int number)
        {
            return number.ToString("#,##0");
        }

        public static string Add(long number)
        {
            return number.ToString("#,##0");
        }

        public static string Add(ulong number)
        {
            return number.ToString("#,##0");
        }

        public static string Add(short number)
        {
            return number.ToString("#,##0");
        }

        public static string Add(ushort number)
        {
            return number.ToString("#,##0");
        }

        public static long Parse(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new System.ArgumentException($"'{nameof(number)}' cannot be null or whitespace", nameof(number));
            }
            return long.Parse(number.Replace(",", ""));
        }
    }
}
