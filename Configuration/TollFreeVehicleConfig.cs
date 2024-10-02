using congestion.calculator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Configuration
{
    internal class TollFreeVehicleConfig : IEntityTypeConfiguration<TollFreeVehicle>
    {
        public void Configure(EntityTypeBuilder<TollFreeVehicle> builder)
        {
            
        }
    }
}
