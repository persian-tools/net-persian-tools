using System;
using System.Diagnostics.CodeAnalysis;
using PersianTools.Modules;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class DigitsTests
    {
        [Fact]
        public void ToEnglishDigits_Throw_ArgumentException_When_Input_Is_Null()
        {
            Action act = () => Digits.PersianToEnglishDigits(null);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ToEnglishDigits_Throw_ArgumentException_When_Input_Is_Default()
        {
            Action act = () => Digits.PersianToEnglishDigits(default);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ToEnglishDigits_Throw_ArgumentException_When_Input_Is_WhiteSpacec()
        {
            Action act = () => Digits.PersianToEnglishDigits(" ");

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("0123456789", "۰۱۲۳۴۵۶۷۸۹")]
        [InlineData("0123456789", "0۱۲۳۴۵۶۷۸۹")]
        [InlineData("9", "۹")]
        [InlineData("012349", "۰۱234۹")]
        [InlineData("0123456789", "۰۱۲۳۴۵۶۷۸9")]
        [InlineData("01ABC456789", "۰۱ABC۴۵۶۷۸9")]
        [InlineData("456", "٤٥٦")]
        [InlineData("زسئرمسنئر", "زسئرمسنئر")]
        [InlineData("ABC", "ABC")]
        public void ToEnglishDigits_Returns_Expected_String_Successfully(string expected, string actual)
        {
            Assert.Equal(expected, Digits.PersianToEnglishDigits(actual));
        }

        [Fact]
        public void EnglishToPersianDigits_Throw_ArgumentException_When_Input_Is_Null()
        {
            Action act = () => Digits.EnglishToPersianDigits(null);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void EnglishToPersianDigits_Throw_ArgumentException_When_Input_Is_Default()
        {
            Action act = () => Digits.EnglishToPersianDigits(default);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void EnglishToPersianDigits_Throw_ArgumentException_When_Input_Is_WhiteSpacec()
        {
            Action act = () => Digits.EnglishToPersianDigits(" ");

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("۰۱۲۳۴۵۶۷۸۹", "0123456789")]
        [InlineData("۰۱۲۳۴۵۶۷۸۹", "۰123456789")]
        [InlineData("۹", "9")]
        [InlineData("۰۱۲۳۴۹", "01۲۳۴9")]
        [InlineData("۰۱۲۳۴۵۶۷۸۹", "۰۱۲۳۴۵۶۷۸9")]
        [InlineData("۰۱ABC۴۵۶۷۸۹", "۰۱ABC۴۵۶۷۸9")]
        [InlineData("زسئرمسنئر", "زسئرمسنئر")]
        [InlineData("ABC", "ABC")]
        public void EnglishToPersianDigits_Returns_Expected_String_Successfully(string expected, string actual)
        {
            Assert.Equal(expected, Digits.EnglishToPersianDigits(actual));
        }
    }
}
