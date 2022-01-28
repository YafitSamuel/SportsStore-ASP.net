using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class ShirtsController : Controller
    {
        ShoesStoreDataContextDataContext DataContxt = new ShoesStoreDataContextDataContext();

        // GET: Pants

        public ActionResult ShowShirt()
        {
            List<Clothing> ListShirt = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Shirts").ToList();
            ViewBag.Shirt = ListShirt;
            return View();
        }


        public ActionResult ShowOnlyLongShirt()
        {
            List<Clothing> ListShirt = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Shirts").ToList();
            ViewBag.Shirt = ListShirt;
            return View();
        }
        public ActionResult ShowOnlyShortShirt()
        {
            List<Clothing> ListShirt = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Shirts").ToList();
            ViewBag.Shirt = ListShirt;
            return View();

        }
        public ActionResult ShowAllShirtInTabel()
        {
            List<Clothing> ListShirt = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Shirts").ToList();
            ViewBag.Shirt = ListShirt;
            return View();
        }
        public ActionResult ShowOnlyDrapeShirts()
        {
            List<Clothing> ListShirt = DataContxt.Clothings.ToList();
            ViewBag.Clothings = ListShirt;
            return View();
        }
        public ActionResult SortByPrice()
        {
            List<Clothing> ListShirt = DataContxt.Clothings.Where(item => item.TypeOfClothing == "Shirts").OrderBy(item => item.Price).ToList();
            ViewBag.Sort = ListShirt;
            return View();


            
        }
    }
}