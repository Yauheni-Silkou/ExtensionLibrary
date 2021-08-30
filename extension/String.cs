using System.Linq;

namespace Extensions
{
    public static class StringEx
    {
        public static T ToEnum<T>(this string str)
            where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), str, true);
        }
        public static T[] ToEnum<T>(this string[] strings)
            where T : struct
        {
            return strings.Select(s => (T)System.Enum.Parse(typeof(T), s, true)).ToArray();
        }
        public static string Left(this string str, int length)
        {
            return str != null && str.Length > length ? str.Substring(0, length) : str;
        }
        public static string Right(this string str, int length)
        {
            return str != null && str.Length > length ? str.Substring(str.Length - length) : str;
        }
        public static string Middle(this string str, int left, int right)
        {
            return str != null && str.Length > left + right ? str.Substring(left, str.Length - left - right) : str;
        }
        public static string CutLeft(this string str, int length)
        {
            return str != null && str.Length >= length ? str.Substring(length) : str;
        }
        public static string CutRight(this string str, int length)
        {
            return str != null && str.Length >= length ? str.Substring(0, str.Length - length) : str;
        }
        public static string CutMiddle(this string str, int left, int right)
        {
            return str != null && str.Length >= left + right ? str.Substring(0, left) + str.Substring(str.Length - right) : str;
        }
        public static string Format(this string str, params object[] args)
        {
            return string.Format(str, args);
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static bool IsFilled(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
        public static bool Contains(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        public static bool Contains(this string str, string value)
        {
            return !string.IsNullOrEmpty(str) && str.Contains(value);
        }
        public static bool NotContains(this string str, string value)
        {
            return string.IsNullOrEmpty(str) || !str.Contains(value);
        }
    }
}
