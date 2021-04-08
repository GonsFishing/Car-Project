using Car_Project.Domain.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Domain.Models.Service
{
	public class VehicleService : IVehicleService
	{
		public DateTime Date => throw new NotImplementedException();

		public string Description => throw new NotImplementedException();

		public float GetYearlyTaxCost(IVehicle vehicle)
		{
			throw new NotImplementedException();
		}
	}
}
