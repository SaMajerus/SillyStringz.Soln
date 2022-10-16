using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Title");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, string name)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(license => license.JoinLicEngr)
        .ThenInclude(join => join.License)  //Connected to:  Details View, Ln 25 
        .Include(engineer => engineer.JoinMachEngr)
        .ThenInclude(join => join.Machine)  //Connected to:  Details View, Ln 10 
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
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
    
    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);  //Calls the Engineer which we'll be adding a Machine for. 
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");  //Connects to:  ../Views/Engineers/AddMachine.cshtml, Ln 17. 
      return View(thisEngineer); 
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngrId = engineer.EngineerId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult AddLicense(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);  //Calls the Engineer which we'll be adding a License for. 
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Title");  //Connects to:  ../Views/Engineers/AddLicense.cshtml, Ln 16. 
      return View(thisEngineer);
    }

    [HttpPost]  //(Destination for Views/Engineers/AddLicense.cshtml, Ln 19)
    public ActionResult AddLicense(Engineer engineer, int LicenseId)
    {
      if (LicenseId != 0)
      {
        _db.LicenseEngineer.Add(new LicenseEngineer() { LicenseId = LicenseId, EngrId = engineer.EngineerId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
} 