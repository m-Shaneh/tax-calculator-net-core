using congestion.calculator.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace congestion.calculator.Entities
{
    public class City: BaseEntity
    {
       
        public string CityName { get; set; }

        /// <summary>
        /// The maximum amount per day and vehicle
        /// </summary>
        public int MaxFee { get; set; }

        /// <summary>
        /// The single charge rule
        /// </summary>
        public int? TimeSingleChargeRule {  get; set; }

        /// <summary>
        ///  limit the scope to the year
        /// </summary>
        public int? LimitedYear { get; set; }

        /// <summary>
        /// Tax Exempt vehicles
        /// </summary>
        public List<TollFreeVehicle> TollFreeVehicles { get; set; }
        /// <summary>
        /// Hours and amounts for congestion tax 
        /// </summary>
        public List<TollTimeFee> TollTimeFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TollFreeDate> TollFreeDates{ get; set; }






    }
}
