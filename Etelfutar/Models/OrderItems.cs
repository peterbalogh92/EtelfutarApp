//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Etelfutar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItems
    {
        public int Id { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> CustomerId { get; set; }
    
        public virtual MenuItems MenuItems { get; set; }
        public virtual Customers Customers { get; set; }
    }
}