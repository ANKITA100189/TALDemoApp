using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TALDemo.Models
{
    /// <summary>
    /// This class is created to validate form fields. This is view model
    /// </summary>
    public class MemberModel
    {
        /// <summary>
        /// Property to validate Member Id field
        /// </summary>
        // Required check to validate if user has entered the value or not.
        [Required(ErrorMessage = "Please enter your Member ID.")]
        // Check to validate max length
        [MaxLength(10, ErrorMessage = "Member ID cannot be more than 10 characters.")]
        public string MemberId { get; set; }

        /// <summary>
        /// Property to validate Name field
        /// </summary>
        // Required check to validate if user has entered the value or not.
        [Required(ErrorMessage = "Please enter your name.")]
        // Check to validate max length
        [MaxLength(200, ErrorMessage = "Name cannot be more than 200 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Property to validate Age field
        /// </summary>
        // Required check to validate if user has entered the value or not.
        [Required(ErrorMessage = "Please enter your age.")]
        // Check to validate values in aparticular range
        [Range(1, 150, ErrorMessage = "Please enter a value between 1 to 150.")]
        [DisplayFormat(DataFormatString = "{0:#}", ApplyFormatInEditMode = true)]
        public int Age { get; set; }

        /// <summary>
        /// Property to validate Date of Birth field
        /// </summary>
        // Required check to validate if user has selected the value or not.
        [Required(ErrorMessage = "Please enter your date of birth.")]
        // Display name of the field on form
        [Display(Name = "Date of Birth")]
        // To set default value as empty
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dob { get; set; }

        /// <summary>
        /// Property to validate Death Sum Insured field
        /// </summary>
        // Required check to validate if user has entered the value or not.
        [Required(ErrorMessage = "Please enter the death sum insured.")]
        // Display name of the field on form
        [Display(Name = "Death-Sum Insured")]
        // To set default value as empty
        [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
        public double DeathSumInsured { get; set; }

        /// <summary>
        /// Property to validate Occupation field
        /// </summary>
        // Required check to validate if user has entered the value or not.
        [Required(ErrorMessage = "Please select your occupation from the list.")]
        // Display name of the field on form
        [Display(Name = "Occupation")]
        public string SelectedOccupationCode { get; set; }

        /// <summary>
        /// Property to fetch list of occupations
        /// </summary>
        public IEnumerable<SelectListItem> Occupation { get; set; }

        /// <summary>
        /// Property to validate Premium field
        /// </summary>
        // Display name of the field on form
        [Display(Name = "Monthly Premium")]
        // To set default value as empty
        [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
        public double Premium { get; set; }
    }
}