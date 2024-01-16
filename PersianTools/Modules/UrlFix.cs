using System.Web;

namespace PersianTools.Modules
{
    public static class UrlFix
    {
        public static string Fix(string url)
        => HttpUtility.UrlDecode(url);
        public static string Fix(string url, string separator)
        => HttpUtility.UrlDecode(url).Replace(" ", separator);
    }
}
