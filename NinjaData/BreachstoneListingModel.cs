using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaData
{
    public class BreachstoneListingModel
    {
        public List<Fragment> Lines { get; set; }
    }

    public class Fragment
    {
        public string CurrencyTypeName { get; set; }
        public float chaosEquivalent { get; set; }
    }
}
