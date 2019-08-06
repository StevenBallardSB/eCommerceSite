﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class LibraryController : Controller
    {
        private GameContext _context;

        public LibraryController(GameContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<IActionResult> Index(int? id)
        {
            // Null-coalescing operator
            // If id is not null set page to it, or if null use 1
            int page = id ?? 1; //id is the page number coming in
            List<VideoGame> games = await VideoGameDb.GetGameByPage(_context, page, 3);

            return View(games);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                await VideoGameDb.Add(game, _context);
                return RedirectToAction("Index");
            }

            // Return view with model including error messages
            return View(game);
        }
    }
}