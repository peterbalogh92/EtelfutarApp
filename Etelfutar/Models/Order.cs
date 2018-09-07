using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Etelfutar.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Guid> Products { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Order()
        {
            this.Products = new List<Guid>();
        }
    }
}