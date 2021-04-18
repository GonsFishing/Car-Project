using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.DTO.Vehicle
{
    public class CreateVehicleRequestDTO
    {
		public string RegistrationNumber { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public float Weight { get; set; }
		public string VehicleType { get; set; }
		public DateTime FirstTimeInTraffic { get; set; }
		public string YearlyCost { get; set; }
		public List<ServiceDTO> ServiceHistory { get; set; } = new List<ServiceDTO>();
	}

	public class ServiceDTO
	{
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
	}
}
