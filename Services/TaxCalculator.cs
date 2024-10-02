using System;
using System.Collections.Generic;
using System.Linq;
using congestion.calculator.Entities;
using congestion.calculator.Interfaces;
public class TaxCalculator : ITaxCalculator
{
    /**
         * Calculate the total toll fee for one day and for one city Rule
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    private City _cityInfo;
    public TaxCalculator(City city)
    {
       _cityInfo = city;
    }
    public int GetTax(Vehicle vehicle, List<DateTime> dates)
    {
        dates = dates.OrderBy(d=>d).ToList();

        DateTime intervalStart = dates[0];
        int totalFee = 0;
        int maxFeeInInterval = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            int tempFee = GetTollFee(intervalStart, vehicle);

            double diffMinutes =(date-intervalStart).TotalMinutes;

            //### The single charge rule
            if (_cityInfo.TimeSingleChargeRule.HasValue && diffMinutes <= _cityInfo.TimeSingleChargeRule)
            {
                if (nextFee > maxFeeInInterval)
                {
                    maxFeeInInterval = nextFee;
                }
            }
            else
            {
                totalFee += maxFeeInInterval;

                intervalStart = date;
                maxFeeInInterval = nextFee;
            }
        }

        totalFee += maxFeeInInterval;

        if (totalFee > _cityInfo.MaxFee) totalFee = _cityInfo.MaxFee;
        return totalFee;
    }

    private bool IsTollFreeVehicle(Vehicle vehicle)
    {
        if (vehicle == null) return false;
        
        return _cityInfo.TollFreeVehicles.Any(x=>x.VehicleId==vehicle.Id);
    }

    private int GetTollFee(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        var tollTimeFee = _cityInfo.TollTimeFee.FirstOrDefault(x => x.FromTime >= date.TimeOfDay && x.ToTime <= date.TimeOfDay);
        return tollTimeFee?.Fee ?? 0;
       
    }

    private Boolean IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (!_cityInfo.LimitedYear.HasValue || year == _cityInfo.LimitedYear)
            if (_cityInfo.TollFreeDates.Any(x=>x.FreeDate.Date==date.Date))
                return true;

        return false;
    }

 
}