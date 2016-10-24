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

                _context.Albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Album album = _context.Albums.Single(m => m.AlbumID == id);
            _context.Albums.Remove(album);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var albumx = _context.Albums.Single(m => m.AlbumID == id);
            ViewBag.AlbumTitle = albumx.Title;
            ViewBag.Genre = new SelectList(_context.Genres, "GenreID", "Name");
            ViewBag.Artists = new SelectList(_context.Artists, "ArtistID", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var album = _context.Albums.Single(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(int id, Album album)
        {
            ViewBag.Genre = new SelectList(_context.Genres, "GenreID", "Name");
            ViewBag.Artists = new SelectList(_context.Artists, "ArtistID", "Name");

            ViewBag.AlbumTitle = album.Title;
            if(id != album.AlbumID)
            {
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                _context.Albums.Update(album);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(album);
        }

        //public IActionResult Details(int? id)
        //{
        //    ViewBag.AlbumTitle = 
        //}

    }
}
