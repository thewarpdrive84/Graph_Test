using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Chart.Models
{
    public class Point
    {
        [Key]
        public int x { get; set; }
        public Nullable<int> y { get; set; }
    }
}
