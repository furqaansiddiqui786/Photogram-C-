using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Photogram.Data;
using Photogram.Models;
using Photogram.Models.ViewModels;

namespace Photogram.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            
            var postsfromuser = await _db.PostsModel.ToListAsync();    
            return View(postsfromuser);
        }

        public IActionResult About()
        {
            return View();
        }


        //create a timeline view
        [Authorize]
        public async Task<IActionResult> YourPosts()
        {
            var claimsidentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);

            UserPostViewModel upm = new UserPostViewModel()
            {
                PostModel = await _db.PostsModel.Where(c => c.UserId == claims.Value).ToListAsync(),
                ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(c => c.Id == claims.Value)
            };

            return View(upm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YourPosts(UserProfileModel upm)
        {
            var claimsidentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);

            if (upm.Id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count() > 0)
                {
                    byte[] pic = null;
                    using (var filestream = files[0].OpenReadStream())
                    {
                        using (var memorystream = new MemoryStream())
                        {
                            filestream.CopyTo(memorystream);
                            pic = memorystream.ToArray();
                        }
                    }
                    upm.ProfilePicture = pic;
                }
                upm.UserId = claims.Value;
                _db.UserProfileModel.Add(upm);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(YourPosts));
            }
            return View(upm);
        }

        //add posts
        public IActionResult AddPost()
        {
            return View();
        }
        //add post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(PostsModel pm)
        {
            var claimsidentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if(files.Count() > 0)
                {
                    byte[] pic = null;
                    using(var filestream = files[0].OpenReadStream())
                    {
                        using(var memorystream = new MemoryStream())
                        {
                            filestream.CopyTo(memorystream);
                            pic = memorystream.ToArray();
                        }
                    }
                    pm.Post = pic;
                }
                pm.UserId = claims.Value;
                _db.PostsModel.Add(pm);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(YourPosts));
            }
            return View(pm);
        }

        //delete button
        public async Task<IActionResult>Delete(int id)
        {
            if(id == null) { return NotFound(); }
            var postfromdb = await _db.PostsModel.FindAsync(id);
            if(postfromdb != null)
            {
                _db.PostsModel.Remove(postfromdb);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(YourPosts));
            }
            return View();
        }
        
    }
}
