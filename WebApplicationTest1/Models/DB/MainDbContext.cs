using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTest1.Models;

namespace WebApplicationTest1.Models.DB
{
    public class MainDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleAuthor> ArticleAuthors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Article>().

            //modelBuilder.Entity<Article>()
            //    .HasMany(a => a.Authors)
            //    .WithMany(a => a.Articles);
            //modelBuilder.Entity<Author>()
            //    .HasMany(a => a.Articles)
            //    .WithMany(a => a.Authors);
            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.Articles);



            modelBuilder.Entity<ArticleAuthor>().HasKey(k => new { k.ArticleId, k.AuthorId });
            
            #region Create Data
            /*
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
                    new Article(){ Name="Name 1", Text="Lorem morem morel", Category = categories[0] , Authors=new List<Author>(){ authors[0] } },
                    new Article(){ Name="Name 2", Text="Lorem morem morel", Category = categories[2] , Authors=new List<Author>(){ authors[2] } },
                    new Article(){ Name="Name 3", Text="Lorem morem morel", Category = categories[1] , Authors=new List<Author>(){ authors[0], authors[1], authors[2] } },
                    new Article(){ Name="Name 4", Text="Lorem morem morel", Category = categories[2] , Authors=new List<Author>(){ authors[1], authors[2] } },
                    new Article(){ Name="Name 5", Text="Lorem morem morel", Category = categories[2] , Authors=new List<Author>(){ authors[0], authors[1] } },
                    new Article(){ Name="Name 6", Text="Lorem morem morel", Category = categories[0] , Authors=new List<Author>(){ authors[0], authors[2] } },
                    new Article(){ Name="Name 7", Text="Lorem morem morel", Category = categories[1] , Authors=new List<Author>(){ authors[1] } },
                };

            try
            {
                using (MainDbContext db = new MainDbContext())
                {
                    db.Categories.AddRange(categories);
                    db.Authors.AddRange(authors);
                    db.Articles.AddRange(articles);
                    db.SaveChanges();
                }

                Console.WriteLine("Finish!");
            }
            catch (Exception)
            {
                Console.WriteLine("something went wrong...");
                //throw;
            }
            */
            #endregion
            



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=RGN7_64-PC\\SQLEXPRESS;database=ASP_DB;Integrated security=true;Trusted_Connection=True;");

        }


    }
}
