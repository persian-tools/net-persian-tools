using System;
using System.Diagnostics.CodeAnalysis;
using PersianTools.Modules;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class IsPersianTests
    {
        [Fact]
        public void Throw_ArgumentException_When_Input_Is_Null()
        {
            Action act = () => IsPersian.IncludePersianChar(null);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Throw_ArgumentException_When_Input_Is_Default()
        {
            Action act = () => IsPersian.IncludePersianChar(default);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Throw_ArgumentException_When_Input_Is_WhiteSpacec()
        {
            Action act = () => IsPersian.IncludePersianChar(" ");

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("۰۱۲۳۴۵۶۷۸۹")]
        [InlineData("0۱۲۳۴۵۶۷۸۹")]
        [InlineData("۹")]
        [InlineData("۰۱234۹")]
        [InlineData("۰۱۲۳۴۵۶۷۸9")]
        [InlineData("۰۱ABC۴۵۶۷۸9")]
        [InlineData("زسئرمسنئر")]
        [InlineData("،")]
        [InlineData("أ")]
        [InlineData("ئ")]
        [InlineData("گ")]
        public void Return_True_When_Input_Contains_Persian_Chars(string str)
        {
            Assert.True(IsPersian.IncludePersianChar(str));
        }

        [Theory]
        [InlineData("0123456789")]
        [InlineData("gtuhsnimdkl,26516")]
        [InlineData("#$%^&*")]
        [InlineData("sf5s6f1")]
        [InlineData("0")]
        [InlineData("Qué lindo día")]
        [InlineData("Який приємний день ")]
        [InlineData("Τι ωραία ημέρα ")]
        [InlineData("なんていい日だ ")]
        [InlineData("多好的一天啊")]
        [InlineData("किती छान दिवस आहे ")]
        [InlineData("♥")]
        [InlineData("◄↕‼¶§▬↨↑)")]
        public void Return_False_When_Input_Does_Not_Contain_Persian_Chars(string str)
        {
            Assert.False(IsPersian.IncludePersianChar(str));
        }
    }
}
