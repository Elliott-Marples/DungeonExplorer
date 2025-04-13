using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory : IEnumerable<Item>
    {
        // Private Properties
        private List<Item> _items;

        // Inventory Constructor
        public Inventory(List<Item> items = null)
        {
            _items = items ?? new List<Item>();
        }

        // Public Properties
        public List<Item> Items { get => _items; private set => _items = value; }
        public int Count => _items.Count;

        // Inventory Methods
        public void Add(Item item) => _items.Add(item);
        public void Remove(Item item) => _items.Remove(item);
        public void Remove(int index) => _items.RemoveAt(index);
        public bool Contains(Item item) => _items.Contains(item);

        // Allows simple iteration through the inventory
        public IEnumerator<Item> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
