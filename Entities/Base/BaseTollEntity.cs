using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace congestion.calculator.Entities.Base
{
    public class BaseTollEntity: BaseEntity
    {
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City city { get; set; }
    }
}
