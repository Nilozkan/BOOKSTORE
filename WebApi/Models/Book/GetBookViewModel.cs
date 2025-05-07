using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Book
{
    public class GetBookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; } 
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}