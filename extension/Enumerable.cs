using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumerableEx
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T value)
        {
            return source.Concat(new List<T> { value });
        }
        public static IEnumerable<T> Populate<T>(this IEnumerable<T> source, T value)
        {
            return source.Select(x => value);
        }
        public static IEnumerable<T> Populate<T>(this IEnumerable<T> source, T value, int amount)
        {
            if (amount < 0) amount = 0;
            return new T[amount].Select(x => value);
        }
        public static IEnumerable<T> Populate<T>(this IEnumerable<T> source, Func<T> func)
        {
            return source.Select(x => func());
        }
        public static IEnumerable<T> Populate<T>(this IEnumerable<T> source, Func<T> func, int amount)
        {
            if (amount < 0) amount = 0;
            return new T[amount].Select(x => func());
        }
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            Random rnd = new Random();
            return source.OrderBy(x => rnd.Next());
        }
        public static IEnumerable<int> Randomize(this IEnumerable<int> source, int min, int max)
        {
            return source.Randomize(min, max, source.Count());
        }
        public static IEnumerable<int> Randomize(this IEnumerable<int> source, int min, int max, int amount)
        {
            if (amount < 0) amount = 0;
            if (min >= max) return source.Populate(min);
            Random rnd = new Random();
            return new int[amount].Select(x => Rnd.Int(min, max));
        }
        public static string DisplayAll<T>(this IEnumerable<T> source, string separator = "\n")
        {
            string s = "";
            foreach (var x in source) s += x + separator;
            return s;
        }
        public static bool NoAny<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }
        public static bool NoAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }
        public static bool NotAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.All(predicate);
        }
        public static bool NotContains<T>(this IEnumerable<T> source, T value)
        {
            return !source.Contains(value);
        }
        public static bool SequenceNotEqual<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            return !source.SequenceEqual(second);
        }
    }

    namespace Safe
    {
        public static class EnumerableEx
        {
            public static bool AnySafe<T>(this IEnumerable<T> source)
            {
                return source == null ? false : source.Any();
            }
            public static bool AnySafe<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                return source == null ? false : source.Any(predicate);
            }
            public static bool NoAnySafe<T>(this IEnumerable<T> source)
            {
                return source == null ? true : !source.Any();
            }
            public static bool NoAnySafe<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                return source == null ? true : !source.Any(predicate);
            }
            public static bool AllSafe<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                return source == null ? true : source.All(predicate);
            }
            public static bool NotAllSafe<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                return source == null ? false : !source.All(predicate);
            }
        }
    }
}
