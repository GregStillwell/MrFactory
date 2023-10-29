using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly FactoryContext _db;

    public EngineerController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "All Engineer";
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add an Engineer";
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
        ViewBag.PageTitle = "Engineer Details";
        Engineer thisEngineer = _db.Engineers
        .Include(engineer => engineer.JoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
        return View(thisEngineer);
      }

    public ActionResult Edit(int Id)
    {
      ViewBag.PageTitle = "Edit Engineer";
      Engineer thisEngineer = _db.Engineers
      .Include(engineer => engineer.JoinEntities)
      .ThenInclude(join => join.Machine)
      .FirstOrDefault(engineer => engineer.EngineerId == Id);
      return View(thisEngineer);
    }
     
    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
       if (!ModelState.IsValid)
      {
        ModelState.AddModelError("", "Please correct the errors and try again.");
        return View(engineer);
      }
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      ViewBag.PageTitle = "Delete Engineer";
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

      public ActionResult AddMachine(int id)
      {
        ViewBag.PageTitle = "Add Machine";
        Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Model");
        return View(thisEngineer);
      
      }




  }
}