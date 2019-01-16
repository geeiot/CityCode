using CAI.Business.Helper;
using CAI.Business.Mapping.Town;
using CAI.Data;
using CAI.Model.Town;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business
{
    public class TownBusiness
    {
        public Town SaveData(string JsonStr, out string errmsg)
        {
            errmsg = string.Empty;
            if (string.IsNullOrEmpty(JsonStr))
            {
                errmsg = "Town json string is null.";
                return null;
            }
            Town model = JsonHelper.DeserializeJsonToObject<Town>(JsonStr);
            if (model.Status != "0")
            {
                errmsg = $"Request town data failed, error msg is {model.Msg}.";
                return model;
            }

            TownModelMapEntity map = new TownModelMapEntity();
            var entities = map.Map(model);

            TownDataManage data = new TownDataManage();
            entities = data.AddRange(entities);
            if (entities != null && entities.Count > 0)
            {
                errmsg = string.Empty;
                return model;
            }
            else
            {
                errmsg = "Can not save town data.";
                return null;
            }
        }
    }
}
