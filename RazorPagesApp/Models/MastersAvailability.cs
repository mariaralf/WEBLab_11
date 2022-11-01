using System;
using System.Collections.Generic;

namespace RazorPagesApp
{
    public partial class MastersAvailability
    {
        public MastersAvailability()
        {
            OrdersLists = new HashSet<OrdersList>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? NumberOfMasters { get; set; }

        public virtual ICollection<OrdersList> OrdersLists { get; set; }
    }
}
