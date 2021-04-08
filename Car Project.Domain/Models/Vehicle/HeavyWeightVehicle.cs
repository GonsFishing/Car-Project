using Car_Project.Domain.Models.Service;
using System;
using System.Collections.Generic;

namespace Car_Project.Domain.Models.Vehicle
{
	public class HeavyWeightVehicle : IVehicle
	{
		private string registrationNumber { get; set; }
		private string model { get; set; }
		private string brand { get; set; }
		private float weight { get; set; }
		private DateTime firstTimeInTraffic { get; set; }
		private IVehicleService bookedService { get; set; }
		private List<IVehicleService> serviceHistory { get; set; }
		public float YearlyCost => 1200;

		public string RegistrationNumber => registrationNumber;
		public string Model => model;
		public string Brand => brand;
		public float Weight => weight;
		public DateTime FirstTimeInTraffic => firstTimeInTraffic;
		public IVehicleService BookedService => bookedService;
		public List<IVehicleService> ServiceHistory => serviceHistory;


		public HeavyWeightVehicle(string registrationNumber, string model, string brand, float weight)
		{
			this.registrationNumber = registrationNumber;
			this.model = model;
			this.brand = brand;
			this.weight = weight;
		}

		public HeavyWeightVehicle(string registrationNumber, string model, string brand, float weight, DateTime firstTimeInTraffic, IVehicleService bookedService, List<IVehicleService> serviceHistory)
		{
			this.registrationNumber = registrationNumber;
			this.model = model;
			this.brand = brand;
			this.weight = weight;
			this.firstTimeInTraffic = firstTimeInTraffic;
			this.bookedService = bookedService;
			this.serviceHistory = ServiceHistory;
		}
	}
}