using congestion.calculator.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace congestion.calculator.Entities
{

    /// <summary>
    /// Tax Exempt vehicles in every city
    /// </summary>
    public class TollFreeVehicle: BaseTollEntity
    {
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle vehicle { get; set; }

    }
}
