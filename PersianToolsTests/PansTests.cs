using System;
using PersianTools.Modules;
using Xunit;

namespace PersianToolsTests
{
    public class PansTests
    {
        [Fact]
        public void GetBankName_Throw_ArgumentException_When_Input_Is_Null()
        {
            Action act = () => Pans.GetBankName(null);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void GetBankName_Throw_ArgumentException_When_Input_Is_Default()
        {
            Action act = () => Pans.GetBankName(default);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void GetBankName_Throw_ArgumentException_When_Input_Is_WhiteSpacec()
        {
            Action act = () => Pans.GetBankName(" ");

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void GetBankName_Throw_BankNotFoundException_When_Bank_Was_Not_Found()
        {
            Action act = () => Pans.GetBankName("1234567890123456");

            var exception = Assert.Throws<BankNotFoundException>(act);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("123456789012345")]
        [InlineData("1234567-89012345")]
        [InlineData("12345678901234567")]
        [InlineData("123456789012345678")]
        [InlineData("12345678901234567890")]
        public void GetBankName_Throw_ArgumentOutOfRangeException_When_Input_Digits_Count_Is_Invalid(string pan)
        {
            Action act = () => Pans.GetBankName(pan);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData("6362147890123456", "بانک آینده")]
        [InlineData("6393467890123456", "بانک سینا")]
        [InlineData("۶۲۷9617890123456", "بانک صنعت و معدن")]
        [InlineData("6280 2378 9012 3456", "بانک مسکن")]
        [InlineData("6104-3378-9012-3456", "بانک ملت")]
        [InlineData("6062_5678_9012_3456", "موسسه اعتباری ملل")]
        [InlineData("5057857890123456789", "بانک ایران زمین")]
        public void GetBankName_Returns_Expected_BankName_Successfully(string pan, string expectedBankName)
        {
            Assert.Equal(expectedBankName, Pans.GetBankName(pan));
        }
    }
}
