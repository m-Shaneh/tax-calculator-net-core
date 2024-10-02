using congestion.calculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Interfaces
{
    internal interface ITaxCalculator
    {
        
        int GetTax(Vehicle vehicle, List<DateTime> dates);
     
    }
}
