using System;
using System.Collections.Generic;

namespace RazorPagesApp
{
    public partial class SystemType
    {
        public SystemType()
        {
            OrdersLists = new HashSet<OrdersList>();
        }

        public int Id { get; set; }
        public string? SystemTypeName { get; set; }
        public string? Img { get; set; }

        public virtual ICollection<OrdersList> OrdersLists { get; set; }
    }
}
