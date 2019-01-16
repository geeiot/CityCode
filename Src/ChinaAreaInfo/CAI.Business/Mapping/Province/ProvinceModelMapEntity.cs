using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Business.Mapping.Province
{
    internal class ProvinceModelMapEntity
    {
        public List<Enitty.Entities.Province> Map(Model.Province.Province province)
        {
            if (province == null || province.Status != "0")
            {
                return null;
            }
            return ResultMap(province.Result);
        }

        private List<Enitty.Entities.Province> ResultMap(List<Model.Province.ResultItem> provinces)
        {
            List<Enitty.Entities.Province> temp = new List<Enitty.Entities.Province>();
            if (provinces == null || provinces.Count == 0)
            {
                return temp;
            }
            //动态创建mapper
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<Model.Province.ResultItem, Enitty.Entities.Province >()
                .ForMember(dest => dest.City, opt => opt.Ignore())
            );
            var mapper = config.CreateMapper();

            foreach (var item in provinces)
            {
                temp.Add(mapper.Map<Enitty.Entities.Province>(item));
            }
            return temp;
        }
    }
}
