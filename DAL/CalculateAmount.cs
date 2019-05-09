using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CalculateAmount
    {
        List<EquipmentTypes> LineItems { get; set; }
        public string LoyalityPoints { get; set; }
        public string TotalAmount { get; set; }
    }
}
