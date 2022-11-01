using System;
using System.Collections.Generic;

namespace RazorPagesApp
{
    public partial class OrdersList
    {
        public int Id { get; set; }
        public int? OrderSystemTypeId { get; set; }
        public int? OrderSystemTonnageId { get; set; }
        public int? OrderPackageId { get; set; }
        public int? OrderThermostatId { get; set; }
        public string? OrderOptionsIds { get; set; }
        public int? OrderDate { get; set; }

        public virtual MastersAvailability? OrderDateNavigation { get; set; }
        public virtual SystemPackage? OrderPackage { get; set; }
        public virtual SystemTonnage? OrderSystemTonnage { get; set; }
        public virtual SystemType? OrderSystemType { get; set; }
        public virtual Themostat? OrderThermostat { get; set; }
    }
}
