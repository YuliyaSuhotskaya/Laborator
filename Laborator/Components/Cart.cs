using Laborator.Models;
using Microsoft.AspNetCore.Mvc;
using Laborator.Entities;
using Laborator.Extensions;



namespace Laborator.Components
{
	public class CartViewComponent: ViewComponent
	{

		private Cart _cart;
		public CartViewComponent(Cart cart)
		{
			_cart = cart;
		}
		public IViewComponentResult Invoke()
		{
			//var cart = HttpContext.Session.Get<Cart>("cart");
			return View(_cart);
		}
	}
}
