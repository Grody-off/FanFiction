﻿using FanFiction.Models;
using FanFiction.Models.AppDBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanFiction.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDBContext _context;

        public ChapterController(AppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewChapter(string id)
        {
            var comp = _context.Сomposition.FirstOrDefault(c => c.Id == id);
            if (comp != null)
            {
                var newChapter = new Chapter { CompositionId = comp.Id };

                return View(newChapter);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> NewChapter(Chapter chapter)
        {
            var comp = await _context.Сomposition
                                    .Include(c => c.Chapters)
                                    .FirstOrDefaultAsync(c => c.Id == chapter.CompositionId);

            if (comp == null)
                return Redirect("~/Сomposition/Index");

            var newChapter = new Chapter
            {
                Title = chapter.Title,
                Contents = chapter.Contents,
                Сomposition = comp
            };

            _context.Chapters.Add(newChapter);
            _context.SaveChanges();

            return Redirect("~/Сomposition/Index");
        }
    }
}