using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class EquipmentController : Controller
    {

        ShoesStoreDataContextDataContext DataContxt = new ShoesStoreDataContextDataContext();

        public ActionResult ShowAllEquipment()
        {
            List<sportEquipment> Equipment = DataContxt.sportEquipments.ToList();
            ViewBag.Equipment = Equipment;
            return View();
        }

        public ActionResult ShowAllEquipmentInTabel()
        {
            List<sportEquipment> EquipmentTable= DataContxt.sportEquipments.ToList();
            ViewBag.EquipmentTable = EquipmentTable;
            return View();
        }

        public ActionResult ShowOnlyFootball()
        {
            List<sportEquipment> Football = DataContxt.sportEquipments.ToList();
            ViewBag.Football = Football;
            return View();
        }

        public ActionResult ShowOnlyBasketball()
        {
            List<sportEquipment> Basketball = DataContxt.sportEquipments.ToList();
            ViewBag.Basketball = Basketball;
            return View();
        }
        public ActionResult SortByPrice()
        {
            List<sportEquipment> ListEquipment = DataContxt.sportEquipments.OrderBy(item => item.price).ToList();
            ViewBag.Sort = ListEquipment;
            return View();

        }
    }
}