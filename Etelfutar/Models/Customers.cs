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
    using System.ComponentModel;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            this.OrderItems = new HashSet<OrderItems>();
        }
    
        public int Id { get; set; }
        [DisplayName("N�v")]
        public string Name { get; set; }
        [DisplayName("C�m")]
        public string Address { get; set; }
        [DisplayName("Telefonsz�m")]
        public string Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
