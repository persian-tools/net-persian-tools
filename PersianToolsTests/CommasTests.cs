using System;
using System.Diagnostics.CodeAnalysis;
using PersianTools.Modules;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class CommasTests
    {
        [Fact]
        public void Add_Returns_Comma_Seperated_String_When_Input_Is_Int16()
        {
            Assert.Equal("10,279", Commas.Add((short)10279));
        }

        [Fact]
        public void Add_Returns_Comma_Seperated_String_When_Input_Is_UInt16()
        {
            Assert.Equal("1,023", Commas.Add((ushort)1023));
        }

        [Fact]
        public void Add_Returns_Comma_Seperated_String_When_Input_Is_Int32()
        {
            Assert.Equal("23,456,789", Commas.Add(23456789));
        }

        [Fact]
        public void Add_Returns_Comma_Seperated_String_When_Input_Is_UInt32()
        {
            Assert.Equal("123,456,789", Commas.Add((uint)123456789));
        }

        [Fact]
        public void Add_Returns_Comma_Seperated_String_When_Input_Is_Int64()
        {
            Assert.Equal("1,234,567,890,123", Commas.Add(1234567890123));
        }

        [Fact]
        public void Add_Returns_Comma_Seperated_String_When_Input_Is_UInt64()
        {
            Assert.Equal("12,345,678,901", Commas.Add((ulong)12345678901));
        }

        [Fact]
        public void Parse_Throws_ArgumentException_When_Input_Is_Null()
        {
            Action act = () => Commas.Parse(null);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Parse_Throws_ArgumentException_When_Input_Is_Default()
        {
            Action act = () => Commas.Parse(default);

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Parse_Throws_ArgumentException_When_Input_Is_WhiteSpacec()
        {
            Action act = () => Commas.Parse(" ");

            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("123", 123L)]
        [InlineData("123,987", 123987L)]
        [InlineData("0", 0L)]
        [InlineData("123,456,789,012,345,678", 123456789012345678L)]
        public void Parse_Return_Equivalient_Number_Of_Comma_Separated_String(string given, long expected)
        {
            Assert.Equal(expected, Commas.Parse(given));
        }
    }
}
