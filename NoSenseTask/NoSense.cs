using System;
using System.Collections.Generic;

namespace CustomExtensions
{
    public static class NoSense
    {
        public static T ThisDoesNotMakeAnySense<T>(this IEnumerable<T> en, Predicate<T> pred, Func<T> del)
        {
            if (en == null || pred == null || del == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in en)
            {
                if (pred(item))
                {
                    return default;
                }
            }

            return del();
        }
    }
}