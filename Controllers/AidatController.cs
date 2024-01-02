using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AidatController : Controller
    {
        private BaharSitesiDbContext _context;

        public AidatController(BaharSitesiDbContext context)
        {
            _context = context;
        }



        // GET: AidatController
        public ActionResult Index()
        {

            return View(_context.Aidats);
        }

        // GET: AidatController/Details/5
        public ActionResult Details(int id)
        {
            Aidat aidat = _context.Aidats.FirstOrDefault(a => a.Id == id);
            if (aidat == null)
                return NoContent();
            return View();
        }

        // GET: AidatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AidatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aidat aidat)
        {
            try
            {
                _context.Aidats.Add(aidat);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AidatController/Edit/5
        public ActionResult Edit(int id)
        {
            Aidat aidat = _context.Aidats.FirstOrDefault(aidat => aidat.Id == id);
            return View(aidat);
        }

        // POST: AidatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Aidat aidat)
        {
            try
            {
                Aidat aidat1 = _context.Aidats.FirstOrDefault(a => a.Id == id);
                aidat1.Tutar = aidat.Tutar;
                aidat1.BaslangicTarihi = aidat.BaslangicTarihi;
                aidat1.BitisTarihi = aidat.BitisTarihi;

                _context.Attach(aidat1);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AidatController/Delete/5
        public ActionResult Delete(int id)
        {
            Aidat aidat = _context.Aidats.FirstOrDefault(a => a.Id == id);

            return View(aidat);
        }

        // POST: AidatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteAidat(int id)
        {
            try
            {
                Aidat aidat = _context.Aidats.FirstOrDefault(a => a.Id == id);
                _context.Remove(aidat);
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
