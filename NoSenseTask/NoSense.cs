using System;
using System.Collections.Generic;

namespace CustomExtensions
{
    public static class NoSense
    {
        public static T ThisDoesNotMakeAnySense<T>(this IEnumerable<T> en, Predicate<T> pred, Delegate del)
        {
            if (en == null || pred == null || del == null)
            {
                throw new ArgumentNullException();
            }

            bool isInCollection = false;

            foreach (var item in en)
            {
                isInCollection = pred.Invoke(item);

                if (isInCollection)
                {
                    break;
                }
            }

            return isInCollection ? default : (T)del.DynamicInvoke(default(T));
        }
    }
}