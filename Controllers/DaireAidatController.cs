using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class DaireAidatController : Controller
    {

        private BaharSitesiDbContext _context;

        public DaireAidatController(BaharSitesiDbContext context)
        {
            _context = context;
        }
        // GET: DaireAidatController
        public ActionResult Index()
        {

            var model = _context.DaireAidats.Include(i => i.Daire);
            return View(model);
        }



        // GET: DaireAidatController/Details/5
        public ActionResult Details(int id)
        {
            DaireAidat daireAidat = _context.DaireAidats.SingleOrDefault(x => x.Id == id);
            if (daireAidat == null)
                return NoContent();
            return View();
        }

        // GET: DaireAidatController/Create
        public ActionResult Create()
        {
            ViewBag.SelectDaire = new SelectList(_context.Daires, "Id", "DaireAciklama");
            ViewBag.SelectAidat = new SelectList(_context.Aidats, "Id", "AidatDönemi");
            return View();
        }

        // POST: DaireAidatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DaireAidat daireAidat)
        {
            try
            {
                _context.DaireAidats.Add(daireAidat);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DaireAidatController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SelectDaire = new SelectList(_context.Daires, "Id", "DaireNo");
            ViewBag.SelectAidat = new SelectList(_context.Aidats, "Id", "AidatDönemi");
            DaireAidat daireAidat = _context.DaireAidats.SingleOrDefault(x => x.Id == id);
            return View(daireAidat);
        }

        // POST: DaireAidatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DaireAidat daireAidat)
        {
            try
            {
                DaireAidat daireAidat1 = _context.DaireAidats.SingleOrDefault(x => x.Id == id);
                daireAidat1.ÖdemeTarihi = daireAidat.ÖdemeTarihi;
                daireAidat1.ÖdenenTutar = daireAidat.ÖdenenTutar;
                _context.Update(daireAidat1);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DaireAidatController/Delete/5
        public ActionResult Delete(int id)
        {
            DaireAidat daireAidat = _context.DaireAidats.SingleOrDefault(x => x.Id == id);
            return View(daireAidat);
        }

        // POST: DaireAidatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteDaireAidat(int id)
        {
            try
            {
                DaireAidat daireAidat = _context.DaireAidats.SingleOrDefault(x => x.Id != id);
                _context.DaireAidats.Remove(daireAidat);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Tahsilat()
        {
            ViewBag.DaireAciklama = new SelectList(_context.Daires, "Id", "DaireAciklama");
            ViewBag.SelectAidat = new SelectList(_context.Aidats, "Id", "AidatDönemi");
            return View();
        }

        // POST: DaireAidatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tahsilat(DaireAidat daireAidat)
        {
            try
            {
                DaireAidat selectDaireAidat = _context.DaireAidats.First(i => i.AidatId == daireAidat.AidatId && i.DaireId == daireAidat.DaireId);

                selectDaireAidat.ÖdemeTarihi = DateTime.Today;
                selectDaireAidat.ÖdenenTutar = daireAidat.ÖdenenTutar;

                _context.Update(selectDaireAidat);
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
