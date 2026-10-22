
using System;
using System.Collections.Generic;

namespace src;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(
        this IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(pageNumber),
                "Page number must be greater than or equal to 1.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(pageSize),
                "Page size must be greater than or equal to 1.");
        }

        int startIndex = (pageNumber - 1) * pageSize;
        int currentIndex = 0;
        int returnedItems = 0;

        foreach (T item in source)
        {
            if (currentIndex >= startIndex)
            {
                yield return item;
                returnedItems++;

                if (returnedItems == pageSize)
                {
                    yield break;
                }
            }

            currentIndex++;
        }
    }

    public static T? FindById<T>(
        this IEnumerable<T> source,
        int id)
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
        Dictionary<int, T> result = new Dictionary<int, T>();

        foreach (T item in source)
        {
            if (result.ContainsKey(item.Id))
            {
                throw new ArgumentException(
                    $"Duplicate ID found: {item.Id}.",
                    nameof(source));
            }

            result.Add(item.Id, item);
        }

        return result;
    }
}
