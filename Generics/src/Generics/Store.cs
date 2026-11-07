using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics;

public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = new();

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException(
                $"An item with ID {item.Id} already exists.");
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

    public IReadOnlyDictionary<int, T> GetAll()
    {
        return new ReadOnlyDictionary<int, T>(_items);
    }

    public bool Remove(int id)
    {
        return _items.Remove(id);
    }
}