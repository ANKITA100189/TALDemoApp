using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DataLibrary.DataAccess
{
    /// <summary>
    /// This is the data access layer
    /// </summary>
    public static class SqlDataAccess
    {
        /// <summary>
        /// Method to get connection string
        /// </summary>
        /// <param name="connectionName">DemoDB</param>
        /// <returns>connection string from configuration manager</returns>
        public static string GetConnectionString(string connectionName = "DemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        /// <summary>
        /// The class will compute premium based on parameters coming from business logic layer 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>sql to calculate premium from function
        /// <param name="data"></param>parameters to be passed to function
        /// <returns></returns>
        public static double ComputePremium<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var result = cnn.ExecuteScalar(sql, data);
                return Convert.ToDouble(result);
            }
        }

        /// <summary>
        /// This class holds logic to populate occupation dropdown
        /// </summary>
        /// <param name="sql"></param>sql to fetch occupation list from database table
        /// <returns>list of occupations</returns>
        public static IEnumerable<SelectListItem> LoadOccupation(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                List<SelectListItem> occupation = cnn.Query<SelectListItem>(sql).ToList();
                // add "select occupation" text in the dropdown
                var occupationtip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select Occupation ---"
                };
                occupation.Insert(0, occupationtip);
                return new SelectList(occupation, "Value", "Text");
            }
        }
    }
}