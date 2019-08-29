using System;
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
        public async Task<IActionResult> Search(SearchCriteria criteria)
        {
            if (ValidSearch(criteria))
            {
                criteria.GameResults = await VideoGameDb.Search(_context, criteria);
            }

            return View(criteria);
        }

        /// <summary>
        /// Returns true if user searched by at least 1 piece of criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        private bool ValidSearch(SearchCriteria criteria)
        {
            if (criteria.Title == null && criteria.Rating == null && criteria.minPrice == null && criteria.MaxPrice == null)
            {
                return false;
            }

            return true;
        }

        [HttpGet] 
        public async Task<IActionResult> Index(int? id)
        {
            // Null-coalescing operator
            // If id is not null set page to it, or if null use 1
            int page = id ?? 1; //id is the page number coming in
            const int PageSize = 3;

            List<VideoGame> games = await VideoGameDb.GetGameByPage(_context, page, PageSize);

            int totalPages = await VideoGameDb.GetTotalPages(_context, PageSize);
            ViewData["Pages"] = totalPages;
            ViewData["CurrentPage"] = page;

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
        public async Task<IActionResult> Update(int id)
        {
            VideoGame game = await VideoGameDb.GetGameById(id, _context);

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VideoGame g)
        {
            if (ModelState.IsValid)
            {
                await VideoGameDb.UpdateGame(g, _context);
                return RedirectToAction("Index");
            }

            // If there are any errors, show the user the form again
            return View(g);
        }

        public async Task<IActionResult> Delete(int id)
        {
            VideoGame game = await VideoGameDb.GetGameById(id, _context);

            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await VideoGameDb.DeleteById(id, _context);
            return RedirectToAction("Index");
        }
    }
}