using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    //Gereksinimler : 
    //1. Sepete ürün eklenebilmelidir.
    //2. Sepetten ürün çıkarılabilmelidir.
    //3. Sepet temizlenebilmelidir.
    public class CartManager
    {
        private readonly List<CartItem> _cartItems;

        public CartManager()
        {
            _cartItems = new List<CartItem>();
        }

        public bool Add(CartItem cartItem)
        {
            int countOfItems = _cartItems.Count;
            _cartItems.Add(cartItem);
            if (_cartItems.Count > countOfItems)
            {
                return true;
            }
            return false;
        }

        public bool Remove(int productId)
        {
            CartItem cartItem = _cartItems.FirstOrDefault(c => c.Product.ProductId == productId);
            int countOfItems = _cartItems.Count;
            _cartItems.Remove(cartItem);
            if (_cartItems.Count < countOfItems)
                return true;
            return false;
        }

        public bool Clear()
        {
            _cartItems.Clear();
            if (_cartItems.Count == 0)
                return true;
            return false;
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public int GetCartItemsCount()
        {
            return _cartItems.Count;
        }
    }
}
