using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class LicensesController : Controller
  {
    private readonly FactoryContext _db;

    public LicensesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<License> model = _db.Licenses.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Title");  //Connects to:  ../Views/Licenses/Create.cshtml, Ln 14.
      return View();
    }

    [HttpPost]  //(Destination for Views/Licenses/Create.cshtml, Ln 16) 
    public ActionResult Create(License license, string title, int LicenseId, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.LicenseEngineer.Add(new LicenseEngineer() { EngineerId = EngineerId, LicenseId = license.LicenseId });
        _db.SaveChanges();
      }
      _db.Licenses.Add(license);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisLicense = _db.Licenses
        .Include(license => license.JoinLicEngr)  //Details View, Ln 10
        .ThenInclude(join => join.Engineer)  //Details View, Ln 20 
        .Include(license => license.JoinLicMach)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }

    public ActionResult Edit(int id)
    {  
      License thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }

    [HttpPost]  //(Destination for Views/Licenses/Edit.cshtml, Ln 21)
    public ActionResult Edit(License license)
    {
      _db.Entry(license).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      License thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }

    [HttpPost, ActionName("Delete")] 
    public ActionResult DeleteConfirmed(int id)
    {
      License thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      _db.Licenses.Remove(thisLicense);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);  //Calls the license which we'll be adding a Engineer for. 
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngrId", "Title");
      return View(thisLicense);
    }

    [HttpPost]
    public ActionResult AddEngineer(License license, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.LicenseEngineer.Add(new LicenseEngineer() { EngineerId = EngineerId, LicenseId = license.LicenseId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    
    public ActionResult AddMachine(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id); 
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisLicense);
    }

    [HttpPost]
    public ActionResult AddMachine(License license, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.LicenseMachine.Add(new LicenseMachine() { MachineId = MachineId, LicenseId = license.LicenseId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
} 