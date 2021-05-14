using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineAPI.Models;

namespace VendingMachineAPI.Interface
{
    public interface IVendingMachineRepository
    {
        List<Item> GetAllItems();
        Item GetItemById(int id);
        void Update(Item item);
    }
}
