using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
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
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");  //Connects to:  ../Views/Machines/Create.cshtml, Ln 18. 
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Title");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine mach, int EngineerId)
    {
      _db.Machines.Add(mach);
      _db.SaveChanges();
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngrId = EngineerId, MachineId = mach.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(mach => mach.JoinMachEngr)  //Details View, Ln 11 
        .ThenInclude(join => join.Engineer)  //Details View, Ln 19 
        .Include(mach => mach.JoinLicMach)
        .ThenInclude(join => join.License)
        .FirstOrDefault(mach => mach.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine mach, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngrId = EngineerId, MachineId = mach.MachineId});
      }
      _db.Entry(mach).State = EntityState.Modified;  //Updates the entry(-ies) in the database. 
      _db.SaveChanges(); //Saves changes to database 
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id); 
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");  //Connects to:  ../Views/Machines/AddEngineer.cshtml, Ln 16. 
      return View(thisMachine);
    }

    [HttpPost]  //(Destination for Views/Machines/AddEngineer.cshtml, Ln 18) 
    public ActionResult AddEngineer(Machine mach, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngrId = EngineerId, MachineId = mach.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]  //(Destination for Views/Machines/Delete.cshtml, Ln 12) 
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {  //Removes the connection between Engineer and a Machine. 
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddLicense(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id); 
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Title");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddLicense(Machine mach, int LicenseId)
    {
      if (LicenseId != 0)
      {
        _db.LicenseMachine.Add(new LicenseMachine() { LicenseId = LicenseId, MachineId = mach.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
} 