using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBrain.Models
{
	public class SpaceXDataManager : ISpaceXData
	{
		public async Task<List<SpaceXdata>> GetData(int pageSize = 100, bool? launchSuccess = true, bool? landSuccess = false, int? launchYear = 2014, bool isFilterRequest = false)
		{
			List<SpaceXdata> spaceXData = null;
			HttpClientHelper<int, List<SpaceXdata>> httpClientHelper = new HttpClientHelper<int, List<SpaceXdata>>();

			string url = "launches?limit="+pageSize;

			if (isFilterRequest)
			{
				if (launchSuccess.HasValue)
				{
					url = url + "&launch_success=" + launchSuccess;
				}

				if (landSuccess.HasValue)
				{
					url = url + "&land_success=" + landSuccess;
				}

				if (launchYear.HasValue)
				{
					url = url + "&launch_year=" + launchYear;
				}

			}

			if (!string.IsNullOrEmpty(url))
			{
				spaceXData = await httpClientHelper.CallApi(url, -1, "GET");
			}


			return spaceXData;
		}
	}
}
