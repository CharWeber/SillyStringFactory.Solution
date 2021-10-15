using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.NoMachines = _db.Machines.ToList().Count == 0;
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.MachineJoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId ==id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //addMachine
    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() {EngineerId = engineer.EngineerId, MachineId = MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //deleteMachine
    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var thisJoin = _db.EngineerMachines.FirstOrDefault(join => join.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(thisJoin);
      return RedirectToAction ("Index");
    }
  }
}