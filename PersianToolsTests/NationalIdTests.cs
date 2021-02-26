using System;
using System.Diagnostics.CodeAnalysis;
using PersianTools.Modules;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class NationalIdTests
    {
        [Fact]
        public void IsValid_Throws_ArgumentException_When_Input_Is_Null()
        {
            Action act = () => NationalId.IsValid(null);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void IsValid_Throws_ArgumentException_When_Input_Is_Default()
        {
            Action act = () => NationalId.IsValid(default);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void IsValid_Throws_ArgumentException_When_Input_Is_WhiteSpacec()
        {
            Action act = () => NationalId.IsValid(" ");

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("123456789")]
        [InlineData("12345678901")]
        [InlineData("A")]
        [InlineData("123456789A")]
        [InlineData("A234567890")]
        [InlineData("ABCDEFGHIJ")]
        [InlineData("ABCDEFGHIJK")]
        public void IsValid_Throws_ArgumentException_When_Input_Is_Not_Ten_Digit_String(string nationalId)
        {
            Action act = () => NationalId.IsValid(nationalId);

            var exception = Assert.Throws<FormatException>(act);
        }

        [Theory]
        [InlineData("3930045370")]
        [InlineData("۳۹۳۰۰۴۵۳۷۰")]
        [InlineData("6222492411")]
        [InlineData("4226919459")]
        [InlineData("2868244378")]
        [InlineData("6882531447")]
        [InlineData("5029114866")]
        [InlineData("0411517775")]
        [InlineData("2643943694")]
        [InlineData("5268586343")]
        [InlineData("3123416542")]
        [InlineData("9370838171")]
        [InlineData("7731689956")]
        public void IsValid_Returns_True_Input_Is_Correct_NationalId(string nationalId)
        {
            Assert.True(NationalId.IsValid(nationalId));
        }

        [Theory]
        [InlineData("7333914246")]
        [InlineData("۷۳۳۳۹۱۴۲۴۶")]
        [InlineData("8701942005")]
        [InlineData("8045927730")]
        [InlineData("0937585061")]
        [InlineData("3464532124")]
        [InlineData("3264685900")]
        [InlineData("9310777266")]
        [InlineData("7838979238")]
        [InlineData("3063962472")]
        [InlineData("0324779713")]
        [InlineData("9756087473")]
        public void IsValid_Returns_True_Input_Is_InCorrect_NationalId(string nationalId)
        {
            Assert.False(NationalId.IsValid(nationalId));
        }
    }
}
