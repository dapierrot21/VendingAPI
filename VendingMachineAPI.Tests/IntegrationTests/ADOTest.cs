using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineAPI.Data.Repositories;

namespace VendingMachineAPI.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTest
    {
        [Test]
        public void CanLoadItems()
        {
            var repo = new VendingMachineRepositoryADO();

            var items = repo.GetAllItems();

            Assert.AreEqual(10, items.Count());
            Assert.AreEqual("3D Printer - PLA", items[0].name);
            Assert.AreEqual(749.99M, items[0].price);
        }

        [Test]
        public void CanGrabItemById()
        {
            var repo = new VendingMachineRepositoryADO();

            var item = repo.GetItemById(0);

            Assert.IsNotNull(item);

            Assert.AreEqual(6, item.id);
        }
    }
}
