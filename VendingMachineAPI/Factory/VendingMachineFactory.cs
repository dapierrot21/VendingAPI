using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineAPI.Interface;
using VendingMachineAPI.Repos;

namespace VendingMachineAPI.Factory
{
	public class VendingMachineFactory
	{
		public static IVendingMachineRepository GetRepository()
		{
			switch (Settings.GetRepositoryType())
			{
				case "ADO":
					return new VendingMachineRepositoryADO();
				case "Sample Data":
					return new VendingMachineRepositoryMock();
				default:
					throw new Exception("Couldn't find the configuration type.");
			}

		}
	}
}

