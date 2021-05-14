using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;
using AcceptVerbsAttribute = System.Web.Http.AcceptVerbsAttribute;
using VendingMachineAPI.Factory;

namespace VendingMachineAPI.Controllers
{
	[EnableCors]
	public class VendingAPIController : ApiController
    {
		[Route("items/")]
		[AcceptVerbs("GET")]
		public IHttpActionResult SelectAll()
		{
			var repo = VendingMachineFactory.GetRepository();

			return Ok(repo.GetAllItems());
		}
	}
}
