using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class ShoesController : Controller
    {
        ShoesStoreDataContextDataContext DataContxt=new ShoesStoreDataContextDataContext();
        public ActionResult ShowAllShoes()
        {
            List<Shoe>Shoes = DataContxt.Shoes.ToList();
            ViewBag.Shoes = Shoes ;
            return View();         
        }

        public ActionResult ShowAllShoesInTable()
        {
            List<Shoe> Shoes = DataContxt.Shoes.ToList();
            ViewBag.Shoes = Shoes;
            return View();
        }
        public ActionResult ShoesOnSale()
        {
            List<Shoe> Sale = DataContxt.Shoes.ToList();
            ViewBag.Sale = Sale;
            return View();
        }


    }
}