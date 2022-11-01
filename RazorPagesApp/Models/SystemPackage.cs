using System;
using System.Collections.Generic;

namespace RazorPagesApp
{
    public partial class SystemPackage
    {
        public SystemPackage()
        {
            OrdersLists = new HashSet<OrdersList>();
        }

        public int Id { get; set; }
        public string? SystemPackageName { get; set; }
        public string? Img { get; set; }
        public int? Price { get; set; }
        public int? TonnageId { get; set; }
        public string? SystemPackageDesc { get; set; }

        public virtual SystemTonnage? Tonnage { get; set; }
        public virtual ICollection<OrdersList> OrdersLists { get; set; }
    }
}
