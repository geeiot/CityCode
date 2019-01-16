using CAI.Enitty;
using CAI.Enitty.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Data
{
    public class ProvinceDataManage
    {
        public List<Province> AddRange(List<Province> cities)
        {
            List<Province> temp = new List<Province>();
            if (cities == null || cities.Count == 0)
            {
                return temp;
            }
            try
            {
                using (CAIDbContext db = new CAIDbContext())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        temp = db.Province.AddRange(cities).ToList();
                        int changeCount = db.SaveChanges();
                        if (temp.Count == changeCount)
                        {
                            trans.Commit();
                            return temp;
                        }
                        else
                        {
                            trans.Rollback();
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
