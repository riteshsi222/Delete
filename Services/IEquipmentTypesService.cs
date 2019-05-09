using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Services
{
    public interface IEquipmentTypesService
    {
        List<EquipmentTypes> GetEquipmentTypes(string rentalInfo);
        StringBuilder CalculateAmount(string rentalInfo);
        
    }
}
