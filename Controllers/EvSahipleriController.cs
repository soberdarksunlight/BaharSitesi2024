using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class EvSahipleriController : Controller
    {
        private BaharSitesiDbContext _context;

        public EvSahipleriController(BaharSitesiDbContext context)
        {
            _context = context;
        }


        // GET: EvSahipleriController
        public ActionResult Index()
        {
            return View(_context.EvSahipleris);
        }

        // GET: EvSahipleriController/Details/5
        public ActionResult Details(int id)
        {
            EvSahipleri evSahipleri = _context.EvSahipleris.SingleOrDefault(e => e.Id == id);
            if (evSahipleri == null)
                return NoContent();
            return View();
        }

        // GET: EvSahipleriController/Create
        public ActionResult Create()
        {
            ViewBag.SelectDaire = new SelectList(_context.Daires, "Id", "DaireAciklama");
            return View();
        }

        // POST: EvSahipleriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EvSahipleri evSahipleri)
        {
            try
            {
                _context.EvSahipleris.Add(evSahipleri);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EvSahipleriController/Edit/5
        public ActionResult Edit(int id)
        {
            EvSahipleri evSahipleri = _context.EvSahipleris.SingleOrDefault(e => e.Id == id);

            return View(evSahipleri);
        }

        // POST: EvSahipleriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EvSahipleri evSahipleri)
        {
            try
            {
                EvSahipleri evSahipleri1 = _context.EvSahipleris.SingleOrDefault(e => e.Id == id);
                evSahipleri1.Adi = evSahipleri.Adi;
                evSahipleri1.Soyadi = evSahipleri.Soyadi;
                evSahipleri1.TelefonNo = evSahipleri.TelefonNo;
                evSahipleri1.EPosta = evSahipleri.EPosta;
                evSahipleri1.Sifre = evSahipleri.Sifre;
                evSahipleri1.Sorumlu = evSahipleri.Sorumlu;
                _context.Attach(evSahipleri1);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EvSahipleriController/Delete/5
        public ActionResult Delete(int id)
        {
            EvSahipleri evSahipleri = _context.EvSahipleris.SingleOrDefault(e => e.Id == id);
            return View(evSahipleri);
        }

        // POST: EvSahipleriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteEvSahipleri(int id)
        {
            try
            {
                EvSahipleri evSahipleri = _context.EvSahipleris.SingleOrDefault(e => e.Id == id);
                _context.Remove(evSahipleri);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
