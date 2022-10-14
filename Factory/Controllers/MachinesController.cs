/* 
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
      ViewBag.SportId = new SelectList(_db.Sports, "SportId", "Title");  //Connects to:  ../Views/Machines/Create.cshtml, Ln 18. 
      ViewBag.SemesterId = new SelectList(_db.Semesters, "SemesterId", "Term");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine player, int SportId)
    {
      _db.Machines.Add(player);
      _db.SaveChanges();
      if (SportId != 0)
      {
        _db.SportMachine.Add(new SportMachine() { SportId = SportId, MachineId = player.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(player => player.JoinPlrSprt)  //Details View, Ln 11 
        .ThenInclude(join => join.Sport)  //Details View, Ln 19 
        .Include(player => player.JoinSmstrPlyr)
        .ThenInclude(join => join.Semester)
        .FirstOrDefault(player => player.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(player => player.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine player, int SportId)
    {
      if (SportId != 0)
      {
        _db.SportMachine.Add(new SportMachine() { SportId = SportId, MachineId = player.MachineId});
      }
      _db.Entry(player).State = EntityState.Modified;  //Updates the entry/-ies in the database. 
      _db.SaveChanges(); //Saves changes to database 
      return RedirectToAction("Index");
    }

    public ActionResult AddSport(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(player => player.MachineId == id); 
      ViewBag.SportId = new SelectList(_db.Sports, "SportId", "Title");  //Connects to:  ../Views/Machines/AddSport.cshtml, Ln 16. 
      return View(thisMachine);
    }

    [HttpPost]  //(Destination for Views/Machines/AddSport.cshtml, Ln 18) 
    public ActionResult AddSport(Machine player, int SportId)
    {
      if (SportId != 0)
      {
        _db.SportMachine.Add(new SportMachine() { SportId = SportId, MachineId = player.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(player => player.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]  //(Destination for Views/Machines/Delete.cshtml, Ln 12) 
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(player => player.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteSport(int joinId)
    {  //Removes the connection between Sport and a Machine. 
      var joinEntry = _db.SportMachine.FirstOrDefault(entry => entry.SportMachineId == joinId);
      _db.SportMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddSemester(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(player => player.MachineId == id); 
      ViewBag.SemesterId = new SelectList(_db.Semesters, "SemesterId", "Term");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddSemester(Machine player, int SemesterId)
    {
      if (SemesterId != 0)
      {
        _db.SemesterMachine.Add(new SemesterMachine() { SemesterId = SemesterId, MachineId = player.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
} */