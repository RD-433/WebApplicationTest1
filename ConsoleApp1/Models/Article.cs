using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTest1.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!"), StringLength(maximumLength: 500, ErrorMessage = "Max length is 500 symbols!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!"), StringLength(maximumLength: 10000, ErrorMessage = "Max length is 10000 symbols!")]
        public string Text { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        //public virtual List<Author> Authors { get; set; }


        public List<ArticleAuthor> Authors { get; set; }

    }
}
