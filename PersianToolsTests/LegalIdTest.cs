using PersianTools.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class LegalIdTest
    {
        [Theory]
        [InlineData("123000000", false)]
        [InlineData("11111111111", false)]
        [InlineData("10380284792", false)]
        [InlineData("10380285692", false)]
        [InlineData("09748208301", false)]
        [InlineData("10380284790", true)]
        [InlineData("", false)]
        [InlineData(null, false)]

        public void Check_Legal(string input, bool expected)
        {
            Assert.Equal(expected, LegalId.Verify(input));
        }
    }
}
