using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber,int pageSize)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(pageNumber),"Page number must be greater than zero.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(pageSize),"Page size must be greater than zero.");
        }

        int startIndex = (pageNumber - 1) * pageSize;
        int currentIndex = 0;

        foreach (T item in source)
        {
            if (currentIndex >= startIndex &&
                currentIndex < startIndex + pageSize)
            {
                yield return item;
            }

            if (currentIndex >= startIndex + pageSize - 1)
            {
                yield break;
            }

            currentIndex++;
        }
    }

    public static T? FindById<T>( this IEnumerable<T> source,int id)
       where T : IHasId
    {
        foreach (T item in source)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(
        this IEnumerable<T> source)
        where T : IHasId
    {
        Dictionary<int, T> dictionary = new();

        foreach (T item in source)
        {
            dictionary.Add(item.Id, item);
        }

        return new ReadOnlyDictionary<int, T>(
            dictionary);
    }
}

