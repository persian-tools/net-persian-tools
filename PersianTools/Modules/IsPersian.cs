﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PersianTools.Modules
{
    public static class IsPersian
    {
        internal readonly static HashSet<char> PERSIAN_CHARS = new HashSet<char>
            ("ٰٟٖٞ،؍٫٬؛؞؟۔٭٪؉؊؈؎؏۞۩؆؇؋٠۰١۱٢۲٣۳٤۴٥۵٦۶٧۷٨۸٩۹ءٴ۽آأٲٱؤإٳئاٵٮبٻپڀة-ثٹٺټٽٿجڃڄچڿڇحخځڂڅدذڈ-ڐۮرزڑ-ڙۯسشښ-ڜۺصضڝڞۻطظڟعغڠۼفڡ-ڦٯقڧڨكک-ڴػؼلڵ-ڸم۾نں-ڽڹهھہ-ۃۿەۀوۥٶۄ-ۇٷۈ-ۋۏىيۦٸی-ێېۑؽ-ؿؠےۓآابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیئؤأي".ToCharArray());

        public static bool IncludePersianChar(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException($"'{nameof(str)}' cannot be null or whitespace", nameof(str));
            }

            return str.Any(x => PERSIAN_CHARS.Contains(x));
        }
    }
}
