using Car_Project.Domain.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Domain.Models.Service
{
	public interface IVehicleService
	{
		DateTime Date { get; }
		string Description { get; }
		float GetYearlyTaxCost(IVehicle vehicle);
	}
}
