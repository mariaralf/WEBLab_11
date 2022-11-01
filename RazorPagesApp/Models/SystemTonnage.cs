using System;
using System.Collections.Generic;

namespace RazorPagesApp
{
    public partial class SystemTonnage
    {
        public SystemTonnage()
        {
            OrdersLists = new HashSet<OrdersList>();
            SystemPackages = new HashSet<SystemPackage>();
        }

        public int Id { get; set; }
        public string? SystemTonnageName { get; set; }

        public virtual ICollection<OrdersList> OrdersLists { get; set; }
        public virtual ICollection<SystemPackage> SystemPackages { get; set; }
    }
}
