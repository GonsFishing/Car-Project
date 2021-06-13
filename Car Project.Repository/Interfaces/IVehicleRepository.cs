using Car_Project.Domain.Models.Service;
using Car_Project.Domain.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Repository.Interfaces
{
	public interface IVehicleRepository
	{
		IEnumerable<IVehicle> GetAllVehicles();
		IVehicle GetByRegistrationNumber(string registrationNumber);
		void CreateVehicle(IVehicle vehicle);
		IVehicle Update(IVehicle vehicle);
		void Delete(string registrationNumber);
		void CreateService(string registrationNumber, VehicleRepairService service);
		void UpdateService(IVehicleRepairService service);
		void DeleteService(string registrationNumber);
		List<IVehicleRepairService> GetServicehistory(string registrationNumber);
	}
}
