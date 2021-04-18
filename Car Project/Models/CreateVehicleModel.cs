using Car_Project.DTO.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Car_Project.Models
{
	public class CreateVehicleModel
	{
		public string RegistrationNumber { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public string VehicleType { get; set; }
		public float Weight { get; set; }
		public DateTime FirstTimeInTraffic { get; set; }
		public List<ServiceDTO> ServiceHistory { get; set; }
		public string YearlyCost { get; set; }
	}
}