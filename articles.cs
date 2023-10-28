namespace softUniClassesExc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] details = Console.ReadLine().Split(", ").ToArray();
            Article article = new Article()
            {
                Title = details[0],
                Content = details[1],
                Author = details[2]
            };

            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i ++)
            {
                string[] methodParts = Console.ReadLine().Split(": ").ToArray();
                switch(methodParts[0])
                {
                    case "Edit":
                        article.Edit(methodParts[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(methodParts[1]);
                        break;
                    case "Rename":
                        article.Rename(methodParts[1]);
                        break;
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
    }
}