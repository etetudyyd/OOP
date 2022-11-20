using Lr1.GameResults;
using Lr1.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lr1.Accounts
{
    public class BaseAccount
    {
        public string Name { get; set; }
        public decimal CurrentRating { get; set; }
        public decimal GameCount { get; set; }
        public string OpponentName { get; set; }


        public BaseAccount(string name, decimal currentrating, decimal gamecount)
        {
            Name = name;
            CurrentRating = currentrating;
            GameCount = gamecount;

        }
        public void GetStats(List<Statistic> games)
        {
            Console.WriteLine(Name + " game stats history:");

            string gameResult;

            Console.WriteLine("|IndexGame|Opponent|Rating|GameResult");

            foreach (Statistic gamestats in games)
            {
                if (gamestats.Winner.Name == Name)
                {
                    gameResult = "Win";
                }
                else
                {
                    gameResult = "Lose";
                }

                Console.WriteLine("|\t" + gamestats.IndexGame + " |  " + OpponentName + "  |  " + gamestats.Game_rating + "  |  " + gameResult);
            }

        }

        public virtual void WinGame(BaseAccount player, BaseGame game, int gamemode)
        {
            switch (gamemode)
            {
                case 1:
                    CurrentRating = CurrentRating + game.getRating();

                    GameCount++;
                    break;
                case 2:
                    GameCount++;
                    break;
                case 3:
                    Console.WriteLine("Enter player, which rating on risk:\n1 - " + player.Name + "\n2 - " + player.OpponentName);
                    string strriskplayer = Console.ReadLine();
                    int riskplayer = Convert.ToInt32(strriskplayer);

                    switch (riskplayer)
                    {
                        case 1:
                            CurrentRating = CurrentRating + game.getRating();
                            GameCount++;
                            break;
                        case 2:
                            GameCount++;
                            break;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gamemode), "Exeption catch wrong rating, please enter requiring value!");
            }
        }
        public virtual void LoseGame(BaseAccount player, BaseGame game, int gamemode)
        {

            switch (gamemode)
            {
                case 1:
                    CurrentRating = CurrentRating - game.getRating();

                    GameCount++;
                    break;
                case 2:
                    GameCount++;
                    break;
                 case 3:
                     Console.WriteLine("Enter player, which rating on risk:\n1 - " + player.Name + "\n2 - " + player.OpponentName);
                     string strriskplayer = Console.ReadLine();
                     int riskplayer = Convert.ToInt32(strriskplayer);


                     switch (riskplayer)
                     {
                         case 1:
                CurrentRating = CurrentRating - game.getRating();
                            GameCount++;
                            break;
                        case 2:
                           
                            break;
                            default :
                            throw new ArgumentOutOfRangeException(nameof(gamemode), "Exeption catch wrong rating, please enter requiring value!");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gamemode), "Exeption catch wrong rating, please enter requiring value!");
            }
        }
        public virtual decimal GiveBonusRating(int rating)
        {
            return rating;
        }


    }
}


