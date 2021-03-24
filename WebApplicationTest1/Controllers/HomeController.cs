using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTest1.Models;
using WebApplicationTest1.Models.DB;

namespace WebApplicationTest1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var articles = Database.GetAllArticles();
            var authors = Database.GetAllAuthors();

            foreach (Article article in articles)
            {
                foreach (var art in article.Authors)
                {
                    art.Author = authors.Where(a => a.Id == art.AuthorId).First();
                }
            }

            return View(articles);
        }

        public IActionResult Article(int Id)
        {
            var article = Database.GetArticle(Id);
            return View(article);
        }

        public IActionResult EditArticle(int Id)
        {
            var article = Database.GetArticle(Id);
            return View(article);
        }

        public IActionResult AddArticle()
        {
            //var authors = Database.GetAllAuthors();
            //var categories = Database.GetAllCategories();
            //DualData data = new DualData(authors, categories);
            DualDataAuthorCategory data = new DualDataAuthorCategory(Database.GetAllAuthors(), Database.GetAllCategories());

            //return RedirectToAction("Index");
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateArticle(Article article)
        {
            if (Request.Form["Delete"] == "Delete")
            {
                Database.DeleteArticle(article);
                return RedirectToAction("Index");
            }
            Database.UpdateArticle(article);

            //return View();
            return RedirectToAction("Article", new { Id = article.Id });
        }

        public IActionResult CreateArticle(DualDataAuthorCategory data)
        {
            Article article = new Article();
            article.CategoryId = data.CategoryId;
            article.Name = data.ArticleName;
            article.Text = data.ArticleText;
            article.Id = 0;

            List<Author> authors = Database.GetAutorsByIds(data.AuthorId);

            List<ArticleAuthor> articleAuthors = new();

            foreach (var author in authors)
            {
                articleAuthors.Add(new ArticleAuthor() { Article = article, Author = author });
            }

            article.Authors = (articleAuthors);


            Database.AddArticle(article);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
