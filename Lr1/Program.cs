using Lr1.Games;
using System.IO;
using System.Text;
using Lr1.Accounts;
using Lr1.GameResults;

class Program
{
    public static string printGames(List<Statistic> games)
    {

        var report = new StringBuilder();

        report.AppendLine("IndexGame|    Winner|   Loser|  Rating");

        foreach (Statistic gamestats in games)
        {
             report.AppendLine($"\t{gamestats.IndexGame}|\t{gamestats.Winner.Name}|\t {gamestats.Winner.OpponentName}|\t{gamestats.Game_rating}");
        }

        return report.ToString();
    }

    public static BaseAccount PlayGame(BaseGame game, BaseAccount player1, BaseAccount player2, int gamemode)
    {
        BaseAccount winner; 
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
            player1.WinGame(player1, game, gamemode);
            player2.LoseGame(player2, game, gamemode);
            winner = player1;
        }
        else
        {
            player2.WinGame(player2, game, gamemode);
            player1.LoseGame(player1, game, gamemode);
            winner = player2;
        }
       
        return winner;
    }



    public static void Main(string[] args)
    {
        List<Statistic> games = new List<Statistic>();
        int index_game = 1;
        

        var player1 = new BonusAccount("Bane", 2000, 0 );//аккаунт с 10% бонусом за винстрик
        var player2 = new VipAccount ("Chen", 2000, 0);//в 2 раз меньше штраф за проигрыш 

        player1.OpponentName = player2.Name;
        player2.OpponentName = player1.Name;
       
        Console.WriteLine("Enter amount of rounds:");
        string data = Console.ReadLine();   
        int iterations = Convert.ToInt32(data);

        Console.WriteLine("Enter game mode:\n1 - ClassicGame\n2 - TrainingGame\n3 - OneRiskGame\n");
        string gamemodestr = Console.ReadLine();
        int gamemode = Convert.ToInt32(gamemodestr);

        BaseGame game;

        decimal rating = 0;

        if (gamemode == 1)
        {
            Console.WriteLine("Enter rating for rounds:");
            string ratingdata = Console.ReadLine();
            rating = Convert.ToInt32(ratingdata);
            game = new ClassicGame(index_game, rating);
        }

        else if (gamemode == 2)
        {
            game = new TrainingGame(index_game, rating);
        }
        else if(gamemode == 3){
            Console.WriteLine("Enter rating for rounds:");
            string ratingdata = Console.ReadLine();
            rating = Convert.ToInt32(ratingdata);
            game = new OneRiskGame(index_game, rating);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Exeption catch negative rating, please enter positive value!");
        }

        for (int i = 0; i < iterations; i++)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Exeption catch negative rating, please enter positive value!");

            }
         
            BaseAccount winner = PlayGame(game, player1, player2, gamemode);

            Statistic gamestats = new Statistic(winner, index_game, rating, winner.CurrentRating);
            games.Add(gamestats);
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