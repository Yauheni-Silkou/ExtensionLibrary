using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class BooleanEx
    {
        public static bool Any(this bool value, params bool[] booleans)
        {
            return booleans.Contains(value);
        }
        public static bool All(this bool value, params bool[] booleans)
        {
            return !booleans.Contains(!value);
        }
    }


    public static class ArrayEx
    {
        public static void Populate<T>(this T[] array, T value)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length; i++) array[i] = value;
        }
        public static void Populate(this int[] array, int value, int increment)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length; i++) array[i] = value + increment * i;
        }
        public static int[] Populated(int length, int value, int increment)
        {
            int[] array = new int[length];
            for (int i = 0; i < array.Length; i++) array[i] = value + increment * i;
            return array;
        }
    }

    
    public static class EnumEx
    {
        public static T[] ToArray<T>()
        {
            return Enum.GetValues(typeof(T)) as T[];
        }
        public static List<T> ToList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
        }
        public static string[] GetNames<T>()
        {
            return Enum.GetNames(typeof(T));
        }
        public static string[] GetNames<T>(Dictionary<T, string> dictionary)
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(s => dictionary[s]).ToArray<string>();
        }
    }
}
