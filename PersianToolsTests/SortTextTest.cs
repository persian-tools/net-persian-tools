using PersianTools.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace PersianToolsTests
{
    [ExcludeFromCodeCoverage]
    public class SortTextTest
    {
        [Theory]
        [InlineData(new string[] { "مومنی", "هستم", "سلام", "مهدی" }, new string[] { "سلام", "مومنی", "مهدی", "هستم" })]
        [InlineData(new string[] { "اب", "اا" }, new string[] { "اا", "اب" })]
        [InlineData(new string[] { "مهدی" }, new string[] { "مهدی" })]
        [InlineData(new string[] { "۲ مهدی", "۱ مهدی" }, new string[] { "۱ مهدی", "۲ مهدی" })]
        [InlineData(new string[] { "" }, new string[] { "" })]
        [InlineData(null, new string[] { "" })]

        public void Check_Array_Sorting(string[] input, string[] expected)
        {
            Assert.Equal(expected, SortText.Sort(input));
        }

        [Theory]
        [InlineData("سلام علی ترکی", new string[] { "ترکی", "سلام", "علی" })]
        [InlineData("سلام علی ترکی سلام", new string[] { "ترکی", "سلام", "سلام", "علی" })]
        [InlineData(null, new string[] { "" })]

        public void Check_String_Sorting(string input, string[] expected)
        {
            Assert.Equal(expected, SortText.Sort(input));
        }
    }
}
