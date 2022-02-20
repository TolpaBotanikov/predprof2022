using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predprof2022
{
    public class AKES_outputs
    {
        public int active_blocks { get; set; }
        public float? active_power_A { get; set; }
        public float? active_power_A_off { get; set; }
        public float? active_power_B { get; set; }
        public float? active_power_B_off { get; set; }
        public float? active_power_C { get; set; }
        public float? active_power_C_off { get; set; }
        public DateTime datetime_end { get; set; }
        public DateTime datetime_start { get; set; }
        public List<float?> all = new List<float?>();
        public int akes_id { get; set; }
        public double cos_A { get; set; }
        public double? cos_A_off { get; set; }
        public double cos_B { get; set; }
        public double? cos_B_off { get; set; }
        public double cos_C { get; set; }
        public double? cos_C_off { get; set; }
        public int id { get; set; }
        public double jet_power_A { get; set; }
        public double? jet_power_A_off { get; set; }
        public double jet_power_B { get; set; }
        public double? jet_power_B_off { get; set; }
        public double jet_power_C { get; set; }
        public double? jet_power_C_off { get; set; }
        public double voltage_A { get; set; }
        public double? voltage_A_off { get; set; }
        public double voltage_B { get; set; }
        public double? voltage_B_off { get; set; }
        public double voltage_C { get; set; }
        public double? voltage_C_off { get; set; }
        public float? effectiveness { get; set; }
    }
}
