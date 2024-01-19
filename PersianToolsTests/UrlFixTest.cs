using PersianTools.Modules;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PersianToolsTests
{


    [ExcludeFromCodeCoverage]
    public class UrlFixTest
    {
        [Theory]
        [InlineData("https://fa.wikipedia.org/wiki/%D9%85%DA%A9%D8%A7%D9%86%DB%8C%DA%A9%20%DA%A9%D9%88%D8%A7%D9%86%D8%AA%D9%88%D9%85%DB%8C", "https://fa.wikipedia.org/wiki/مکانیک کوانتومی")]
        [InlineData("https://en.wikipedia.org/wiki/Persian_alphabet", "https://en.wikipedia.org/wiki/Persian_alphabet")]
        [InlineData("https://fa.wikipedia.org/wiki/%D8%AF%DB%8C%D8%A7%DA%A9%D9%88", "https://fa.wikipedia.org/wiki/دیاکو")]
        [InlineData("https://fa.wikipedia.org/wiki/%D9%85%D8%AF%DB%8C%D8%A7%D9%88%DB%8C%DA%A9%DB%8C:Gadget-Extra-Editbuttons-botworks.js","https://fa.wikipedia.org/wiki/مدیاویکی:Gadget-Extra-Editbuttons-botworks.js")]
        [InlineData(null, "")]

        public void Test_Url_without_separator(string input, string expected)
        {
            Assert.Equal(expected, UrlFix.Fix(input));
        }

        [Theory]
        [InlineData("https://fa.wikipedia.org/wiki/%D9%85%DA%A9%D8%A7%D9%86%DB%8C%DA%A9%20%DA%A9%D9%88%D8%A7%D9%86%D8%AA%D9%88%D9%85%DB%8C", "https://fa.wikipedia.org/wiki/مکانیک_کوانتومی")]
        [InlineData("Sample Text", "Sample_Text")]
        [InlineData("", "")]
        [InlineData(null, "")]

        public void Test_Url_with_separator(string input, string expected)
        {
            Assert.Equal(expected, UrlFix.Fix(input,"_"));
        }
    }
}
