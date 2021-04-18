using Car_Project.Domain.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Domain.Models.Service
{
	public class VehicleRepairService : IVehicleRepairService
	{
		private DateTime date { get; set; }
		private string description { get; set; }
		private bool isCompleted { get; set; }

		public DateTime Date => date;
		public string Description => description;
		public bool IsCompleted => isCompleted;

		public float GetYearlyTaxCost(IVehicle vehicle)
		{
			if (vehicle.Weight > 2500)
			{
				return 4500;
			}
			else if (vehicle.Weight > 1800)
			{
				return 1800;
			}
			else
			{
				return 1200;
			}
		}
		public VehicleRepairService(DateTime date, string description, bool isCompleted)
		{
			this.date = date;
			this.description = description;
			this.isCompleted = isCompleted;
		}	
	}
}
