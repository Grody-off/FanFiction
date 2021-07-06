using FanFiction.Models;
using FanFiction.Models.AppDBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FanFiction.Controllers
{
    public class СompositionController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDBContext _context;
        public readonly UserManager<IdentityUser> _userManager;

        public СompositionController(AppDBContext context,
            UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; 
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return RedirectToAction("Index");

            var comp = _context.Сomposition.Where(c => c.AuthorID == userId).ToList();

            if (comp == null)
                return RedirectToAction("Index");

            return View(comp);
        }

        public IActionResult New() => View();
        [HttpPost]
        public IActionResult New(Сomposition comp)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newComp = new Сomposition
            {
                AuthorID = userId,
                Title = comp.Title,
                Description = comp.Description,
                Fandom = comp.Fandom
            };

            _context.Add(newComp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var comp = await _context.Сomposition.FirstOrDefaultAsync(c => c.Id == id);
            if(comp != null)
            {
                Сomposition compos = new Сomposition
                {
                    Id = comp.Id,
                    AuthorID = comp.AuthorID,
                    Title = comp.Title,
                    Description = comp.Description,
                    Fandom = comp.Fandom,
                    Tags = comp.Tags
                };
                return View(compos);
            }
            return NotFound();  
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Сomposition updated, string id)
        {
            if (updated == null)
                return RedirectToAction("Index");
            var comp = await _context.Сomposition.FirstOrDefaultAsync(c => c.Id == id);

            comp.Title = updated.Title;
            comp.Description = updated.Description;
            comp.Fandom = updated.Fandom;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Сomposition comp = await _context.Сomposition.FirstOrDefaultAsync(c => c.Id == id);
            if (comp != null)
            {
                _context.Сomposition.Remove(comp);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
