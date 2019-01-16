using System;
using System.Collections.Generic;
using System.Text;

namespace CAI.Config
{
    public static class Configs
    {
        public static string ApiUrl
        {
            get
            {
                return "http://api.jisuapi.com/area";
            }
        }

        /// <summary>
        /// 获取全国省份
        /// </summary>
        public static string ApiProvinceUrl
        {
            get
            {
                return @"http://api.jisuapi.com/area/province?appkey=" + AppKey;
            }
        }

        /// <summary>
        /// 获取全国市区
        /// </summary>
        public static string ApiCityUrl
        {
            get
            {
                return @"http://api.jisuapi.com/area/city?parentid={0}&appkey=" + AppKey;
            }
        }

        /// <summary>
        /// 获取全国市区区县
        /// </summary>
        public static string ApiTownUrl
        {
            get
            {
                return @"http://api.jisuapi.com/area/town?parentid={0}&appkey=" + AppKey;
            }
        }

        public static string AppKey
        {
            get
            {
                return "填写自己的AppKey";
            }
        }

        /// <summary>
        /// 默认数据库连接字符串
        /// </summary>
        public static string DefaultDbConnectStrName
        {
            get
            {
                return "name=DefaultConnectString";
            }
        }
    }
}
