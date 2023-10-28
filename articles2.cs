namespace softUniClassesExc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i ++)
            {
                string[] details = Console.ReadLine().Split(", ").ToArray();
                Article article = new Article()
                {
                    Title = details[0],
                    Content = details[1],
                    Author = details[2]
                };
                articles.Add(article);
            }

            foreach(Article article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}