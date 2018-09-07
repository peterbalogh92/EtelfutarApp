using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Etelfutar.Models
{
    public class Item
    {
        private MenuItems product = new MenuItems();

        private int quantity;

        public int CustomerId { get; set; }

        public Item()
        {
        }

        public Item(MenuItems product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public MenuItems Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}