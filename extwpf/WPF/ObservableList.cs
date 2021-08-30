using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExtensions
{
    public static class ObservableListExtension
    {
        public static ObservableList<T> ObservableList<T>(this IEnumerable<T> collection)
        {
            return new ObservableList<T>(collection);
        }
    }

    public class ObservableList<T> : ObservableCollection<T>
    {
        public static implicit operator ObservableList<T>(List<T> list) => new ObservableList<T>(list);
        public static implicit operator ObservableList<T>(T[] list) => new ObservableList<T>(list);
        public static implicit operator ObservableList<T>(T[,] list) => new ObservableList<T>(list.Cast<T>());
        public static implicit operator ObservableList<T>(T[,,] list) => new ObservableList<T>(list.Cast<T>());
        public static implicit operator ObservableList<T>(T[][] list) => new ObservableList<T>(list.Cast<T>());
        public static implicit operator ObservableList<T>(T obj) => new ObservableList<T>() { obj };

        public static implicit operator List<T>(ObservableList<T> list) => new List<T>(list);
        public static implicit operator T[](ObservableList<T> list) => new T[] { }.Concat(list).ToArray();
        public static implicit operator T(ObservableList<T> list)
        {
            if (list == null || list.Count == 0) return default;
            return list[0];
        }



        public static ObservableList<T> operator +(ObservableList<T> first, ObservableList<T> second) => new ObservableList<T>(first.Concat(second));
        public static ObservableList<T> operator +(ObservableList<T> first, ObservableCollection<T> second) => new ObservableList<T>(first.Concat(second));
        public static ObservableList<T> operator +(ObservableCollection<T> first, ObservableList<T> second) => new ObservableList<T>(first.Concat(second));
        public static ObservableList<T> operator +(ObservableList<T> first, IEnumerable<T> second) => new ObservableList<T>(first.Concat(second));
        public static ObservableList<T> operator +(IEnumerable<T> first, ObservableList<T> second) => new ObservableList<T>(first.Concat(second));
        public static ObservableList<T> operator +(ObservableList<T> first, IOrderedEnumerable<T> second) => new ObservableList<T>(first.Concat(second));
        public static ObservableList<T> operator +(IOrderedEnumerable<T> first, ObservableList<T> second) => new ObservableList<T>(first.Concat(second));



        public static ObservableList<T> operator -(ObservableList<T> first, ObservableList<T> second) => new ObservableList<T>(first.Except(second));
        public static ObservableList<T> operator -(ObservableList<T> first, ObservableCollection<T> second) => new ObservableList<T>(first.Except(second));
        public static ObservableList<T> operator -(ObservableCollection<T> first, ObservableList<T> second) => new ObservableList<T>(first.Except(second));
        public static ObservableList<T> operator -(ObservableList<T> first, IEnumerable<T> second) => new ObservableList<T>(first.Except(second));
        public static ObservableList<T> operator -(IEnumerable<T> first, ObservableList<T> second) => new ObservableList<T>(first.Except(second));
        public static ObservableList<T> operator -(ObservableList<T> first, IOrderedEnumerable<T> second) => new ObservableList<T>(first.Except(second));
        public static ObservableList<T> operator -(IOrderedEnumerable<T> first, ObservableList<T> second) => new ObservableList<T>(first.Except(second));



        // assignments

        // old = new  ------- not possible

        // if not, then

        // old = _ / new  --- possible
        // old /= new   ----- possible
        
        /// <summary>
        /// Simple assignment without conversion.
        ///     * old = new; - doesn't work.
        ///     * old /= new; - works.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="collection"></param>
        /// <returns>Returns collection.</returns>
        public static ObservableList<T> operator /(ObservableList<T> _, IEnumerable<T> collection) => new ObservableList<T>(collection);
        /// <summary>
        /// Simple assignment without conversion.
        ///     * old = new; - doesn't work.
        ///     * old /= new; - works.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="collection"></param>
        /// <returns>Returns collection.</returns>
        public static ObservableList<T> operator /(ObservableList<T> _, IOrderedEnumerable<T> collection) => new ObservableList<T>(collection);
        /// <summary>
        /// Simple assignment without conversion.
        ///     * old = new; - doesn't work.
        ///     * old /= new; - works.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="collection"></param>
        /// <returns>Returns collection.</returns>
        public static ObservableList<T> operator /(ObservableList<T> _, ObservableCollection<T> collection) => new ObservableList<T>(collection);

        public ObservableList<T> DistinctBy(Func<T, object> keySelector)
        {
            ObservableList<T> result = null;
            result /= this.GroupBy(keySelector).Select(x => x.First());
            return result;
        }

        public ObservableList() : base() { }
        public ObservableList(IEnumerable<T> collection) : base(collection) { }
        public ObservableList(List<T> list) : base(list) { }
    }
}
