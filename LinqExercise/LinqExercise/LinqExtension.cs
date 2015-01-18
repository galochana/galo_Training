using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise
{
    public static class LinqExtension
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source", Messages.ArgumentNullExceptionMessage);

            if (predicate == null)
                throw new ArgumentNullException("predicate", Messages.ArgumentNullExceptionMessage);

            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}
