using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTest1.Models;

namespace WebApplicationTest1.Models.DB
{
    public class Database
    {
        public static List<Category> GetAllCategories()
        {
            using (MainDbContext db = new MainDbContext())
            {
                List<Category> categories = new List<Category>(db.Categories);

                return categories;
            }
        }

        public static List<Author> GetAllAuthors()
        {
            using (MainDbContext db = new MainDbContext())
            {
                List<Author> authors = new List<Author>(db.Authors);

                return authors;
            }
        }

        public static List<Article> GetAllArticles()
        {
            using (MainDbContext db = new MainDbContext())
            {
                List<Article> articles = new List<Article>(db.Articles);

                foreach (var article in articles)
                {
                    article.Authors = db.ArticleAuthors.Where(a => a.ArticleId == article.Id).ToList();
                }


                return articles;
            }
        }

        public static Article GetArticle(int Id)
        {
            using (MainDbContext db = new MainDbContext())
            {
                var article = db.Articles.Where(a => a.Id == Id).FirstOrDefault();

                if (article == null)
                {
                    return null;
                }

                article.Authors = db.ArticleAuthors.Where(a => a.ArticleId == article.Id).ToList();

                foreach (var item in article.Authors)
                {
                    item.Author = db.Authors.Where(i => i.Id == item.AuthorId).FirstOrDefault();
                }

                return article;
            }
        }

        public static void AddArticle(Article article)
        {
            using (MainDbContext db = new MainDbContext())
            {
                db.Articles.Add(article);
                //db.SaveChanges();
            }
        }

        public static void UpdateArticle(Article article)
        {
            using (MainDbContext db = new MainDbContext())
            {
                var art = db.Articles.Where(a => a.Id == article.Id).FirstOrDefault();
                if (art != null)
                {
                    art.Name = article.Name;
                    art.Text = article.Text;
                    db.SaveChanges();
                }
            }
        }
    }
}
