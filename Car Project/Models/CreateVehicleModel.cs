using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Project.Models
{
	public class CreateVehicleModel
	{
		public string RegistrationNumber { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public string VehicleType { get; set; }
		public float Weight { get; set; }
		public DateTime FirstUse { get; set; }
		public bool VehicleISInUse { get; set; }
		public bool ServiceISBooked { get; set; }
		public List<Service> List { get; set; }
		public string YearlyCost { get; set; }
	}
}