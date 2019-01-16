using CAI.Business.Helper;
using CAI.Business.Mapping.City;
using CAI.Data;
using CAI.Model.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business
{
    public class CityBusiness
    {
        public City SaveData(string cityJsonStr,out string errmsg)
        {
            errmsg = "";
            if (string.IsNullOrEmpty(cityJsonStr))
            {
                errmsg = "City json string is null.";
                return null;
            }
            City cityModel = JsonHelper.DeserializeJsonToObject<City>(cityJsonStr);
            if(cityModel.Status != "0")
            {
                errmsg = $"Request city data failed, error msg is {cityModel.Msg}.";
                return cityModel;
            }

            CityModelMapEntity map = new CityModelMapEntity();
            var entities = map.Map(cityModel);

            CityDataManage data = new CityDataManage();
            entities = data.AddRange(entities);
            if(entities != null && entities.Count > 0)
            {
                return cityModel;
            }
            else
            {
                errmsg = "Can not save city data.";
                return null;
            }
        }
    }
}
