using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business.Mapping.City
{
    public class CityEntityMapModel
    {
        public Model.City.City Map(List<Enitty.Entities.City> cities)
        {
            if (cities == null || cities.Count == 0)
            {
                return null;
            }
            Model.City.City city = new Model.City.City()
            {
                Status = "0",
                Msg = "",
                Result = ResultMap(cities),
            };
            return city;
        }

        private List<Model.City.ResultItem> ResultMap(List<Enitty.Entities.City> cities)
        {
            List<Model.City.ResultItem> temp = new List<Model.City.ResultItem>();
            if (cities == null || cities.Count == 0)
            {
                return temp;
            }
            //动态创建mapper
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<Enitty.Entities.City, Model.City.ResultItem > ());

            var mapper = config.CreateMapper();

            foreach (var item in cities)
            {
                temp.Add(mapper.Map<Model.City.ResultItem>(item));
            }
            return temp;
        }
    }
}
