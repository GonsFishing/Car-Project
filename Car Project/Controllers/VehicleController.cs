using Car_Project.DTO.Vehicle;
using Car_Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Car_Project.Controllers
{
	public class VehicleController : Controller
	{
		private readonly string createVehicle = "https://localhost:44321/api/createvehicle";
		private readonly string removeVehicle = "https://localhost:44321/api/deletevehicle";
		private readonly string updateVehicle = "https://localhost:44321/api/updatevehicle";

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult CreateVehicleView()
		{
			return View("CreateVehicle");
		}

		//POST: /api/createvehicle
		[HttpPost]
		public ActionResult CreateVehicle(CreateVehicleModel CreateVehicleModel)
		{
			var createVehicleRequest = new CreateVehicleRequestDTO
			{
				RegistrationNumber = CreateVehicleModel.RegistrationNumber,
				Brand = CreateVehicleModel.Brand,
				Model = CreateVehicleModel.Model,
				VehicleType = CreateVehicleModel.VehicleType,
				Weight = CreateVehicleModel.Weight,
				FirstTimeInTraffic = CreateVehicleModel.FirstTimeInTraffic,
				ServiceHistory = CreateVehicleModel.ServiceHistory,
				YearlyCost = CreateVehicleModel.YearlyCost
			};

			string jsonCreateVehicle = JsonConvert.SerializeObject(createVehicleRequest);
			var httpContent = new StringContent(jsonCreateVehicle, Encoding.UTF8, "application/json");


			using (HttpClient client = new HttpClient())
			{
				var response = client.PostAsync(new Uri(createVehicle), httpContent).Result;
			}

			return View("Index");
		}

		public ActionResult DeleteVehicleView()
		{
			return View("DeleteVehicleView");
		}

		[HttpPost]
		public ActionResult Delete(DeleteVehicleRequestModel model)
		{
			var carToDelete = new VehicleDTO
			{
				RegistrationNumber = model.RegistrationNumber
			};

			string jsonCreateVehicle = JsonConvert.SerializeObject(carToDelete);
			var httpContent = new StringContent(jsonCreateVehicle, Encoding.UTF8, "application/json");
			using (HttpClient client = new HttpClient())
			{
				var response = client.PostAsync(new Uri(removeVehicle), httpContent).Result;
			}

			return View("Index");
		}

		public ActionResult UpdateVehicleView()
		{
			return View("UpdateVehicle");
		}
	}
}