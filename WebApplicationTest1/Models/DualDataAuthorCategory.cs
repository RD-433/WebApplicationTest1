using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTest1.Models
{
    public class DualDataAuthorCategory
    {
        public string ArticleName { get; set; }

        public string ArticleText { get; set; }

        public int CategoryId { get; set; }

        public int[] AuthorId { get; set; }
        public List<Author> Authors { get; set; }

        public List<Category> Categories { get; set; }

        public DualDataAuthorCategory()
        {

        }

        public DualDataAuthorCategory(List<Author> authors, List<Category> categories)
        {
            ArticleName = ArticleText = "";
            CategoryId = 0;

            Authors = authors;
            Categories = categories;
        }
    }
}
