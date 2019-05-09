using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;
using Services;
using System.Text;
using System.IO;

namespace Assignment.Controllers
{
    public class EquipmentTypeController : Controller
    {
        static StreamWriter sw = null;
        private IEquipmentTypesService _iEquipmentTypesService;
        public EquipmentTypeController(IEquipmentTypesService iEquipmentTypesService)
        {
            CreateLog();
            WriteToLog("Process started at : " + DateTime.Now);
            _iEquipmentTypesService = iEquipmentTypesService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            WriteToLog("Data loaded at : " + DateTime.Now);
            string rentalInfo = (string)Session["UserInfo"];
            var equipmentTypeList = _iEquipmentTypesService.GetEquipmentTypes(rentalInfo);
            return View(equipmentTypeList);
        }
        [HttpGet]
        public FileStreamResult PrintInvoice()
        {
            string rentalInfo = (string)Session["UserInfo"];
            var data = _iEquipmentTypesService.CalculateAmount(rentalInfo);

            var byteArray = Encoding.ASCII.GetBytes(data.ToString());
            var stream = new MemoryStream(byteArray);

            WriteToLog("Process completed at : " + DateTime.Now);

            return File(stream, "text/plain", String.Format("{0}.txt", "Invoice Detail"));
        }
        [HttpGet]
        public ActionResult AddToCart(int Id)
        {
            string rentalInfo = (string)Session["UserInfo"];
            var eq = _iEquipmentTypesService.GetEquipmentTypes(rentalInfo).Where(s => s.EquipmentId == Id).FirstOrDefault();
            return View(eq);
        }

        [HttpPost]
        public ActionResult AddToCart(string Id)
        {
            int ID = int.Parse(Id.ToString());
            string rentalInfo = (string)Session["UserInfo"];
            var equipment = _iEquipmentTypesService.GetEquipmentTypes(rentalInfo).Where(s => s.EquipmentId == ID).FirstOrDefault();

            int rentalDays = int.Parse(Request.Form["RentalDays"]);
            if (Session["UserInfo"] == null)
            {
                Session["UserInfo"] = Id + ":" + rentalDays;
            }
            else
            {
                Session["UserInfo"] += "|" + Id + ":" + rentalDays;
            }
            return RedirectToAction("Index");
        }
        private static void CreateLog()
        {
            if (sw == null)
                sw = new StreamWriter("C:\\AppLog.txt");
        }

        static void WriteToLog(String strMsg)
        {
            sw.WriteLine(strMsg);
            sw.Flush();

        }
    }
}