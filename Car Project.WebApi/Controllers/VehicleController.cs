using Car_Project.Domain.Models.Service;
using Car_Project.Domain.Models.Vehicle;
using Car_Project.Repository.Interfaces;
using Car_Project.DTO;
using System.Web.Http;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Car_Project.WebApi.Controllers
{
	public class VehicleController : ApiController
	{
		private readonly IVehicleRepository vehicleRepository;
		private readonly IVehicleService vehicleService;

		public VehicleController(IVehicleRepository vehicleRepository,
								 IVehicleService vehicleService)
		{
			this.vehicleRepository = vehicleRepository;
			this.vehicleService = vehicleService;
		}

		[HttpPost]
		[Route("api/createvehicle")]
		public IHttpActionResult CreateVehicle(CreateVehicleRequestDTO request)
		{
			IVehicle vehicle = VehicleFactory.CreateVehicle(
				request.RegistrationNumber,
				request.Model,
				request.Brand,
				request.Weight
				);

			vehicleRepository.CreateVehicle(vehicle);

			return Ok();
		}

	}
}