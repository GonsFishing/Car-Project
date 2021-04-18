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
	public class HomeController : Controller
	{
		private readonly string createVehicle = "https://localhost:44321/api/createvehicle";
		public ActionResult CreateVehicleView()
		{
			return View("CreateVehicle");
		}

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

		public ActionResult Index()
		{
			ViewBag.Message = "Your application description page.";
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}
	}
}