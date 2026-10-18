
using src;
using System.Collections.Generic;

public class Store<T> where T : IHasId
{
    private readonly List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T? GetById(int id)
    {
        foreach (T item in _items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

    public List<T> GetAll()
    {
        return new List<T>(_items);
    }

    public bool Remove(int id)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Id == id)
            {
                _items.RemoveAt(i);
                return true;
            }
        }

        return false;
    }
}
