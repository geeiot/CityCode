using CAI.Enitty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Data
{
    public class LogDataManage
    {
        public bool AddUpdateLog()
        {
            try
            {
                using (CAIDbContext db = new CAIDbContext())
                {
                    db.UpdateLog.Add(new Enitty.Entities.UpdateLog()
                    {
                        Describe = "完整更新",
                        Time = DateTime.Now,
                    });
                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Add update log failed,error msg:{ex.Message}");
            }
        }
    }
}
