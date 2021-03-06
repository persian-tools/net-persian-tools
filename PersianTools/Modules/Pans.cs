﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PersianTools.Modules
{
    public static class Pans
    {
        public static string GetBankName(string pan)
        {
            pan = CheckValidationAndExtract(pan);

            var code = string.Join("", pan.Take(6));
            EnsureBankNameIsAvaiable(code);
            return CODE_BANKNAME_MAP[code];
        }

        public static bool IsValid(string pan)
        {
            pan = CheckValidationAndExtract(pan);

            var r = pan
                .Select((digit, index) => SumOfDigits((digit - '0') * (index % 2 == 0 ? 2 : 1)))
                .Sum() % 10;

            return r == 0;
        }

        private static int SumOfDigits(int value)
        {
            return value.ToString()
                .Sum(x => x - '0');
        }

        private static string CheckValidationAndExtract(string pan)
        {
            if (string.IsNullOrWhiteSpace(pan))
            {
                throw new ArgumentException($"'{nameof(pan)}' cannot be null or whitespace", nameof(pan));
            }
            string englishPan = Digits.PersianToEnglishDigits(pan);
            englishPan = englishPan.Replace(" ", "")
                .Replace("-", "")
                .Replace("_", "")
                .Replace(",", "");

            if (englishPan.Count() != 16)
            {
                throw new ArgumentOutOfRangeException($"'{nameof(pan)}' should contains 16 digits.", nameof(pan));
            }
            if (!englishPan.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException($"'{nameof(pan)}' contains invalid characters!", nameof(pan));
            }

            return englishPan;
        }

        private static void EnsureBankNameIsAvaiable(string code)
        {
            if (!CODE_BANKNAME_MAP.ContainsKey(code))
            {
                throw new BankNotFoundException(code);
            }
        }

        private static readonly Dictionary<string, string> CODE_BANKNAME_MAP = new Dictionary<string, string>()
        {
            { "636214",  "بانک آینده" },
            { "627412", "بانک اقتصاد نوین" },
            { "627381", "بانک انصار" },
            { "505785", "بانک ایران زمین" },
            { "622106", "بانک پارسیان" },
            { "627884", "بانک پارسیان" },
            { "502229", "بانک پاسارگاد" },
            { "639347", "بانک پاسارگاد" },
            { "627760", "پست بانک ایران" },
            { "585983", "بانک تجارت" },
            { "627353", "بانک تجارت" },
            { "502908", "بانک توسعه تعاون" },
            { "207177", "بانک توسعه صادرات" },
            { "627648", "بانک توسعه صادرات" },
            { "636949", "بانک حکمت ایرانیان" },
            { "585949", "بانک خاورمیانه" },
            { "502938", "بانک دی" },
            { "504172", "بانک رسالت" },
            { "589463", "بانک رفاه کارگران" },
            { "621986", "بانک سامان" },
            { "589210", "بانک سپه" },
            { "639607", "بانک سرمایه" },
            { "639346", "بانک سینا" },
            { "502806", "بانک شهر" },
            { "504706", "بانک شهر" },
            { "603769", "بانک صادرات ایران" },
            { "903769", "بانک صادرات ایران" },
            { "627961", "بانک صنعت و معدن" },
            { "639370", "بانک قرض الحسنه مهر" },
            { "639599", "بانک قوامین" },
            { "627488", "بانک کارآفرین" },
            { "603770", "بانک کشاورزی" },
            { "639217", "بانک کشاورزی" },
            { "505416", "بانک گردشگری" },
            { "505426", "بانک گردشگری" },
            { "636797", "بانک مرکزی ایران" },
            { "628023", "بانک مسکن" },
            { "610433", "بانک ملت" },
            { "991975", "بانک ملت" },
            { "170019", "بانک ملی ایران" },
            { "603799", "بانک ملی ایران" },
            { "606373", "بانک مهر ایران" },
            { "505801", "موسسه کوثر" },
            { "606256", "موسسه اعتباری ملل" },
            { "628157", "موسسه اعتباری توسعه" },
        };
    }
}
