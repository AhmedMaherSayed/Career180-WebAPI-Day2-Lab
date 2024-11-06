namespace Day2_Lab.Models
{
    public static class NewsData
    {
        public static List<News> NewsList { get; set; } = new List<News>()
        {
            new News() {ID = 1, Title = "How to Deal with AI", Author = "Hassan", Description = "desc1"},
            new News() {ID = 2, Title = "SciFi", Author = "Ahmed", Description = "desc2"},
            new News() {ID = 2, Title = "Title", Author = "Ali", Description = "desc3"},
        };


    }
}
