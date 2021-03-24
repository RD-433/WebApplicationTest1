using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTest1.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public List<Article> Articles { get; set; }

        public List<ArticleAuthor> Articles { get; set; }
    }
}
