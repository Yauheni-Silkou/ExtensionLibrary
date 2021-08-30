using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfExtensions
{
    public static class OservableCollectionEx
    {
        public static void AddRange<T>(this ObservableCollection<T> thisCollection, IEnumerable<T> collection)
        {
            foreach (T obj in collection) thisCollection.Add(obj);
        }
        public static T Find<T>(this ObservableCollection<T> collection, Predicate<T> match)
        {
            return collection.ToList().Find(match);
        }
        public static T FindLast<T>(this ObservableCollection<T> collection, Predicate<T> match)
        {
            return collection.ToList().FindLast(match);
        }
    }
}
