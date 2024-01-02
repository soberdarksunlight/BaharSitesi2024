using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class DaireController : Controller
    {
        private BaharSitesiDbContext _context;

        public DaireController(BaharSitesiDbContext context)
        {
            _context = context;
        }
        // GET: DaireController
        public ActionResult Index()
        {
            return View(_context.Daires);
        }

        // GET: DaireController/Details/5
        public ActionResult Details(int id)
        {
            Daire daire = _context.Daires.SingleOrDefault(d => d.Id == id);
            if (daire == null)
                return NoContent();
            return View();
        }

        // GET: DaireController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DaireController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Daire daire)
        {
            try
            {
                _context.Daires.Add(daire);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DaireController/Edit/5
        public ActionResult Edit(int id)
        {
            Daire daire = _context.Daires.SingleOrDefault(d => d.Id == id);

            return View(daire);
        }

        // POST: DaireController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Daire daire)
        {
            try
            {
                Daire daire1 = _context.Daires.SingleOrDefault(d => d == daire);
                daire1.Blok = daire.Blok;
                daire1.Kat = daire.Kat;
                daire1.DaireNo = daire.DaireNo;
                _context.Update(daire1);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DaireController/Delete/5
        public ActionResult Delete(int id)
        {
            Daire daire = _context.Daires.SingleOrDefault(d => d.Id == id); ;
            return View(daire);
        }

        // POST: DaireController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteDaire(int id)
        {
            try
            {
                Daire daire = _context.Daires.SingleOrDefault(da => da.Id == id);
                _context.Daires.Remove(daire);
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
