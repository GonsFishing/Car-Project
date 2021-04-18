using Car_Project.Domain.Models.Service;
using System;
using System.Collections.Generic;

namespace Car_Project.Domain.Models.Vehicle
{

	public class MediumVehicle : IVehicle
	{
		private string registrationNumber { get; set; }
		private string model { get; set; }
		private string brand { get; set; }
		private float weight { get; set; }
		private string vehicleType { get; set; }
		private DateTime firstTimeInTraffic { get; set; }
		private List<IVehicleRepairService> serviceHistory { get; set; } = new List<IVehicleRepairService>();

		public string RegistrationNumber => registrationNumber;
		public string Model => model;
		public string Brand => brand;
		public float Weight => weight;
		public string VehicleType => vehicleType;
		public DateTime FirstTimeInTraffic => firstTimeInTraffic;
		public IList<IVehicleRepairService> ServiceHistory => serviceHistory;

		public float YearlyCost => 1800;

		public MediumVehicle(string registrationNumber, string model, string brand, float weight, string vehicleType)
		{
			this.registrationNumber = registrationNumber;
			this.model = model;
			this.brand = brand;
			this.weight = weight;
			this.vehicleType = vehicleType;
		}

		public MediumVehicle(string registrationNumber, string model, string brand, float weight, string vehicleType, DateTime firstTimeInTraffic, List<IVehicleRepairService> serviceHistory)
		{
			this.registrationNumber = registrationNumber;
			this.model = model;
			this.brand = brand;
			this.weight = weight;
			this.vehicleType = vehicleType;
			this.firstTimeInTraffic = firstTimeInTraffic;
			this.serviceHistory = serviceHistory;
		}
	}
}