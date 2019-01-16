using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business.Mapping.Province
{
    class ProvinceEntityMapModel
    {
        public Model.Province.Province Map(List<Enitty.Entities.Province> provinces)
        {
            if (provinces == null || provinces.Count == 0)
            {
                return null;
            }
            Model.Province.Province city = new Model.Province.Province()
            {
                Status = "0",
                Msg = "",
                Result = ResultMap(provinces),
            };
            return city;
        }

        private List<Model.Province.ResultItem> ResultMap(List<Enitty.Entities.Province> provinces)
        {
            List<Model.Province.ResultItem> temp = new List<Model.Province.ResultItem>();
            if (provinces == null || provinces.Count == 0)
            {
                return temp;
            }
            //动态创建mapper
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<Enitty.Entities.Province, Model.Province.ResultItem>());
            var mapper = config.CreateMapper();

            foreach (var item in provinces)
            {
                temp.Add(mapper.Map<Model.Province.ResultItem>(item));
            }
            return temp;
        }
    }
}
