using Entities.DomainModels;

namespace MvcWebUI.Helpers
{
    public interface ICartSessionHelper
    {
        void Clear();
        Cart GetCart(string key);
        void SetCart(string key,Cart cart);
       
    }
}
