using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBrain.Models
{
	public interface ISpaceXData
	{
		Task<List<SpaceXdata>> GetData(int pageSize = 100, bool? launchSuccess = true, bool? landSuccess = false, int? launchYear = 2014, bool isFilterRequest = false);
	}
}
