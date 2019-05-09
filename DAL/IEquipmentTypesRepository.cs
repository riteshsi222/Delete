using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IEquipmentTypesRepository
    {
        List<EquipmentTypes> GetEquipmentTypes(string rentalInfo);
        StringBuilder CalculateAmount(string rentalInfo);
    }
}
