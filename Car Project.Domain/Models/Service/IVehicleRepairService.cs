using Car_Project.Domain.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Domain.Models.Service
{
	public interface IVehicleRepairService
	{
		DateTime Date { get; }
		string Description { get; }
		bool IsCompleted { get; }
		float GetYearlyTaxCost(IVehicle vehicle);
	}
}
