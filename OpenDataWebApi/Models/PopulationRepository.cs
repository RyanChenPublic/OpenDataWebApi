using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenDataWebApi.Models
{
    public class PopulationRepository
    {
        static readonly HttpClient httpClient = new();
        static readonly string openDataApiUrl = "https://data.moi.gov.tw/MoiOD/System/DownloadFile.aspx?DATA=B7BBE544-EBFB-41F7-93FD-6996FD24767E";
        /// <summary>
        /// 取得OPENDATA API資料
        /// </summary>
        /// <returns></returns>
        public async Task<Response_Data<PopulationParameter>> GetPopulationDataFromOpenDataApi()
        {
            var response =await httpClient.GetAsync(openDataApiUrl);
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<Response_Data<PopulationParameter>>(responseStream);

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public int Create(SqlConnection connection,PopulationParameter parameter)
        {
           
            var sql =
            @"
        INSERT INTO Population 
        (
            [site_id]
           ,[people_total]
           ,[area]
           ,[population_density]
           ,[statistic_yyy]
        ) 
        VALUES 
        (
            @site_id
           ,@people_total
           ,@area
           ,@population_density
           ,@statistic_yyy
        );
    ";

                var result = connection.Execute(sql, parameter);
                return result;
            
        }
    }
}
