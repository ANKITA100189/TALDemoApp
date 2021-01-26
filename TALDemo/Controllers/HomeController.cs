using System;
using System.Web.Mvc;
using TALDemo.Models;
using static DataLibrary.BusinessLogic.MemberProcessor;

namespace TALDemo.Controllers
{
    /// <summary>
    /// This method calls the method to populate Occupation dropdown and loads the view
    /// </summary>
    public class HomeController : Controller
    {
        //object created for model class
        MemberModel mod = new MemberModel();

        #region LoadView
        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.Message = "Calculate Premium";
            try
            {
                //method to load Occupation dropdown
                mod.Occupation = LoadOccupation();
            }
            catch (Exception)
            {

                ViewBag.ErrorMessage = "An error has occured. Please try again.";
            }
            
            //return view after getting value from model for desired fields
            return View(mod);
                
        }
        #endregion LoadView

        #region Calculate
        /// <summary>
                /// This method calls the method to calculate premium and handles code flow based on the returned result
                /// </summary>
                /// <param name="model"></param>
                /// <returns></returns>


        [HttpPost]
        //Added security check done on form fields
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(MemberModel model)
        {
            //additional layer of security to check model state
            if (ModelState.IsValid)
            {
                //call the method to calculate monthly premium
                try
                {
                    var result = CallPremiumCalculation(model.MemberId, model.DeathSumInsured, model.Age, model.SelectedOccupationCode);
                    if (result == -1)
                    {
                        //Show message if member details not matched with db table
                        ViewBag.ErrorMessage = "This member does not exist. Please enter valid details.";
                    }
                    else
                    {
                        //if valid result, bind it to premium property of the model
                        mod.Premium = result;
                    }
                }
                catch (Exception)
                {

                    ViewBag.ErrorMessage = "An error has occured. Please try again.";
                }
               
            }
            mod.Occupation = LoadOccupation();
            return View(mod);
        }
        #endregion Calculate

        #region CalculatePremium
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberId"></param> Member Id of the member
        /// <param name="deathSumInsured"></param> Death sum insured value of the member
        /// <param name="age"></param> Age of the member
        /// <param name="selectedOccupationCode"></param> Selected Occupation of the member
        /// <returns></returns>
        public double CallPremiumCalculation(string memberId, double deathSumInsured, int age, string selectedOccupationCode)
        {
            double result = 0;
            //call ComputePremium method of business logic layer
            result = ComputePremium(memberId, deathSumInsured, age, selectedOccupationCode);
            //return the calculated premium
            return result;
        }
        #endregion CalculatePremium
    }
}