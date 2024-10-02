using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using congestion.calculator.Entities.Base;

namespace congestion.calculator.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class TollFreeDate : BaseTollEntity
    {
        [Column(TypeName = "Date")]
        public DateTime FreeDate { get; set; }

    }
}
