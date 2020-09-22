using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaData
{
    public class UniqueListingModel
    {
        public List<Unique> Lines { get; set; }
    }
    public class Unique
    {
        public string Name { get; set; }
        public float chaosValue { get; set; }
        public int links { get; set; }
    }
}
