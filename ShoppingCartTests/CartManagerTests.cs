using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Tests
{
    [TestClass()]
    public class CartManagerTests
    {
        private CartManager _cartManager;
        private CartItem _cartItem;

        [TestInitialize]
        public void TestInitialize()
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem()
            {
                Product = new Product()
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 45_000
                },
                Quantity = 8
            };

            _cartManager.Add(_cartItem);
        }

        [TestCleanup] 
        public void TestCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod()]
        public void SepeteUrunEklenebilmelidirTest()
        {
            //Action 
            //_cartManager.Add(_cartItem);
            int countOfCartItems = _cartManager.GetCartItemsCount();

            //Assert 
            Assert.AreEqual(1, countOfCartItems);
        }

        [TestMethod()]
        public void SepettenUrunCikarilabilmelidirTest()
        {
            int countOfItemsBeforeRemove = _cartManager.GetCartItemsCount();

            //Action
            bool isRemoved = _cartManager.Remove(1);
            int countOfItemsAfterRemove = _cartManager.GetCartItemsCount();

            //Assert
            Assert.IsTrue(isRemoved);
            Assert.AreEqual(countOfItemsAfterRemove, countOfItemsBeforeRemove - 1);
        }

        [TestMethod()]
        public void SepetTemizlenebilmelidirTest()
        {
            //Action 
            _cartManager.Clear();

            //Assert 
            Assert.AreEqual(0, _cartManager.GetCartItemsCount());
        }
    }
}