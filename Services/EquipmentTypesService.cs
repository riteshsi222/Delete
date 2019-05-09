using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Services
{
    public class EquipmentTypesService : IEquipmentTypesService
    {
        private IEquipmentTypesRepository _iEquipmentTypesRepository;
        public EquipmentTypesService(IEquipmentTypesRepository iEquipmentTypesRepository)
        {
            _iEquipmentTypesRepository = iEquipmentTypesRepository;
        }
        public List<EquipmentTypes> GetEquipmentTypes(string rentalInfo)
        {
            return _iEquipmentTypesRepository.GetEquipmentTypes(rentalInfo);
        }
        public StringBuilder CalculateAmount(string rentalInfo)
        {
            return _iEquipmentTypesRepository.CalculateAmount(rentalInfo);
        }
    }
}
