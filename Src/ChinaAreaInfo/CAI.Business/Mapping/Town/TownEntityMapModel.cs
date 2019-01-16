using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business.Mapping.Town
{
    class TownEntityMapModel
    {
        public Model.Town.Town Map(List<Enitty.Entities.Town> towns)
        {
            if (towns == null || towns.Count == 0)
            {
                return null;
            }
            Model.Town.Town city = new Model.Town.Town()
            {
                Status = "0",
                Msg = "",
                Result = ResultMap(towns),
            };
            return city;
        }

        private List<Model.Town.ResultItem> ResultMap(List<Enitty.Entities.Town> towns)
        {
            List<Model.Town.ResultItem> temp = new List<Model.Town.ResultItem>();
            if (towns == null || towns.Count == 0)
            {
                return temp;
            }
            //动态创建mapper
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<Enitty.Entities.Town, Model.Town.ResultItem > ());
            var mapper = config.CreateMapper();

            foreach (var item in towns)
            {
                temp.Add(mapper.Map<Model.Town.ResultItem>(item));
            }
            return temp;
        }
    }
}
