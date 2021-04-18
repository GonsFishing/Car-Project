using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.DTO.Vehicle
{
	public class VehicleDTO
	{
		public string RegistrationNumber { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public string VehicleType { get; set; }
		public float Weight { get; set; }
		public DateTime FirstTimeInTraffic { get; set; }
		public float YearlyCost { get; set; }
		public List<ServiceDTO> ServiceHistory { get; set; } = new List<ServiceDTO>();
	}

	public class GetAllVehiclesResponseDTO
	{
		public IList<VehicleDTO> Vehicles { get; set; } = new List<VehicleDTO>();
	}
}
