using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using VendingMachineAPI.Factory;
using VendingMachineAPI.Models;
using VendingMachineAPI.Repos;


namespace VendingMachineAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VendingMachineController : ApiController
    {
        [Route("items/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllItems()
        {
            var repo = VendingMachineFactory.GetRepository();
            var items = repo.GetAllItems();
            return Ok(items);
        }

		[Route("money/{amount}/item/{id}")]
		[AcceptVerbs("POST")]
		public IHttpActionResult GetbyId(string amount, int id)
		{
			var repo = VendingMachineFactory.GetRepository();

			Item item = repo.GetItemById(id);

			decimal money = decimal.Parse(amount);

			ReturnedChange change = new ReturnedChange();

			if (money >= item.price)
            {
				money = money - item.price;

				change.Quarters = (int)(money / .25M);
				money %= .25M;
				change.Dimes = (int)(money / .10M);
				money %= .10M;
				change.Nickels = (int)(money / .05M);
				money %= .05M;
				change.Pennies = (int)(money / 0.01M);

				repo.Update(item);

				
			}
			else if (money < item.price)
            {
				return new HttpError("Please enter more money.", Request);
			}


			return Ok(change);


		}

	
	}
}