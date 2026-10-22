
using src;
using System;
using System.Collections.Generic;

public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = new Dictionary<int, T>();

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new ArgumentException(
                $"An item with ID {item.Id} already exists.",
                nameof(item));
        }

        _items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        if (_items.TryGetValue(id, out T? item))
        {
            return item;
        }

        return default;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return new List<T>(_items.Values).AsReadOnly();
    }

    public bool Remove(int id)
    {
        return _items.Remove(id);
    }
}
