using CAI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business
{
    public class UpdateLogBussnies
    {
        public bool AddUpdateLog()
        {
            LogDataManage data = new LogDataManage();
            return data.AddUpdateLog();
        }
    }
}
