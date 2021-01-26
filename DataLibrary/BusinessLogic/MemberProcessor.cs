using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Web.Mvc;

namespace DataLibrary.BusinessLogic
{
    /// <summary>
    /// This class holds all the business logic
    /// </summary>
    public static class MemberProcessor
    {
        /// <summary>
        /// The class will compute premium based on parameters coming from controller 
        /// </summary>
        /// <param name="memberId"></param> Member Id of the member
        /// <param name="deathSumInsured"></param>Death sum insured value of the member
        /// <param name="age"></param>Age of the member
        /// <param name="selectedOccupation"></param> Selected Occupation of the member
        /// <returns>sql to calculate premium from function and parameters</returns>
        public static double ComputePremium(string memberId, double deathSumInsured, int age, string selectedOccupation)
        {
            MemberModel data = new MemberModel
            {
                MemberId = memberId,
                DeathSumInsured = deathSumInsured,
                Age = age,
                SelectedOccupationCode = selectedOccupation
            };

            //Query to call function by passing input entered by member
            string sql = @"select dbo.CalculatePremium(@MemberId,@DeathSumInsured,@Age,@SelectedOccupationCode)";

            return SqlDataAccess.ComputePremium(sql, data);
        }

        /// <summary>
        /// This class holds logic to populate occupation dropdown
        /// </summary>
        /// <returns>sql to fetch occupation list from database table</returns>
        public static IEnumerable<SelectListItem> LoadOccupation()
        {
            //query to load occupation
            string sql = @"select OccupationName as Text, OccupationName as Value from Occupation";

            return SqlDataAccess.LoadOccupation(sql);
        }
    }
}