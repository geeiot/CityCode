using CAI.Business.Helper;
using CAI.Business.Mapping.Province;
using CAI.Data;
using CAI.Model.Province;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business
{
    public class ProvinceBusiness
    {
        public Province SaveData(string JsonStr, out string errmsg)
        {
            errmsg = string.Empty;
            if (string.IsNullOrEmpty(JsonStr))
            {
                errmsg = "Province json string is null.";
                return null;
            }
            Province model = JsonHelper.DeserializeJsonToObject<Province>(JsonStr);
            if (model.Status != "0")
            {
                errmsg = $"Request province data failed, error msg is {model.Msg}.";
                return model;
            }

            ProvinceModelMapEntity map = new ProvinceModelMapEntity();
            var entities = map.Map(model);

            ProvinceDataManage data = new ProvinceDataManage();
            entities = data.AddRange(entities);
            if (entities != null && entities.Count > 0)
            {
                errmsg = string.Empty;
                return model;
            }
            else
            {
                errmsg = "Can not save province data.";
                return null;
            }
        }
    }
}
