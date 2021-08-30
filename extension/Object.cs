using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Extensions
{
    public static class ObjectEx
    {
        public static bool In<T>(this T value, params T[] list)
        {
            return list.Contains(value);
        }
        public static bool OutOf<T>(this T value, params T[] list)
        {
            return !list.Contains(value);
        }

        /// <summary>
        /// Create a full copy of an object (need a [Serializable] attribute)
        /// </summary>
        public static T DeepClone<T>(this T toClone)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, toClone);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}

namespace Extensions.Safe
{
    public static class ObjectEx
    {
        public static bool InSafe<T>(this T value, params T[] list)
        {
            return list == null ? false : list.Contains(value);
        }
        public static bool OutOfSafe<T>(this T value, params T[] list)
        {
            return list == null ? true : !list.Contains(value);
        }
    }
}
