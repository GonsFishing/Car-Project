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
			float weight,
			string vehicleType)
		{
			switch (weight)
			{
				case float w when w >= 2500:
					return new HeavyWeightVehicle(registrationNumber, model, brand, weight, vehicleType);
				case float w when w >= 1800:
					return new MediumVehicle(registrationNumber, model, brand, weight, vehicleType);
				default:
					return new LightWeightVehicle(registrationNumber, model, brand, weight, vehicleType);
			}
		}

		public static IVehicle CreateVehicle(
			string registrationNumber,
			string model,
			string brand,
			float weight,
			string vehicleType,
			DateTime firstTimeInTraffic,
			List<IVehicleRepairService> serviceHistory)
		{
			switch (weight)
			{
				case float w when w <= 1800:
					return new HeavyWeightVehicle(registrationNumber, model, brand, weight, vehicleType, firstTimeInTraffic, serviceHistory);
				case float w when w <= 1200:
					return new MediumVehicle(registrationNumber, model, brand, weight, vehicleType, firstTimeInTraffic, serviceHistory);
				default:
					return new LightWeightVehicle(registrationNumber, model, brand, weight, vehicleType, firstTimeInTraffic, serviceHistory);
				
			}
		}
	}
}
