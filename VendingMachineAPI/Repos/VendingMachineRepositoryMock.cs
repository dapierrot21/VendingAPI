using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineAPI.Interface;
using VendingMachineAPI.Models;

namespace VendingMachineAPI.Repos
{
    public class VendingMachineRepositoryMock : IVendingMachineRepository
    {

        public static List<Item> _items = new List<Item>()
        {
            new Item
            {
                id = 1,
                name = "Twin Snakes",
                price = 1.89M,
                quantity = 8
            },

            new Item
            {
                id = 2,
                name = "Sea Moss",
                price = 30.00M,
                quantity = 100
            },

            new Item
            {
                id = 3,
                name = "Common Sense",
                price = 0.10M,
                quantity = 10
            }
        };

        public List<Item> GetAllItems()
        {
            var items = from item in _items
                        select new Item { id = item.id, name = item.name, price = item.price, quantity = item.quantity };

            return items.ToList();
        }

        public Item GetItemById(int id)
        {
            var itemIdMatch = from item in _items
                              where item.id == id
                              select item;

            return itemIdMatch.First();
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}