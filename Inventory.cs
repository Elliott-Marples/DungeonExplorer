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

        // Inventory Constructor
        public Inventory(List<Item> items = null)
        {
            Items = items ?? new List<Item>();
        }

        // Public Properties
        public List<Item> Items { get; private set; }
        public int Count => Items.Count;

        // Inventory Methods
        public void Add(Item item) => Items.Add(item);
        public void Remove(Item item) => Items.Remove(item);
        public void Remove(int index) => Items.RemoveAt(index);
        public bool Contains(Item item) => Items.Contains(item);

        // Allows simple iteration through the inventory
        public IEnumerator<Item> GetEnumerator() => Items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
