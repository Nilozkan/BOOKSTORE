

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