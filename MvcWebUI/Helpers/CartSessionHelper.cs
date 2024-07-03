using Entities.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcWebUI.Extensions;

namespace MvcWebUI.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
       private IHttpContextAccessor _httpContextAcccessor;
        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcccessor = httpContextAccessor;
        }

        public void Clear()
        {
           _httpContextAcccessor.HttpContext.Session.Clear();
        }

        public Cart GetCart(string key)
        {
            Cart cartToCheck = _httpContextAcccessor.HttpContext.Session.GetObject<Cart>(key);
            if (cartToCheck == null)
            {
                SetCart(key, new Cart());
                cartToCheck = _httpContextAcccessor.HttpContext.Session.GetObject<Cart>(key);
            }
            return cartToCheck;
        }

        public void SetCart(string key,Cart cart)
        {
            _httpContextAcccessor.HttpContext.Session.SetObject(key, cart);
        }
    }
}


