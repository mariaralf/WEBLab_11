using System;
using System.Collections.Generic;

namespace RazorPagesApp
{
    public partial class Option
    {
        public int Id { get; set; }
        public string? OptionName { get; set; }
        public string? OptionDesc { get; set; }
        public int? Price { get; set; }
        public string? Img { get; set; }
    }
}
