using Car_Project.Domain.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Domain.Models.Vehicle
{
	public class VehicleFactory
	{
		public static IVehicle CreateVehicle(
			string registrationNumber,
			string model,
			string brand,
			float weight)
		{
			switch (weight)
			{
				case float w when w >= 2500:
					return new HeavyWeightVehicle(registrationNumber, model, brand, weight);
				case float w when w >= 1800:
					return new MediumVehicle(registrationNumber, model, brand, weight);
				default:
					return new LightWeightVehicle(registrationNumber, model, brand, weight);
			}
		}

		public static IVehicle CreateVehicle(
			string registrationNumber,
			string model,
			string brand,
			float weight,
			DateTime firstTimeInTraffic,
			IVehicleService bookedService,
			List<IVehicleService> serviceHistory)
		{
			switch (weight)
			{
				case float w when w >= 2500:
					return new HeavyWeightVehicle(registrationNumber, model, brand, weight, firstTimeInTraffic, bookedService, serviceHistory);
				case float w when w >= 1800:
					return new MediumVehicle(registrationNumber, model, brand, weight, firstTimeInTraffic, bookedService, serviceHistory);
				default:
					return new LightWeightVehicle(registrationNumber, model, brand, weight, firstTimeInTraffic, bookedService, serviceHistory);
			}
		}
	}
}
