using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService , ICartSessionHelper cartSessionHelper ,IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
           _productService = productService; 
            
        }

        public ActionResult AddToCart( int productId)
        {
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart(key:"cart");

            _cartService.AddToCart(cart, product);
            _cartSessionHelper.SetCart(key:"cart",cart);
            TempData.Add("message", product.ProductName + "sepete eklendi !");

            return RedirectToAction("Index",controllerName:"Product");
        }
        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
              cart = _cartSessionHelper.GetCart(key:"cart")
              
            };
            return View(model);
        }
           
        
        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart(key: "cart");

            _cartService.RemoveFromCart(cart, productId);
            _cartSessionHelper.SetCart("cart", cart);
            TempData.Add("message", product.ProductName + "sepetten silindi !");

            return RedirectToAction("Index", controllerName: "Cart");
            

        }
        public IActionResult Complete() 
        {
            var model = new ShippingDetailsViewModel
            {
                shippingDetail = new ShippingDetail()
            };
            return View();
        
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {   
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", "Siparişiniz başarıyla tamamlandı");

            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Cart");
        }
    

    }
    

    
    
}
