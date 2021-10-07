using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDataWebApi.Models
{
    public class Response_Data<T>
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string totalPage { get; set; }
        public string totlaDataSize { get; set; }
        public string page { get; set; }
        public string pageDataSize { get; set; }
        public T[] responseData { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class PopulationParameter
    {
        /// <summary>
        /// 統計年
        /// </summary>
        public string statistic_yyy { get; set; }
        /// <summary>
        /// 區域別
        /// </summary>
        public string site_id { get; set; }
        /// <summary>
        /// 年底人口數
        /// </summary>
        public string people_total { get; set; }
        /// <summary>
        /// 土地面積
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 人口密度
        /// </summary>
        public string population_density { get; set; }
    }
}
