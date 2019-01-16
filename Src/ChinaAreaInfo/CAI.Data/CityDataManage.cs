using CAI.Enitty;
using CAI.Enitty.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Data
{
    public class CityDataManage
    {
        public List<City> AddRange(List<City> cities)
        {
            List<City> temp = new List<City>();
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
                        temp = db.City.AddRange(cities).ToList();
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
