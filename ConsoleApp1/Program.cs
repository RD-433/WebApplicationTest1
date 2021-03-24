using System;
using System.Collections.Generic;
using WebApplicationTest1.Models;
using WebApplicationTest1.Models.DB;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            try
            {
                #region Create Data

                List<Category> categories = new List<Category>()
                    {
                        new Category(){ Name="Tech" },
                        new Category(){ Name="Mech" },
                        new Category(){ Name="Hack" },
                    };


                List<Author> authors = new List<Author>()
                    {
                        new Author(){ Name="Author 1" },
                        new Author(){ Name="Author 2" },
                        new Author(){ Name="Author 3" },
                    };


                List<Article> articles = new List<Article>()
                    {
                        new Article(){ Name="Name 1", Text=Text.text[0], Category = categories[0] },
                        new Article(){ Name="Name 2", Text=Text.text[1], Category = categories[2] },
                        new Article(){ Name="Name 3", Text=Text.text[2], Category = categories[1] },
                        new Article(){ Name="Name 4", Text=Text.text[3], Category = categories[2] },
                        new Article(){ Name="Name 5", Text=Text.text[4], Category = categories[2] },
                        new Article(){ Name="Name 6", Text=Text.text[5], Category = categories[0] },
                        new Article(){ Name="Name 7", Text=Text.text[6], Category = categories[1] },
                    };

                List<ArticleAuthor> articleAuthors = new List<ArticleAuthor>()
                {
                    new ArticleAuthor(){ Article=articles[0], Author=authors[0] },
                    new ArticleAuthor(){ Article=articles[0], Author=authors[2] },
                    new ArticleAuthor(){ Article=articles[1], Author=authors[1] },
                    new ArticleAuthor(){ Article=articles[1], Author=authors[2] },
                    new ArticleAuthor(){ Article=articles[2], Author=authors[2] },
                    new ArticleAuthor(){ Article=articles[3], Author=authors[2] },
                    new ArticleAuthor(){ Article=articles[3], Author=authors[1] },
                    new ArticleAuthor(){ Article=articles[3], Author=authors[0] },
                    new ArticleAuthor(){ Article=articles[4], Author=authors[0] },
                    new ArticleAuthor(){ Article=articles[5], Author=authors[2] },
                    new ArticleAuthor(){ Article=articles[5], Author=authors[0] },
                    new ArticleAuthor(){ Article=articles[6], Author=authors[1] },
                    new ArticleAuthor(){ Article=articles[6], Author=authors[2] },

                };

                try
                {
                    using (MainDbContext db = new MainDbContext())
                    {
                        db.Categories.AddRange(categories);
                        db.Authors.AddRange(authors);
                        db.Articles.AddRange(articles);
                        db.ArticleAuthors.AddRange(articleAuthors);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Finish!");
                }
                catch (Exception)
                {
                    Console.WriteLine("something went wrong...");
                    //throw;
                }

                #endregion
            }
            catch (Exception)
            {

                Console.WriteLine("!!!!!!!!!!!!");
                Console.ReadLine();
            }

        }
    }
}
