using congestion.calculator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Configuration
{
    public class TollFreeDateConfig : IEntityTypeConfiguration<TollFreeDate>
    {
        public void Configure(EntityTypeBuilder<TollFreeDate> builder)
        {
            builder.Property(c => c.FreeDate).HasConversion(
                    v => v.Date,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
               
        }
    }
}
