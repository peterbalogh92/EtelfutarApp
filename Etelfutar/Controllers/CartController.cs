using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Etelfutar.Models;

namespace Etelfutar.Controllers
{
    public class CartController : Controller
    {

        private EtelfutarDbEntities entities = new EtelfutarDbEntities();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        private int IsExist(Guid id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }     
            }

            return -1;
        }

        private int GetTotal(List<Item> items)
        {
            int sum = 0;

            foreach (var item in items)
            {
                sum += (int)(item.Product.Price * item.Quantity);
            }

            return sum;
        }

        public ActionResult Add(Guid id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>
                {
                    new Item(entities.MenuItems.Find(id), 1)
                };
                TempData["msg"] = "Sikeres hozzáadás!";
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                if (GetTotal(cart) + entities.MenuItems.Find(id).Price > 20000)
                {
                    TempData["msg"] = "Legfeljebb 20.000 Ft végösszeg engedélyezett.";
                }
                else
                {
                    int index = IsExist(id);
                    if (index == -1)
                    {
                        cart.Add(new Item(entities.MenuItems.Find(id), 1));
                    }
                    else
                    {
                        cart[index].Quantity++;
                    }
                    Session["cart"] = cart;
                    TempData["msg"] = "Sikeres hozzáadás!";
                }
            }

            return RedirectToAction("Product", "Home", new { category = entities.MenuItems.Find(id).Category});
        }

        public ActionResult Delete(Guid id)
        {
            int index = IsExist(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Pay()
        {

            Customers newCustomer = new Customers();

            return View(newCustomer);
        }
        
        [HttpPost]
        public ActionResult Pay(Customers c)
        {
            foreach (var item in (List<Item>)Session["cart"])
            {
                OrderItems orderItem = new OrderItems
                {
                    ProductId = item.Product.Id,
                    Quantity = item.Quantity,
                    CustomerId = item.CustomerId
                };

                entities.OrderItems.Add(orderItem);
            }

            entities.Orders.Add(c);
            entities.SaveChanges();

            ((List<Item>)Session["cart"]).Clear();

            return Redirect("/");
        }

        public ActionResult Clear()
        {
            ((List<Item>)Session["cart"]).Clear();

            return Redirect("/");
        }
    }
}