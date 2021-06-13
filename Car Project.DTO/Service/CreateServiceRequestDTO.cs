using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project.DTO.Service
{
	public class CreateServiceRequestDTO
	{
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
	}
}
