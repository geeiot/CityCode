using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business.Mapping.City
{
    public class CityModelMapEntity
    {
        public List<Enitty.Entities.City> Map(Model.City.City city)
        {
            if (city == null || city.Status != "0")
            {
                return null;
            }
            return ResultMap(city.Result);
        }

        private List<Enitty.Entities.City> ResultMap(List<Model.City.ResultItem> cities)
        {
            List<Enitty.Entities.City> temp = new List<Enitty.Entities.City>();
            if (cities == null || cities.Count == 0)
            {
                return temp;
            }
            //动态创建mapper
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<Model.City.ResultItem, Enitty.Entities.City>()
                .ForMember(dest => dest.Province, opt => opt.Ignore())
                .ForMember(dest => dest.Town, opt => opt.Ignore())
            );
            var mapper = config.CreateMapper();

            foreach (var item in cities)
            {
                temp.Add(mapper.Map<Enitty.Entities.City>(item));
            }
            return temp;
        }
    }
}
