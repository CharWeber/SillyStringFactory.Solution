using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class HomeController : Controller
    {

      private readonly FactoryContext _db;

      public HomeController(FactoryContext db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        Dictionary <string, object> model = new Dictionary <string, object>();
        var Engineers = _db.Engineers.ToList();
        var Machines = _db.Machines.ToList();
        model.Add("Engineers", Engineers);
        model.Add("Machines", Machines);
        return View(model);
      }
    }
}