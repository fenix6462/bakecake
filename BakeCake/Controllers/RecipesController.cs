using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeCake.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipes
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Details()
        {
            return PartialView();
        }

        public ActionResult Create()
        {
            return PartialView();
        }
    }
}