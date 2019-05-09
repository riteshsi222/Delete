using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class EquipmentType
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int EquipmentId { get; set; }
        [Display(Name = "Name")]
        public string EquipmentName { get; set; }
        [Display(Name = "Type")]
        public string EquipmentTypeName { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int OneTimeRentalFee { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int PremiumDailyFee { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RegularDailyFee { get; set; }
        [Display(Name = "Rental Days")]
        public int RentalDays { get; set; }

    }
}