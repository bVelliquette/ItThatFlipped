using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaData
{
    public class ProphecyListingModel
    {
        public List<Prophecy> Lines { get; set; }
    }
    public class Prophecy
    {
        public string Name { get; set; }
        public float chaosValue { get; set; }
    }
}
