using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicFall2016.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicFall2016.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MusicDbContext _context;

        public AlbumsController(MusicDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var albums =  _context.Albums.ToList();
            return View(albums);
        }

        public IActionResult Create()
        {
            ViewBag.Genre = new SelectList(_context.Genres, "GenreID", "Name");
            ViewBag.Artists = new SelectList(_context.Artists, "ArtistID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            ViewBag.Genre = new SelectList(_context.Genres, "GenreID", "Name");
            ViewBag.Artists = new SelectList(_context.Artists, "ArtistID", "Name");

            if (ModelState.IsValid)
            {
                var artist = (from c in _context.Artists
                              where c.ArtistID == album.ArtistID
                              select c).First();
                album.Artist = artist;
                _context.Albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(Album album)
        {
            _context.Albums.Remove(album);

            return RedirectToAction("Index");
        }



    }
}
