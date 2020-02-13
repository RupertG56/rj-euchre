using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Objects.Common
{
    public static class ListExtensions
    {
        public static void EmptyFill<T>(this IList<T> list, int capacity)
        {
            for (var i = 0; i < capacity; i++)
                list.Add(default(T));
        }
    }
}
