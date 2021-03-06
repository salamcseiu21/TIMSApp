﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TIMSApp.BLL.Contracts;
using TIMSApp.DatabaseContexts.DatabaseContext;
using TIMSApp.Models.EntityModels;

namespace TIMSApp.Controllers
{
    public class TraineesController : Controller
    {
        private readonly ITraineeManager _iTraineeManager;

        public TraineesController(ITraineeManager iTraineeManager)
        {
            _iTraineeManager = iTraineeManager;
        }

        // GET: Trainees
        public IActionResult Index()
        {
            return View(_iTraineeManager.GetAll().ToList());
        }

        // GET: Trainees/Details/5
        public IActionResult Details(int id)
        {
           

            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Phone,Address")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _iTraineeManager.Add(trainee);
               
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public IActionResult Edit(int id)
        {
            

            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email,Phone,Address")] Trainee trainee)
        {
          

            if (ModelState.IsValid)
            {
                try
                {
                    _iTraineeManager.Update(trainee);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.Id))
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
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public IActionResult Delete(int id)
        {


            var trainee = _iTraineeManager.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var trainee = _iTraineeManager.GetById(id);
            _iTraineeManager.Remove(trainee);

            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
            return _iTraineeManager.GetAll().Any(e => e.Id == id);
        }
    }
}
