using System;
using System.Diagnostics.CodeAnalysis;
using PersianTools.Modules;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class WordsToNumberTests
    {
        [Fact]
        public void Convert_Throw_ArgumentException_When_Input_Is_Null()
        {
            Action act = () => WordsToNumber.Convert(null);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Convert_Throw_ArgumentException_When_Input_Is_Default()
        {
            Action act = () => WordsToNumber.Convert(default);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Convert_Throw_ArgumentException_When_Input_Is_WhiteSpacec()
        {
            Action act = () => WordsToNumber.Convert(" ");

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("صفر", 0L)]
        [InlineData("یک", 1L)]
        [InlineData("دوازده", 12L)]
        [InlineData("صد", 100L)]
        [InlineData("یک هزار و یک", 1001L)]
        [InlineData("صد و یک", 101L)]
        [InlineData("منفی یک هزار", -1000L)]
        [InlineData("یک میلیارد", 1_000_000_000L)]
        [InlineData("نه تریلیون", 9_000_000_000_000_000_000L)]
        [InlineData("نه تریلیون و یک میلیون", 9_000_000_000_001_000_000L)]
        [InlineData("نه تریلیون و یک", 9_000_000_000_000_000_001L)]
        [InlineData("دو میلیارد و صد و چهل و هفت میلیون و چهارصد و هشتاد و سه هزار و ششصد و چهل و هفت", 2_147_483_647L)]
        [InlineData("منفی دو میلیارد و صد و چهل و هفت میلیون و چهارصد و هشتاد و سه هزار و ششصد و چهل و هشت", -2_147_483_648L)]
        [InlineData("نه تریلیون و دویست و بیست و سه بیلیارد و سیصد و هفتاد و دو بیلیون و سی و شش میلیارد و هشتصد و پنجاه و چهار میلیون و هفتصد و هفتاد و پنج هزار و هشتصد و هفت", 9_223_372_036_854_775_807L)]
        public void Convert_Returns_Expected_String_Successfully(string numberInWords, long expected)
        {
            Assert.Equal(expected, WordsToNumber.Convert(numberInWords));
        }
    }
}
