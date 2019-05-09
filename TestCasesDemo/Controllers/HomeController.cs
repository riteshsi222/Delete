using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace TestCasesDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CheckEquipmentTypes()
        {
            List<EquipmentTypes> eq = new List<EquipmentTypes>();
            eq = new List<EquipmentTypes>{
                    new EquipmentTypes() { EquipmentId = 1, EquipmentName ="Caterpillar bulldozer", EquipmentTypeName = "Heavy", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 0, RentalDays = 0},
                    new EquipmentTypes() { EquipmentId = 2, EquipmentName ="KamAZ truck", EquipmentTypeName = "Regular", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 40, RentalDays = 0},
                    new EquipmentTypes() { EquipmentId = 3, EquipmentName ="Bosch jackhammer", EquipmentTypeName = "Specialized", OneTimeRentalFee = 0, PremiumDailyFee = 60, RegularDailyFee = 40, RentalDays = 0},
                    new EquipmentTypes() { EquipmentId = 4, EquipmentName ="Komatsu crane", EquipmentTypeName = "Heavy", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 0, RentalDays = 0},
                    new EquipmentTypes() { EquipmentId = 5, EquipmentName ="Volvo steamroller", EquipmentTypeName = "Regular", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 40, RentalDays = 0}
                };

            return View();
        }

        public ActionResult CalculateInvoiceTest()
        {
            List<EquipmentTypes> eq = new List<EquipmentTypes>();
            eq = new List<EquipmentTypes>{
                    new EquipmentTypes() { EquipmentId = 1, EquipmentName ="Caterpillar bulldozer", EquipmentTypeName = "Heavy", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 0, RentalDays = 3},
                    new EquipmentTypes() { EquipmentId = 2, EquipmentName ="KamAZ truck", EquipmentTypeName = "Regular", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 40, RentalDays = 4},
                    new EquipmentTypes() { EquipmentId = 3, EquipmentName ="Bosch jackhammer", EquipmentTypeName = "Specialized", OneTimeRentalFee = 0, PremiumDailyFee = 60, RegularDailyFee = 40, RentalDays = 5},
                    new EquipmentTypes() { EquipmentId = 4, EquipmentName ="Komatsu crane", EquipmentTypeName = "Heavy", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 0, RentalDays = 6},
                    new EquipmentTypes() { EquipmentId = 5, EquipmentName ="Volvo steamroller", EquipmentTypeName = "Regular", OneTimeRentalFee = 100, PremiumDailyFee = 60, RegularDailyFee = 40, RentalDays = 7}
                };
            StringBuilder sb = CalculateAmount(eq);
            return View();
        }

        public StringBuilder CalculateAmount(List<EquipmentTypes> eq)
        {
            var equipmentTypeList = eq;

            Decimal TotalAmount = 0;
            int LoyalityPoints = 0;
            //todo: add some data from your database into that string:
            StringBuilder data = new StringBuilder();
            data.Append("===============================================================================================================================================================================".PadRight(175));
            data.Append(Environment.NewLine);
            data.Append("Invoice Receipt".PadRight(175));
            data.Append(Environment.NewLine);
            data.Append("===============================================================================================================================================================================".PadRight(175));
            data.Append(Environment.NewLine);
            data.Append("Name".PadRight(50));
            data.Append("Type".PadRight(25));
            data.Append("Rental Days".PadRight(25));
            data.Append("One Time Rental Fee".PadRight(25));
            data.Append("Premium Fee".PadRight(25));
            data.Append("Regular Fee".PadRight(25));
            data.Append(Environment.NewLine);
            data.Append("===============================================================================================================================================================================".PadRight(175));
            data.Append(Environment.NewLine);
            for (int i = 0; i < equipmentTypeList.Count; i++)
            {
                int oneTimeRentalFee = 0;
                int premiumFee = 0;
                int regularFee = 0;
                if (equipmentTypeList[i].EquipmentTypeName.ToString() == "Heavy")
                {
                    int iRentalDays = equipmentTypeList[i].RentalDays;
                    oneTimeRentalFee = equipmentTypeList[i].OneTimeRentalFee;
                    premiumFee = (iRentalDays * equipmentTypeList[i].PremiumDailyFee);
                    regularFee = 0;
                    TotalAmount += equipmentTypeList[i].OneTimeRentalFee + (iRentalDays * equipmentTypeList[i].PremiumDailyFee);
                    LoyalityPoints += 2;
                }
                if (equipmentTypeList[i].EquipmentTypeName.ToString() == "Regular")
                {
                    oneTimeRentalFee = equipmentTypeList[i].OneTimeRentalFee;
                    int iRentalDays = equipmentTypeList[i].RentalDays;
                    if (iRentalDays > 2)
                    {
                        premiumFee += (2 * equipmentTypeList[i].PremiumDailyFee);
                        regularFee += ((iRentalDays - 2) * equipmentTypeList[i].RegularDailyFee);
                        TotalAmount += equipmentTypeList[i].OneTimeRentalFee + (2 * equipmentTypeList[i].PremiumDailyFee) + ((iRentalDays - 2) * equipmentTypeList[i].RegularDailyFee);
                    }
                    if (iRentalDays <= 2)
                    {
                        premiumFee += (iRentalDays * equipmentTypeList[i].PremiumDailyFee);
                        regularFee += 0;
                        TotalAmount += equipmentTypeList[i].OneTimeRentalFee + (iRentalDays * equipmentTypeList[i].PremiumDailyFee);
                    }
                    LoyalityPoints += 1;
                }
                if (equipmentTypeList[i].EquipmentTypeName.ToString() == "Specialized")
                {
                    oneTimeRentalFee = 0;
                    int iRentalDays = equipmentTypeList[i].RentalDays;
                    if (iRentalDays > 3)
                    {
                        premiumFee += (3 * equipmentTypeList[i].PremiumDailyFee);
                        regularFee += ((iRentalDays - 3) * equipmentTypeList[i].RegularDailyFee);
                        TotalAmount += (3 * equipmentTypeList[i].PremiumDailyFee) + ((iRentalDays - 3) * equipmentTypeList[i].RegularDailyFee);
                    }
                    if (iRentalDays <= 3)
                    {
                        premiumFee += (iRentalDays * equipmentTypeList[i].PremiumDailyFee);
                        regularFee += 0;
                        TotalAmount += (iRentalDays * equipmentTypeList[i].PremiumDailyFee);
                    }
                    LoyalityPoints += 1;
                }

                data.Append(equipmentTypeList[i].EquipmentName.Trim().PadRight(50));
                data.Append(equipmentTypeList[i].EquipmentTypeName.Trim().PadRight(25));
                data.Append(equipmentTypeList[i].RentalDays.ToString().Trim().PadRight(25));
                data.Append(oneTimeRentalFee.ToString().Trim().PadRight(25));
                data.Append(premiumFee.ToString().Trim().PadRight(25));
                data.Append(regularFee.ToString().Trim().PadRight(25));
                data.Append(Environment.NewLine);
            }
            data.Append("===============================================================================================================================================================================".PadRight(150));
            data.Append(Environment.NewLine);
            data.Append("".PadRight(125));
            data.Append(("Total Amount :" + TotalAmount).PadRight(50));
            data.Append(Environment.NewLine);
            data.Append("===============================================================================================================================================================================".PadRight(150));
            data.Append(Environment.NewLine);
            data.Append("".PadRight(125));
            data.Append(("Loyality Points Earned :" + LoyalityPoints).PadRight(50));
            data.Append(Environment.NewLine);
            data.Append("===============================================================================================================================================================================".PadRight(150));

            return data;
        }
    }
}