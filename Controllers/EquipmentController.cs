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
            List<SportsEquipment> Equipment = DataContxt.SportsEquipments.ToList();
            ViewBag.Equipment = Equipment;
            return View();
        }

        public ActionResult ShowAllEquipmentInTabel()
        {
            List<SportsEquipment> EquipmentTable= DataContxt.SportsEquipments.ToList();
            ViewBag.EquipmentTable = EquipmentTable;
            return View();
        }

        public ActionResult ShowOnlyFootball()
        {
            List<SportsEquipment> Football = DataContxt.SportsEquipments.ToList();
            ViewBag.Football = Football;
            return View();
        }

        public ActionResult ShowOnlyBasketball()
        {
            List<SportsEquipment> Basketball = DataContxt.SportsEquipments.ToList();
            ViewBag.Basketball = Basketball;
            return View();
        }
        public ActionResult SortByPrice()
        {
            List<SportsEquipment> ListEquipment = DataContxt.SportsEquipments.OrderBy(item => item.Price).ToList();
            ViewBag.Sort = ListEquipment;
            return View();

        }
    }
}