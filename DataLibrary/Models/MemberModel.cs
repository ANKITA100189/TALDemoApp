using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLibrary.Models
{
    /// <summary>
    /// This is database model
    /// </summary>
    public class MemberModel
    {
        /// <summary>
        /// Property to map Member Id field
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// Property to map death sum insured field
        /// </summary>
        public double DeathSumInsured { get; set; }

        /// <summary>
        /// Property to map age field
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Property to map selected occupation field
        /// </summary>
        public string SelectedOccupationCode { get; set; }

        /// <summary>
        /// Property to fetch list of ocupation 
        /// </summary>
        public IEnumerable<SelectListItem> Occupation { get; set; }
    }
}