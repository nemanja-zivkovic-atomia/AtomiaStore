﻿using Atomia.Store.AspNetMvc.Infrastructure;
using Atomia.Store.AspNetMvc.Models;
using Atomia.Store.Core;
using System.Web.Mvc;

namespace Atomia.Store.AspNetMvc.Controllers
{
    public sealed class CartController : Controller
    {
        private readonly Cart cart;

        public CartController()
        {
            var cartProvider = DependencyResolver.Current.GetService<ICartProvider>();
            this.cart = cartProvider.GetCart();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new CartModel(cart));
        }

        [ChildActionOnly]
        public ActionResult Partial()
        {
            return PartialView(new CartModel(cart));
        }

        [HttpPost]
        public JsonResult AddItem(CartItemModel item)
        {
            if (ModelState.IsValid)
            {
                cart.AddItem(item.CartItem);

                return JsonEnvelope.Success(new CartModel(cart));
            }

            return JsonEnvelope.Fail(ModelState);
        }

        [HttpPost]
        public JsonResult RemoveItem(CartItemRemoveModel removeItem)
        {
            if (ModelState.IsValid)
            {
                cart.RemoveItem(removeItem.Id);

                return JsonEnvelope.Success(new CartModel(cart));
            }

            return JsonEnvelope.Fail(ModelState);
        }

        [HttpPost]
        public JsonResult ChangeQuantity(CartItemQuantityChangeModel quantityChangeItem)
        {
            if (ModelState.IsValid)
            {
                cart.ChangeQuantity(quantityChangeItem.Id, quantityChangeItem.Quantity);

                return JsonEnvelope.Success(new CartModel(cart));
            }

            return JsonEnvelope.Fail(ModelState);
        }
    }
}