using System;
using System.Collections.Generic;

namespace RazorPagesApp
{
    public partial class Themostat
    {
        public Themostat()
        {
            OrdersLists = new HashSet<OrdersList>();
        }

        public int Id { get; set; }
        public string? ThermoName { get; set; }
        public string? Img { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<OrdersList> OrdersLists { get; set; }
    }
}
