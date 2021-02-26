using System.Diagnostics.CodeAnalysis;
using PersianTools.Modules;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class NumberToWordsTests
    {
        [Theory]
        [InlineData(0L, "صفر")]
        [InlineData(1L, "یک")]
        [InlineData(12L, "دوازده")]
        [InlineData(100L, "صد")]
        [InlineData(101L, "صد و یک")]
        [InlineData(-1000L, "منفی یک هزار")]
        [InlineData(1_000_000_000, "یک میلیارد")]
        [InlineData(9_000_000_000_000_000_000, "نه تریلیون")]
        [InlineData(9_000_000_000_001_000_000, "نه تریلیون و یک میلیون")]
        [InlineData(9_000_000_000_000_000_001, "نه تریلیون و یک")]
        [InlineData(2_147_483_647, "دو میلیارد و صد و چهل و هفت میلیون و چهارصد و هشتاد و سه هزار و ششصد و چهل و هفت")]
        [InlineData(-2_147_483_648, "منفی دو میلیارد و صد و چهل و هفت میلیون و چهارصد و هشتاد و سه هزار و ششصد و چهل و هشت")]
        [InlineData(9_223_372_036_854_775_807, "نه تریلیون و دویست و بیست و سه بیلیارد و سیصد و هفتاد و دو بیلیون و سی و شش میلیارد و هشتصد و پنجاه و چهار میلیون و هفتصد و هفتاد و پنج هزار و هشتصد و هفت")]
        public void ToEnglishDigits_Returns_Expected_String_Successfully(long number, string expected)
        {
            Assert.Equal(expected, NumberToWords.Convert(number));
        }
    }
}
