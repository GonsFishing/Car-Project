﻿using Car_Project.Domain.Models.Service;
using Car_Project.Domain.Models.Vehicle;
using Car_Project.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Repository.Repos
{
	public class LocalSQLDatabase : IVehicleRepository
	{
		private readonly VehicleRegistrationDataContext datacontext;

		public LocalSQLDatabase()
		{
			datacontext = new VehicleRegistrationDataContext();
		}

		public List<IVehicleRepairService> GetServicehistory(string registrationNumber)
		{
			var vehicle = datacontext.Vehicles.Where(x => x.RegistrationNumber == registrationNumber).Single();
			var services = datacontext.Services.Where(x => x.Id == vehicle.ServiceHistory);

			List<IVehicleRepairService> serviceList = new List<IVehicleRepairService>();

			if (vehicle.Service != null)
			{
				foreach (var item in services)
				{
					var service = new VehicleRepairService(item.Date, item.Description, item.IsCompleted);
					serviceList.Add(service);
				}
			}

			//foreach (var item in vehicle.Services.ToList())
			//{
			//	var service = new VehicleRepairService(item.Date, item.Description, item.IsCompleted);
			//	services.Add(service);
			//}
			return serviceList;
		}

		public IEnumerable<IVehicle> GetAllVehicles()
		{
			var vehicles = new List<IVehicle>();
			foreach (var item in datacontext.Vehicles)
			{
				IVehicle vehicle = VehicleFactory.CreateVehicle(
					item.RegistrationNumber,
					item.Model,
					item.Brand,
					(float)item.Weight,
					item.VehicleType,
					item.FirstTimeInTraffic,
					GetServicehistory(item.RegistrationNumber));
				vehicles.Add(vehicle);
			}
			return vehicles;
		}

		public void CreateVehicle(IVehicle vehicle)
		{
			try
			{
				//kollar så att registreringsnumret inte redan finns i databasen 
				if (datacontext.Vehicles.Where(x => x.RegistrationNumber == vehicle.RegistrationNumber).First().RegistrationNumber == vehicle.RegistrationNumber)
				{
					throw new Exception($"An instance of the car {vehicle.RegistrationNumber} already exists in the database");
				}

				EntitySet<Service> services = new EntitySet<Service>();
				foreach (var item in vehicle.ServiceHistory)
				{
					var service = new Service
					{
						Date = item.Date,
						Description = item.Description,
						IsCompleted = item.IsCompleted
					};
					services.Add(service);
				}

				var newVehicle = new Vehicle
				{
					RegistrationNumber = vehicle.RegistrationNumber,
					Model = vehicle.Model,
					Brand = vehicle.Brand,
					Weight = vehicle.Weight,
					YearlyCost = vehicle.YearlyCost,
					FirstTimeInTraffic = DateTime.Now,
					ServiceHistory = services
				};
				datacontext.Vehicles.InsertOnSubmit(newVehicle);
				datacontext.SubmitChanges();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void Delete(string registrationNumber)
		{
			var vehicleToDelete = datacontext.Vehicles.Where(x => x.RegistrationNumber == registrationNumber).First();
			DeleteService(registrationNumber);
			datacontext.Vehicles.DeleteOnSubmit(vehicleToDelete);
			datacontext.SubmitChanges();
		}

		public void DeleteService(string registrationNumber)
		{
			var vehicle = datacontext.Vehicles.Where(x => x.RegistrationNumber == registrationNumber).First();
			var services = datacontext.Services.Where(x => x.CarID == vehicle.ID);

			datacontext.Services.DeleteOnSubmit((Service)services);
			datacontext.SubmitChanges();
		}

		public IVehicle GetByRegistrationNumber(string registrationNumber)
		{
			IVehicle vehicle = (IVehicle)datacontext.Vehicles.Where(x => x.RegistrationNumber == registrationNumber).Single();
			return vehicle;
		}

		public IVehicle Update(IVehicle vehicle)
		{
			var carToUpdate = datacontext.Vehicles.Where(x => x.RegistrationNumber == vehicle.RegistrationNumber).Single();

			//jag gillar inte denna lösningen men efter lite googling så har jag inte lyckats komma fram till en bättre lösning.
			//som fungerar utan att behöva göra om Weight och FirstTimeInTraffic till nullable värden
			var weight = vehicle.Weight;
			var dateFirstused = vehicle.FirstTimeInTraffic;

			if (vehicle.Weight != 0)
			{
				weight = vehicle.Weight;
			}

			if (vehicle.FirstTimeInTraffic != DateTime.MinValue)//the minimum value is also the default value of a DATETIME variable
			{
				dateFirstused = vehicle.FirstTimeInTraffic;
			}

			var updatedVehicle = new Vehicle
			{
				RegistrationNumber = vehicle.RegistrationNumber,
				Model = vehicle.Model ?? carToUpdate.Model,
				Brand = vehicle.Brand ?? carToUpdate.Brand,
				Weight = weight,
				YearlyCost = vehicle.YearlyCost,
				FirstTimeInTraffic = dateFirstused
			};

			datacontext.SubmitChanges();
			return (IVehicle)updatedVehicle;
		}

		public void CreateService(string registrationNumber, VehicleRepairService service)
		{
			try
			{
				var vehicle = datacontext.Vehicles.Where(x => x.RegistrationNumber == registrationNumber).Single();

				var ServiceToAdd = new Service
				{
					Date = service.Date,
					Description = service.Description,
					IsCompleted = service.IsCompleted
				};

				datacontext.Services.InsertOnSubmit(ServiceToAdd);
				datacontext.SubmitChanges();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void UpdateService(IVehicleRepairService service)
		{
			throw new NotImplementedException();
		}
	}
}
