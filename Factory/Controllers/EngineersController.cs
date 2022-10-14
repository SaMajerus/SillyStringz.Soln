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
      ViewBag.PlayerId = new SelectList(_db.Players, "PlayerId", "Name");
      ViewBag.SemesterId = new SelectList(_db.Semesters, "SemesterId", "Term");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer sport, string title)
    {
      _db.Engineers.Add(sport);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(semester => semester.JoinSmstrSprt)
        .ThenInclude(join => join.Semester)  //Connected to:  Details View, Ln 25 
        .Include(sport => sport.JoinPlrSprt)
        .ThenInclude(join => join.Player)  //Connected to:  Details View, Ln 10 
        .FirstOrDefault(sport => sport.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(sport => sport.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer sport)
    {
      _db.Entry(sport).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(sport => sport.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(sport => sport.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult AddPlayer(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(sport => sport.EngineerId == id);  //Calls the Engineer which we'll be adding a Player for. 
      ViewBag.PlayerId = new SelectList(_db.Players, "PlayerId", "Name");  //Connects to:  ../Views/Engineers/AddPlayer.cshtml, Ln 16. 
      return View(thisEngineer); 
    }

    [HttpPost]
    public ActionResult AddPlayer(Engineer sport, int PlayerId)
    {
      if (PlayerId != 0)
      {
        _db.EngineerPlayer.Add(new EngineerPlayer() { PlayerId = PlayerId, EngineerId = sport.EngineerId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult AddSemester(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(sport => sport.EngineerId == id);  //Calls the Engineer which we'll be adding a Semester for. 
      ViewBag.SemesterId = new SelectList(_db.Semesters, "SemesterId", "Term");  //Connects to:  ../Views/Engineers/AddSemester.cshtml, Ln 16. 
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddSemester(Engineer sport, int SemesterId)
    {
      if (SemesterId != 0)
      {
        _db.SemesterEngineer.Add(new SemesterEngineer() { SemesterId = SemesterId, EngineerId = sport.EngineerId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}