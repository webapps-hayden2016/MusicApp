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



    }
}
