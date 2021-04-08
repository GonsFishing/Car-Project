using Car_Project.Domain.Models.Service;
using Car_Project.Domain.Models.Vehicle;
using Car_Project.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.Repository.Repos
{
	public class AzureSQLDataStorage : IVehicleRepository
	{
		//private readonly AzureBankDataBaseContext datacontext;

		public AzureSQLDataStorage()
		{
			//datacontext = new AzureBankDataBaseContext();
		}

		public void Delete(string registrationNumber)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IVehicle> GetAllCars()
		{
			throw new NotImplementedException();
		}

		public IVehicle GetByRegistrationNumber(string registrationNumber)
		{
			throw new NotImplementedException();
		}

		public IVehicleService GetServicehistory(string registrationNumber)
		{
			throw new NotImplementedException();
		}

		public void CreateVehicle(IVehicle vehicle)
		{
			throw new NotImplementedException();
		}

		public IVehicle Update(IVehicle vehicle)
		{
			throw new NotImplementedException();
		}

		public void UpdateService(IVehicleService service)
		{
			throw new NotImplementedException();
		}
	}
}
