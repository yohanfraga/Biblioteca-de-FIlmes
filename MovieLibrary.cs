namespace MovieLibrary
{
    public class MovieMenu
    {
        private readonly MovieDbContext _context = new MovieDbContext();

        public void DisplayMenu()
        {
            Console.WriteLine("---Biblioteca de Filmes---");
            Console.WriteLine("1. Adicionar Filme");
            Console.WriteLine("2. Buscar Filmes");
            Console.WriteLine("3. Dar Nota Para um Filme");
            Console.WriteLine("4. Sair");
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();

                Console.Write("Entre sua opção: ");
                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        SearchMovies();
                        break;
                    case 3:
                        RateMovie();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida. Tente Novamente");
                        break;
                }
            }
        }

        private void AddMovie()
        {
            Console.Write("\nNome do Filme: ");
            string title = Console.ReadLine();

            Console.Write("Genero: ");
            string genre = Console.ReadLine();

            Console.Write("App de streaming: ");
            string streaming = Console.ReadLine();

            Movie newMovie = new Movie
            {
                Title = title,
                Genre = genre,
                Rating = 0,
                Streaming = streaming
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            Console.WriteLine("\nFilme Adicionado com Sucesso!\n");
        }

        private void SearchMovies()
        {
            Console.Write("Qual genero(Digite * para qualquer genero): ");
            string genre = Console.ReadLine();

            Console.Write("Qual App de streaming(Digite * para qualquer app): ");
            string streaming = Console.ReadLine();

            Console.WriteLine("");

            if (streaming == "*" & genre == "*")
                foreach (MovieLibrary.Movie movie in _context.Movies.ToList())
                    Console.WriteLine(movie.Id + ". " + movie.Title + " | " + movie.Genre + " | " + movie.Streaming + " | " + movie.Rating);
            else if (streaming != "*" & genre == "*")
                foreach (MovieLibrary.Movie movie in _context.Movies.Where(b => b.Streaming.Contains(streaming)).ToList())
                    Console.WriteLine(movie.Id + ". " + movie.Title + " | " + movie.Genre + " | " + movie.Streaming + " | " + movie.Rating);
            else if (streaming == "*" & genre != "*")
                foreach (MovieLibrary.Movie movie in _context.Movies.Where(b => b.Genre.Contains(genre)).ToList())
                    Console.WriteLine(movie.Id + ". " + movie.Title + " | " + movie.Genre + " | " + movie.Streaming + " | " + movie.Rating);
            else if (streaming != "*" & genre != "*")
                foreach (MovieLibrary.Movie movie in _context.Movies.Where(b => b.Genre.Contains(genre)).Where(b => b.Streaming.Contains(streaming)).ToList())
                    Console.WriteLine(movie.Id + ". " + movie.Title + " | " + movie.Genre + " | " + movie.Streaming + " | " + movie.Rating);

            Console.WriteLine("");
        }

        private void RateMovie()
        {
            Console.WriteLine("");
            foreach (MovieLibrary.Movie movie in _context.Movies.ToList())
                Console.WriteLine(movie.Id + ". " + movie.Title + " | " + movie.Genre + " | " + movie.Streaming + " | " + movie.Rating);
            Console.WriteLine("");

            Console.Write("Escolhe o Id de um filme para dar Nota: ");
            int id = int.Parse(Console.ReadLine());
                
            MovieLibrary.Movie movieNewRating = _context.Movies.Single(b => b.Id.Equals(id));
            Console.Write("Digite a nota: ");
            movieNewRating.Rating = int.Parse(Console.ReadLine());

            _context.Movies.Update(movieNewRating);
            _context.SaveChanges();
            Console.WriteLine("\nNota Adicionada com Sucesso!\n");
        }
    }
}