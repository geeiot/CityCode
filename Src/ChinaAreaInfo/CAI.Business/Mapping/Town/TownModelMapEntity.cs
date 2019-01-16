using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business.Mapping.Town
{
    class TownModelMapEntity
    {
        public List<Enitty.Entities.Town> Map(Model.Town.Town town)
        {
            if (town == null || town.Status != "0")
            {
                return null;
            }
            return ResultMap(town.Result);
        }

        private List<Enitty.Entities.Town> ResultMap(List<Model.Town.ResultItem> towns)
        {
            List<Enitty.Entities.Town> temp = new List<Enitty.Entities.Town>();
            if (towns == null || towns.Count == 0)
            {
                return temp;
            }
            //动态创建mapper
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<Model.Town.ResultItem, Enitty.Entities.Town>()
                .ForMember(dest => dest.City, opt => opt.Ignore())
            );
            var mapper = config.CreateMapper();

            foreach (var item in towns)
            {
                temp.Add(mapper.Map<Enitty.Entities.Town>(item));
            }
            return temp;
        }
    }
}
