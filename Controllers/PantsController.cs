using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class PantsController : Controller
    {

        ShoesStoreDataContextDataContext DataContxt = new ShoesStoreDataContextDataContext();

        // GET: Pants

        public ActionResult ShowPants()
        {
            List<Clothing> ListPantst = DataContxt.Clothings.Where(item=>item.TypeOfClothing=="Pants").ToList();
            ViewBag.Pants = ListPantst;
            return View();
        }


        public ActionResult ShowOnlyLongPants()
        {
            List<Clothing> ListPantst = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Pants").ToList();
            ViewBag.Pants = ListPantst;
            return View();
        }
        public ActionResult ShowOnlyShortPants()
        {
            List<Clothing> ListPantst = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Pants").ToList();
            ViewBag.Pants = ListPantst;
            return View();

        }
        public ActionResult ShowAllPantsInTabel()
        {
            List<Clothing> ListPantst = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Pants").ToList();
            ViewBag.Pants = ListPantst;
            return View();
        }
        public ActionResult ShowOnlyDrapePants()
        {
            List<Clothing> ListShirt = DataContxt.Clothings.Where(item => item.IsDreyfit == true).ToList();
            ViewBag.Pants = ListShirt;
            return View();
        }
        public ActionResult SortByPrice()
        {
            List<Clothing> sort = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Pants").OrderBy(item=>item.Price).ToList();            
            ViewBag.Pants = sort;
            return View();
        }
    }
}