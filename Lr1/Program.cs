using Lr1;
using System.IO;
using System.Text;



class Program
{
    public static string printGames(List<Game> games)
    {

        var report = new StringBuilder();

        report.AppendLine("IndexGame|    Winner|   Loser|  Rating");

        foreach (Game game in games)
        {
             report.AppendLine($"\t{game.IndexGame}|\t{game.Winner.Name}|\t {game.Winner.OpponentName}|\t{game.Game_rating}");
        }

        return report.ToString();
    }

    public static GameAccount PlayGame(int game_rating, GameAccount player1, GameAccount player2)
    {
        GameAccount winner; 
        Random rand = new Random();
        int player1numb = rand.Next(0, 10);
        int player2numb = rand.Next(0, 10);

        while (player1numb == player2numb)
        {
           player1numb = rand.Next(0, 10);
           player2numb = rand.Next(0, 10);
        }

        if (player1numb > player2numb)
        {
            player1.WinGame(player2, game_rating);
            winner = player1;
        }
        else{
            player1.LoseGame(player1, game_rating);
            winner = player2;
        }
        return winner;
    }



    public static void Main(string[] args)
    {
        List<Game> games = new List<Game>();
        int index_game = 1;
        

        GameAccount player1 = new GameAccount("Bane", 2000, 0);
        GameAccount player2 = new GameAccount("Chen", 2000, 0);

        player1.OpponentName = player2.Name;
        player2.OpponentName = player1.Name;

       string data;
        Console.WriteLine("Enter amount of rounds:");
        data = Console.ReadLine();
        
       int iterations = Convert.ToInt32(data);
        Console.WriteLine("Enter rating for each round:");


        for (int i = 0; i < iterations; i++)
        {
            string ratingdata;
            ratingdata = Console.ReadLine();
            int rating = Convert.ToInt32(ratingdata);

            if (rating < 0) {
               throw new ArgumentOutOfRangeException(nameof(rating),"Exeption catch negative rating, please enter positive value!");
            
            }

            GameAccount winner = PlayGame(rating, player1, player2);
            Game game1 = new Game(winner, index_game, rating);
            games.Add(game1);
            index_game++;
        }

        Console.WriteLine("Current Rating");
                Console.WriteLine(player1.Name + " = " + player1.CurrentRating + "; Amount games = " + player1.GameCount + "\n" + player2.Name + " = " + player2.CurrentRating + "; Amount games = "+ player1.GameCount + "\n");

                player1.GetStats(games);
        Console.WriteLine("\n");
                player2.GetStats(games);
        Console.WriteLine("\n");

        Console.WriteLine("GameHistory:");
        Console.WriteLine(printGames(games));  
        
        
        
    }

    
}