﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDay.Models;
using YesDay.Models.ViewModels;

namespace YesDay.Controllers
{
    public class CoupleController : Controller
    {
        CoupleServices coupleServices;

        public CoupleController(CoupleServices services)
        {
            this.coupleServices = services;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            return View(coupleServices.ShowAllGuests());

        }

        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddGuest(CoupleAddNewGuestVM newGuestVM)
        {
            if (!ModelState.IsValid)
                return View(newGuestVM);

            coupleServices.AddNewGuest(newGuestVM);
            return RedirectToAction(nameof(GuestList));
        }

        [HttpGet]
        public IActionResult Overview()
        {
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await coupleServices.LogoutAsync();
            return RedirectToAction("Index", "Public");
        }

        [HttpGet]
        public IActionResult Checklist()
        {
            return View(coupleServices.GetChecklist());
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(CoupleAddNewTaskVM newTaskVM)
        {
            if (!ModelState.IsValid)
                return View(newTaskVM);

            coupleServices.AddNewTask(newTaskVM);
            return RedirectToAction(nameof(Checklist));
        }


    }
}