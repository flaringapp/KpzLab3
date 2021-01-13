using System;
using System.Collections.Generic;

namespace Lab3
{
    public static class LinqExtensions
    {
        public static T MinBy<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
            var minValue = int.MaxValue;
            var minT = default(T);

            foreach (var t in list)
            {
                var value = selector.Invoke(t);
                if (value >= minValue) continue;
                minT = t;
                minValue = value;
            }
            return minT;
        }

        public static T MinBy<T>(this IEnumerable<T> list, Func<T, float> selector)
        {
            var minValue = float.MaxValue;
            var minT = default(T);

            foreach (var t in list)
            {
                var value = selector.Invoke(t);
                if (!(value < minValue)) continue;
                minT = t;
                minValue = value;
            }
            return minT;
        }

        public static T MaxBy<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
            var maxValue = int.MinValue;
            var minT = default(T);

            foreach (var t in list)
            {
                var value = selector.Invoke(t);
                if (value <= maxValue) continue;
                minT = t;
                maxValue = value;
            }
            return minT;
        }

        public static T MaxBy<T>(this IEnumerable<T> list, Func<T, float> selector)
        {
            var maxValue = float.MinValue;
            var minT = default(T);

            foreach (var t in list)
            {
                var value = selector.Invoke(t);
                if (!(value > maxValue)) continue;
                minT = t;
                maxValue = value;
            }
            return minT;
        }
    }
}