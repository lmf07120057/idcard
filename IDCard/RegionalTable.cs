using IDCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDCard
{

    /// <summary>
    /// 区域表
    /// </summary>
    public class RegionalTable
    {
        private static RegionalTable table = new RegionalTable();

        /// <summary>
        /// 私有的构造函数
        /// </summary>
        private RegionalTable()
        { 
        }

        /// <summary>
        /// 获取区域表单例
        /// </summary>
        /// <returns></returns>
        public static RegionalTable GetInstance()
        {
            return table;
        }

        /// <summary>
        /// 通过区域代码获取区域名称
        /// </summary>
        /// <param name="regionid">区域代码</param>
        /// <returns></returns>
        public string GetRegion(int regionid)
        {
            var ret = RegionalData.Region.FirstOrDefault(w=>w.Value.Contains(regionid));
            return ret.Key;
        }

        /// <summary>
        /// 通过省份代码获取省份名称
        /// </summary>
        /// <param name="provinceid">省份代码</param>
        /// <returns></returns>
        public string GetProvince(int provinceid)
        {
            var val = "";
            RegionalData.Province.TryGetValue(provinceid, out val);
            return val;
        }

        /// <summary>
        /// 通过市区县区域代码获取对应的地址
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public string GetCity(int cityid)
        {
            var val = "";
            RegionalData.City.TryGetValue(cityid, out val);
            return val;
        }

    }

    
}
