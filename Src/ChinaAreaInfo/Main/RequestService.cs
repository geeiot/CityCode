using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CAI.Business;
using CAI.Config;
using CAI.Model.City;
using CAI.Model.Province;
using CAI.Model.Town;
using Main.Helper;

namespace Main
{
    class RequestService
    {
        public void Start()
        {
            //更新
            UpdateTownData(UpdateCityData(UpdateProvinceData()));
            //记录日志
            AddUpdateLog();
            //
            Console.WriteLine("成功完成本次更新！");
        }

        public Province UpdateProvinceData()
        {
            string errmsg = "";
            try
            {
                HttpHelper httpHelper = new HttpHelper();
                string result = httpHelper.HttpResponsePostString(Configs.ApiProvinceUrl);
                if (string.IsNullOrEmpty(result))
                {
                    return null;
                }
                ProvinceBusiness business = new ProvinceBusiness();
                Province province = business.SaveData(result, out errmsg);
                if (province != null && string.IsNullOrEmpty(errmsg))
                {
                    Console.WriteLine($"获取并保存省份数据成功，共计{province.Result.Count}条记录。");
                    return province;
                }
                else
                {
                    Console.WriteLine("保存数据失败！错误：" + errmsg);
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<City> UpdateCityData(Province province)
        {
            string errmsg = "";
            List<City> cityList = new List<City>();
            if (province == null || province.Status != "0")
            {
                return null;
            }
            try
            {
                HttpHelper httpHelper = new HttpHelper();
                foreach (var item in province.Result)
                {
                    string requestUrl = string.Format(Configs.ApiCityUrl, item.Id);
                    string result = httpHelper.HttpResponsePostString(requestUrl);
                    if (string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine($"请求{item.Name}（ID：{item.Id}）下的城市失败！");
                        continue;
                    }
                    CityBusiness cityBusiness = new CityBusiness();
                    City city = cityBusiness.SaveData(result, out errmsg);
                    if (city != null && string.IsNullOrEmpty(errmsg))
                    {
                        Console.WriteLine($"保存{item.Name}城市数据成功，共计{city.Result.Count}条记录。");
                        cityList.Add(city);
                    }
                    else
                    {
                        if (city != null)
                        {
                            switch (city.Status)
                            {
                                case "203":
                                    Console.WriteLine($"{item.Name}下没有数据.");
                                    break;
                                default:
                                    Console.WriteLine($"获取{item.Name}数据失败，错误代码：{city.Status}，错误信息：{city.Msg}");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"保存{item.Name}城市数据失败！错误：" + errmsg);
                        }
                        continue;
                    }
                }
                return cityList;
            }
            catch (Exception ex)
            {
                throw new Exception($"更新城市数据出错，错误：{ex.Message}");
            }
        }

        public List<Town> UpdateTownData(List<City> cities)
        {
            string errmsg = "";
            List<Town> towns = new List<Town>();
            if (cities == null || cities.Count == 0)
            {
                return null;
            }
            try
            {
                HttpHelper httpHelper = new HttpHelper();
                foreach (var city in cities)
                {
                    foreach (var item in city.Result)
                    {
                        string requestUrl = string.Format(Configs.ApiTownUrl, item.Id);
                        string result = httpHelper.HttpResponsePostString(requestUrl);
                        if (string.IsNullOrEmpty(result))
                        {
                            Console.WriteLine($"请求{item.Name}（ID：{item.Id}）下的区县失败！");
                            continue;
                        }
                        TownBusiness townBusiness = new TownBusiness();
                        Town town = townBusiness.SaveData(result, out errmsg);
                        if (town != null && string.IsNullOrEmpty(errmsg))
                        {
                            Console.WriteLine($"保存{item.Name}区县数据成功，共计{town.Result.Count}条记录。");
                            towns.Add(town);
                        }
                        else
                        {
                            if (town != null)
                            {
                                switch (town.Status)
                                {
                                    case "203":
                                        Console.WriteLine($"{item.Name}下没有数据.");
                                        break;
                                    default:
                                        Console.WriteLine($"获取{item.Name}数据失败，错误代码：{town.Status}，错误信息：{town.Msg}");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"保存{item.Name}城市数据失败！错误：" + errmsg);
                            }
                            continue;
                        }
                    }
                }
                return towns;
            }
            catch (Exception ex)
            {
                throw new Exception($"更新区县数据出错，错误：{ex.Message}");
            }
        }

        public bool AddUpdateLog()
        {
            try
            {
                UpdateLogBussnies updateLogBussnies = new UpdateLogBussnies();
                if (updateLogBussnies.AddUpdateLog())
                {
                    Console.WriteLine("保存日志成功！");
                    return true;
                }
                else
                {
                    Console.WriteLine("保存日志失败！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
