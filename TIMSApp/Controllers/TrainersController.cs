﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TIMSApp.BLL.Contracts;
using TIMSApp.DatabaseContexts.DatabaseContext;
using TIMSApp.Models.EntityModels;

namespace TIMSApp.Controllers
{
    public class TrainersController : Controller
    {
        private readonly ITrainerManager _iTrainerManager; 

        public TrainersController(ITrainerManager iTrainerManager)
        {
            _iTrainerManager = iTrainerManager;
        }

        // GET: Trainers
        public IActionResult Index()
        {
            return View(_iTrainerManager.GetAll().ToList());
        }

        // GET: Trainers/Details/5
        public IActionResult Details(int id)
        {
           

            var trainer = _iTrainerManager.GetById(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // GET: Trainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Phone,Email,Address,LinkedinProfile")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _iTrainerManager.Add(trainer);
                
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public IActionResult Edit(int id)
        {
            

            var trainer = _iTrainerManager.GetById(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Phone,Email,Address,LinkedinProfile")] Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _iTrainerManager.Update(trainer);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerExists(trainer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public IActionResult Delete(int id)
        {
           
            var trainer = _iTrainerManager.GetById(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var trainer= _iTrainerManager.GetById(id);
            _iTrainerManager.Remove(trainer);
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
            return _iTrainerManager.GetAll().Any(e => e.Id == id);
        }
    }
}
