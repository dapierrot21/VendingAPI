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
    public class MockTest
    {
        [Test]
        public void CanLoadItems()
        {
            var repo = new VendingMachineRepositoryMock();

            var items = repo.GetAllItems();

            Assert.AreEqual(3, items.Count());
            Assert.AreEqual("Twin Snakes", items[0].name);
            Assert.AreEqual(1.89M, items[0].price);
        }

        [Test]
        public void CanGrabItemById()
        {
            var repo = new VendingMachineRepositoryMock();

            var item = repo.GetItemById(1);

            Assert.IsNotNull(item);

            Assert.AreEqual(1, item.id);
        }
    }
}
