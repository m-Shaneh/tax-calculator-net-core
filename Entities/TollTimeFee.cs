using congestion.calculator.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace congestion.calculator.Entities
{
    /// <summary>
    /// Hours and amounts for congestion tax in every city
    /// </summary>
    public class TollTimeFee: BaseTollEntity
    {
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }

        public int Fee { get; set; }
        


    }
}
