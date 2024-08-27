using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        //veri tabanı olmadığı için buradan static olarak field tanımladık...
        private static int _nextId = 1;
        private static List<BlogPost> _posts = new List<BlogPost>();
        public IActionResult Index()
        {
            ViewBag.TotalPost = _posts.Count;
            ViewData["PageTitle"] = "Blog Gönderileri";


            return View(_posts);
        }
        public IActionResult Create()
        {
            ViewBag.CurrentTime = DateTime.Now;
            return View();
        }

        //bunun blog tipi bir http post olacağını söyler.. 
        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Id = _nextId++;
                _posts.Add(blogPost);
                TempData["SuccessMessage"] = "Blog Gönderisi Başarıyla Oluşturuldu";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CurrentTime = DateTime.Now;
            return View(blogPost);

        }

        public IActionResult Details(int id)
        {
            var post = _posts.FirstOrDefault(x => x.Id == id);
            if (post is null)
            {
                return NotFound();
            }

            ViewData["CreatedAgo"] = $"{(DateTime.Now - post.CreatedAt).TotalMinutes} dakika önce.";
            return View(post);
        }
    }
}
