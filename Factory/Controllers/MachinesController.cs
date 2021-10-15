using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController:Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.NoEngineers = _db.Engineers.ToList().Count == 0;
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      var thisMachine = _db.Machines
        .Include(machine => machine.EngineerJoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(machine =>machine.MachineId ==id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId ==id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId ==id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId ==id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      if(EngineerId !=0)
      {
        _db.EngineerMachines.Add(new EngineerMachine () {MachineId = machine.MachineId, EngineerId = EngineerId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {
      var thisJoin = _db.EngineerMachines.FirstOrDefault(join => join.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(thisJoin);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}