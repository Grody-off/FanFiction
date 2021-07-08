using FanFiction.Models;
using FanFiction.Models.AppDBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace FanFiction.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDBContext _context;

        public FavoritesController(AppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult AddToFavorite(string id)
        {
            var comp = _context.Сomposition
                                .Include(c => c.Favorites)
                                .FirstOrDefault(c => c.Id == id);

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var check = comp.Favorites.FirstOrDefault(c => c.UserId == userId);

            if(check == null)
            {
                Favorites fav = new()
                {
                    UserId = userId,
                    CompositionId = comp.Id,
                };

                _context.Favorites.Add(fav);
            }
            else
                _context.Favorites.Remove(check);

            _context.SaveChanges();
            return Redirect("~/Home/Index");
        }

        public IActionResult FavoriteList()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favor = _context.Favorites
                                .Include(c => c.Сomposition)
                                .Where(c => c.UserId == userId);

            return View(favor.ToList());
        }

        public IActionResult Index() => View();
        
    }
}
