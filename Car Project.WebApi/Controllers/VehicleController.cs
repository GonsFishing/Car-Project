using Car_Project.Domain.Models.Service;
using Car_Project.Domain.Models.Vehicle;
using Car_Project.Repository.Interfaces;
using System.Web.Http;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using Car_Project.DTO.Vehicle;
using System.Collections.Generic;
using Car_Project.DTO.Service;

namespace Car_Project.WebApi.Controllers
{
	public class VehicleController : ApiController
	{
		private readonly IVehicleRepository vehicleRepository;

		public VehicleController(IVehicleRepository vehicleRepository)
		{
			this.vehicleRepository = vehicleRepository;
		}

		[HttpGet]
		[Route("api/getvehicles")]
		public IHttpActionResult GetVehicles()
		{
			var response = new GetAllVehiclesResponseDTO();
			foreach (var Vehicle in vehicleRepository.GetAllVehicles())
			{
				var vehicleDTO = new VehicleDTO()
				{
					RegistrationNumber = Vehicle.RegistrationNumber,
					Model = Vehicle.Model,
					Brand = Vehicle.Brand,
					Weight = Vehicle.Weight,
					VehicleType = Vehicle.VehicleType,
					FirstTimeInTraffic = Vehicle.FirstTimeInTraffic,
					YearlyCost = Vehicle.YearlyCost,

				};
				if (Vehicle.ServiceHistory != null)
				{
					foreach (var service in Vehicle.ServiceHistory)
					{
						var serviceDTO = new ServiceDTO
						{
							Date = service.Date,
							Description = service.Description,
							IsCompleted = service.IsCompleted
						};

						vehicleDTO.ServiceHistory.Add(serviceDTO);
					}
				}
				response.Vehicles.Add(vehicleDTO);
			}
			return Ok(response);
		}

		[HttpPost]
		[Route("api/getvehicle")]
		public IHttpActionResult GetVehicles(string registraitionNumber)
		{
			var vehicle = vehicleRepository.GetByRegistrationNumber(registraitionNumber);

			List<ServiceDTO> serviceHistory = new List<ServiceDTO>();
			foreach (var service in vehicle.ServiceHistory)
			{
				var serviceDTO = new ServiceDTO
				{
					Date = service.Date,
					Description = service.Description,
					IsCompleted = service.IsCompleted
				};
				serviceHistory.Add(serviceDTO);
			}

			var vehicleDTO = new VehicleDTO()
			{
				RegistrationNumber = vehicle.RegistrationNumber,
				Model = vehicle.Model,
				Brand = vehicle.Brand,
				Weight = vehicle.Weight,
				VehicleType = vehicle.VehicleType,
				FirstTimeInTraffic = vehicle.FirstTimeInTraffic,
				YearlyCost = vehicle.YearlyCost,
				ServiceHistory = serviceHistory
			};

			return Ok(vehicleDTO);
		}

		[HttpPost]
		[Route("api/createvehicle")]
		public IHttpActionResult CreateVehicle(CreateVehicleRequestDTO request)
		{
			IVehicle vehicle = VehicleFactory.CreateVehicle(
				request.RegistrationNumber,
				request.Model,
				request.Brand,
				request.Weight,
				request.VehicleType);

			vehicleRepository.CreateVehicle(vehicle);
			return Ok();
		}

		[HttpPost]
		[Route("api/deletevehicle")]
		public IHttpActionResult DeleteVehicle(string RegistrationNumber)
		{
			vehicleRepository.Delete(RegistrationNumber);
			return Ok();
		}


		[HttpPost]
		[Route("api/bookService")]
		public IHttpActionResult CreateService(string registrationNumber, CreateServiceRequestDTO request)
		{
			VehicleRepairService service = new VehicleRepairService(request.Date, request.Description, request.IsCompleted);
			vehicleRepository.CreateService(registrationNumber, service);
			return Ok();
		}
	}
}