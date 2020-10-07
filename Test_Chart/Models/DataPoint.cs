using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Test_Chart.Models
{
    [DataContract]
    public class DataPoint
    {
		public DataPoint(double y, string label)
		{
			this.Y = y;
			this.Label = label;
		}

		public DataPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}


		public DataPoint(double x, double y, string label)
		{
			this.X = x;
			this.Y = y;
			this.Label = label;
		}

		//Explicitly setting the name to be used while serializing to JSON. 
		[DataMember(Name = "label")]
		public string Label = null;

		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

		[DataMember(Name = "x")]
		public Nullable<double> X = null;
	}
}
