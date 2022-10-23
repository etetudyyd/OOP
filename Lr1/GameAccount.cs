using Lr1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class GameAccount
{
    public string Name { get; set; }
    public decimal CurrentRating { get; set; }
    public decimal GameCount { get; set; }

    public string OpponentName { get; set; }

    public GameAccount(string name, decimal currentrating, decimal gamecount)
    {
        Name = name;
        CurrentRating = currentrating;
        GameCount = gamecount;
    }

    public void WinGame(GameAccount loser, decimal rating)
    {
        CurrentRating = CurrentRating + rating;
        loser.CurrentRating = loser.CurrentRating - rating;
        if (loser.CurrentRating <= 1)
        {
            loser.CurrentRating = 1;
        }
        GameCount++;
    }

    public void LoseGame(GameAccount winner, decimal rating)
    {
        CurrentRating = CurrentRating - rating;
        winner.CurrentRating = winner.CurrentRating + rating;
        if (winner.CurrentRating <= 1) { 
        winner.CurrentRating = 1;
        }

        GameCount++;
    }

    public void GetStats(List<Game> games)
    {
        Console.WriteLine(Name + " game stats history:");

        string gameResult;

        Console.WriteLine("|IndexGame|Opponent|Rating|GameResult");

        foreach (Game game in games)
        {               
            if (game.Winner.Name == Name)
            {                                                    
                gameResult = "Win";
            }
            else
            {
                gameResult = "Lose";
            }

            Console.WriteLine("|\t" + game.IndexGame + " |  " + OpponentName + "  |  " + game.Game_rating + "  |  " + gameResult + "  ");
        }
        
    }

}



